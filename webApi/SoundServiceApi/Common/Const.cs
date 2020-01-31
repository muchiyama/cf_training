using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class Const
    {
        #region コネクション
        public static string Con => @"Server=W1003848N182\SQLEXPRESS;Database=SoundServiceApi;persist security info=True;user id=sa;password=1234567;MultipleActiveResultSets=True";
        #endregion

        #region モデル設定パラメーター
        public static string Anonymous => "不明な";
        public static string a_Artist => $"{Anonymous}アーティスト";
        public static string a_Title => $"{Anonymous}タイトル";
        public static string a_Album => $"{Anonymous}アルバム";
        public static string a_Genre => $"{Anonymous}ジャンル";
        public static string a_Year => $"{Anonymous}リリース年";
        public static string year_fmt => "yyyy年";

        public static string loggerConfDir => "./log4net.config";
        public static string loggerName => "debug";
        #endregion

        #region message

        #region 名詞
        /// <summary>
        /// コンテンツ更新バッチ処理
        /// </summary>
        public static string N001 => "コンテンツ更新バッチ処理";
        /// <summary>
        /// コンテンツ取得処理
        /// </summary>
        public static string N002 => "コンテンツ取得処理";
        /// <summary>
        /// 音楽ファイル取得
        /// </summary>
        public static string N003 => "音楽ファイル取得";
        #endregion
        #region Info
        /// <summary>
        /// $"{ s }を開始します";
        /// </summary>
        public static string I001 (string s) => $"{s}を開始します";
        /// <summary>
        /// { s }を終了します
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string I002 (string s) => $"{s}を終了します";
        /// <summary>
        /// コンテンツ取得処理を開始します
        /// </summary>
        
        #endregion
        #region Error
        /// <summary>
        /// 致命的なエラーが発生しました
        /// </summary>
        public static string E001 => $"致命的なエラーが発生しました";
        /// <summary>
        /// ファイル名が指定されていません
        /// </summary>
        public static string E002 => $"ファイル名が指定されていません";
        /// <summary>
        /// 不正なリクエストです
        /// </summary>
        public static string E003 => $"不正なリクエストです";
        //ファイル名が指定されていません
        #endregion
        #region Fatal
        /// <summary>
        /// 致命的なエラーが発生しました
        /// </summary>
        public static string F001 => $"致命的なエラーが発生しました";
        #endregion


        #endregion

    }
}
