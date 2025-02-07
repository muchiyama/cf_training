﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SoundServiceApi.ViewModel
{
    /// <summary>
    /// audioファイルのモデル
    /// </summary>
    public class AudioViewModel
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
        /// ファイル名
        /// </summary>
        public string fileName { get; set; }
        /// <summary>
        /// Audioファイル
        /// </summary>
        public byte[] content { get; set; }
    }
}
