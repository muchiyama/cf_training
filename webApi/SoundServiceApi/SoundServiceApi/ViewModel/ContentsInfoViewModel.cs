using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundServiceApi.ViewModel
{
    /// <summary>
    /// コンテンツ情報のモデル
    /// </summary>
    public class ContentsInfoViewModel
    {
        /// <summary>
        /// アーティスト
        /// </summary>
        public string artist { get; set; }
        /// <summary>
        /// タイトル
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// ジャンル
        /// </summary>
        public string genre { get; set; }
        /// <summary>
        /// ファイル名
        /// </summary>
        public string fileName { get; set; }
    }
}
