using System;
using System.Collections.Generic;

namespace Sample_SoundServiceApi.Models
{
    public partial class MusicPath
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
