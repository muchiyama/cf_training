using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using SoundServiceApi.ViewModel;

namespace SoundServiceApi.Service
{
    public class MusicInfoService
    {
        private readonly SoundServiceApiContext context = new SoundServiceApiContext();
        
        public IEnumerable<ContentsInfoViewModel> GetAll()
        {
            foreach(var r in context.MusicInfo)
                yield return ViewModelFactory.GetContentsInfoVMInstance(r);
        }

        public IEnumerable<ContentsInfoViewModel> GetByArtist(string _artist)
        {
            foreach (var r in context.MusicInfo.Where(w => w.Artist.Equals(_artist)))
                yield return ViewModelFactory.GetContentsInfoVMInstance(r);
        }
        public MusicInfo GetByFileName(string _fileName)
        {
            return context.MusicInfo.Where(w => w.FileName.Equals(_fileName)).FirstOrDefault();
        }
    }
}
