﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using DataAccess.Models;
using DataAccess.Factory;
using DataAccess;
using Common;
using Common.CF_Logger;

namespace SoundBatch.Service
{
    internal class RegisterContentsInfo
    {

        private readonly SoundServiceApiContext context = new SoundServiceApiContext();
        private readonly CF_ILogger logger = CF_LoggerFactory.GetCFLogger();

        /// <summary>
        /// 音楽ファイルの差分更新をする
        /// ①サーバー内の実ファイルをすべて取得する
        /// ②DB内の登録データをすべて取得する
        /// ③差分更新を実行する
        /// 
        /// 同一データの判定基準 -> ファイル名が同一かつファイルのタイムスタンプが一致している
        /// </summary>
        public void Update()
        {
            // サーバー内のファイル一覧
            var files = IOUtillity.GetAudioFiles(context.Parameter.FirstOrDefault().RootDir,
                                              context.PlayingExtensionConfiguration.FirstOrDefault().Convert()).ToDictionary(k => k.Name, v => v.LastWriteTime);
            // DBデータ一覧
            var records = context.MusicPath.ToDictionary(k => k.FileName, v => (DateTime)v.UpdatedDate);

            // トランザクション開始
            context.Database.BeginTransaction();

            // 不要レコード削除
            DeleteDifferent(records.Except(files).ToDictionary(k => k.Key, v => v.Value));
            logger.Info($"削除件数: {context.SaveChanges() / 2}件"); 
            // 新規レコード追加
            InsertDifferent(files.Except(records).ToDictionary(k => k.Key, v => v.Value));
            logger.Info($"登録件数: {context.SaveChanges() / 2}件");
            
            // トランザクション終了
            context.Database.CommitTransaction();
        }

        /// <summary>
        /// 新規データ登録
        /// </summary>
        /// <param name="_target"></param>
        private void InsertDifferent(IDictionary<string, DateTime> _target)
        {
            if (!_target.Any())
                return;

            InsertPath(_target);
            InsertInfo(_target);
        }

        /// <summary>
        /// Pathの設定をDBに登録
        /// </summary>
        /// <param name="_target"></param>
        private void InsertPath(IDictionary<string, DateTime> _target)
        {
            var factory = ModelFactory.GetInstance();
            foreach (var kvp in _target)
                context.MusicPath.Add(factory.CreateMusicPath(kvp));
        }

        /// <summary>
        /// 音楽情報を登録
        /// </summary>
        /// <param name="_target"></param>
        private void InsertInfo(IDictionary<string, DateTime> _target)
        {
            var factory = ModelFactory.GetInstance();
            foreach (var kvp in _target) 
                context.MusicInfo.Add(factory.CreateMusicInfo(kvp, TagLib.File.Create($@"{this.context.Parameter.FirstOrDefault().RootDir}\{kvp.Key}")));
        }

        /// <summary>
        /// 不要データを削除
        /// </summary>
        /// <param name="_target"></param>
        private void DeleteDifferent(IDictionary<string, DateTime> _target)
        {
            if (!_target.Any())
                return;

            DeletePath(_target);
            DeleteInfo(_target);
        }

        /// <summary>
        /// Pathの設定をDBにから削除
        /// </summary>
        /// <param name="_target"></param>
        private void DeletePath(IDictionary<string, DateTime> _target)
        {
            foreach(var kvp in _target)
                context.MusicPath.Remove(context.MusicPath.Where(w => w.FileName.Equals(kvp.Key)).FirstOrDefault());
        }

        /// <summary>
        /// 音楽情報の設定をDBから削除
        /// </summary>
        /// <param name="_target"></param>
        private void DeleteInfo(IDictionary<string, DateTime> _target)
        {
            foreach (var kvp in _target)
                context.MusicInfo.Remove(context.MusicInfo.Where(w => w.FileName.Equals(kvp.Key)).FirstOrDefault());
        }
    }
}
