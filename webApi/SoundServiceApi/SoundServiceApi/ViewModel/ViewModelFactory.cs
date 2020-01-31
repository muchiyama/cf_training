using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SoundServiceApi.ViewModel
{
    public static class ViewModelFactory
    {
        public static MusicViewModel GetMusicVMInstance(byte[] _content, MusicInfo _model) 
        {
            return new MusicViewModel
            {
                artist = _model.Artist,
                title = _model.Title,
                fileName = _model.FileName,
                content = _content
            };
        }

        public static ContentsInfoViewModel GetContentsInfoVMInstance(MusicInfo _model)
        {
            return new ContentsInfoViewModel
            {
                artist = _model.Artist,
                title = _model.Title,
                genre = _model.Genre,
                fileName = _model.FileName
            };
        }

    }
}
