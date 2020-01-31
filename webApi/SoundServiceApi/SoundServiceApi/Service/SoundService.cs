using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using Common;
using SoundServiceApi.ViewModel;

namespace SoundServiceApi.Service
{
    /// <summary>
    /// mp3ファイルを返す
    /// </summary>
    public class SoundService
    {
        private readonly SoundServiceApiContext context = new SoundServiceApiContext();
        public MusicViewModel GetByFileName(string _fileName)
        {
            return ViewModelFactory.GetMusicVMInstance(IOUtillity.GetBytesByFileName(context.Parameter.FirstOrDefault().RootDir, _fileName),
                                                       context.MusicInfo.Where(w => w.FileName.Equals(_fileName)).FirstOrDefault());
        }
        public bool Exist(string _fileName)
        {
            return IOUtillity.GetByFileName(context.Parameter.FirstOrDefault().RootDir, _fileName).Any() && context.MusicInfo.Where(w => w.FileName.Equals(_fileName)).Any();
        }
    }
}
