using System;
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
        public string artist { get; set; }
        public string title { get; set; }
        public string fileName { get; set; }
        public byte[] content { get; set; }
    }
}
