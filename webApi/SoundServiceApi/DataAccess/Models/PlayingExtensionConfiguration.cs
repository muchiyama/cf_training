using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class PlayingExtensionConfiguration
    {
        public bool? Aiff { get; set; }
        public bool? Mp3 { get; set; }
        public bool? Wav { get; set; }
        public bool? Aac { get; set; }  
        public bool? Flac { get; set; }
    }
}
