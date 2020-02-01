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
        public string artist { get; set; }
        public string title { get; set; }
        public string genre { get; set; }
        public string fileName { get; set; }
    }
}
