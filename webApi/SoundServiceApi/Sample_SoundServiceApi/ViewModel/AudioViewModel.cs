using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_SoundServiceApi.ViewModel
{
    public class AudioViewModel
    {
        /// <summary>
        /// アーティスト名
        /// </summary>
        public string artist { get; set; }
        /// <summary>
        /// 曲名
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// ファイル名
        /// </summary>
        public string fileName { get; set; }
        /// <summary>
        /// Audioファイル
        /// </summary>
        public byte[] content { get; set; }
    }
}
