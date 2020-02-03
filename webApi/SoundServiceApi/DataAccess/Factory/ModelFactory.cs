using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace DataAccess.Factory
{
    /// <summary>
    /// Modelを生成する
    /// </summary>
    public class ModelFactory
    {
        private static ModelFactory instance = new ModelFactory();

        public static ModelFactory GetInstance()
        {
            return instance;
        }

        /// <summary>
        /// MusicInfoのインスタンス返す
        /// </summary>
        /// <returns></returns>
        public MusicInfo CreateMusicInfo()
        {
            return new MusicInfo();
        }

        /// <summary>
        /// バッチ用
        /// 使用ライブラリ -> Taglib
        /// なんか音楽ファイルのメタデータ取得してくれる
        /// </summary>
        /// <param name="_kvp"></param>
        /// <param name="_metaData"></param>
        /// <returns></returns>
        public MusicInfo CreateMusicInfo(KeyValuePair<string, DateTime> _kvp, TagLib.File _metaData)
        {
            return new MusicInfo()
            {
                FileName = _kvp.Key, // ファイル名
                Artist = _metaData.Tag.FirstAlbumArtist ?? _metaData.Tag.FirstArtist ?? Const.a_Artist, // アーティスト名
                Title = _metaData.Tag.Title ?? _kvp.Key.TrimEnd(@".mp3".ToCharArray()), // 曲名
                Album = _metaData.Tag.Album ?? Const.a_Album, // アルバム名
                Year = _metaData.Tag.Year.ToString() ?? Const.a_Year, // リリース年
                Genre = _metaData.Tag.FirstGenre ?? Const.a_Genre, // ジャンル
                CreatedDate = _kvp.Value, // 作成日時
                UpdatedDate = _kvp.Value // 更新日時(差分は削除するから実質使わん)
            };
        }

        /// <summary>
        /// MusicPathのインスタンス返す
        /// </summary>
        /// <returns></returns>
        public MusicPath CreateMusicPath()
        {
            return new MusicPath();
        }

        /// <summary>
        /// バッチ用
        /// </summary>
        /// <param name="_kvp"></param>
        /// <returns></returns>
        public MusicPath CreateMusicPath(KeyValuePair<string, DateTime> _kvp)
        {
            return new MusicPath 
            {
                FileName = _kvp.Key, // ファイル名
                CreatedDate = _kvp.Value, // 作成日時
                UpdatedDate = _kvp.Value // 更新日時
            };
        }
    }
}
