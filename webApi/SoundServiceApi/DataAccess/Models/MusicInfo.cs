using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class MusicInfo
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Album { get; set; }
        public string Year { get; set; }
        public string Genre { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
