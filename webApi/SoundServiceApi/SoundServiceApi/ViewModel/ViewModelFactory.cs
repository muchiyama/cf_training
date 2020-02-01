using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SoundServiceApi.ViewModel
{
    /// <summary>
    /// ViewModelのFactory
    /// </summary>
    public static class ViewModelFactory
    {

        public static AudioViewModel GetMusicVMInstance() 
        {
            return new AudioViewModel(); 
        }

        /// <summary>
        /// 詰め替え
        /// </summary>
        /// <param name="_content"></param>
        /// <param name="_model"></param>
        /// <returns></returns>
        public static AudioViewModel GetMusicVMInstance(byte[] _content, MusicInfo _model) 
        {
            return new AudioViewModel
            {
                artist = _model.Artist,
                title = _model.Title,
                fileName = _model.FileName,
                content = _content
            };
        }

        public static ContentsInfoViewModel GetContentsInfoVMInstance() 
        {
            return new ContentsInfoViewModel(); 
        }

        /// <summary>
        /// 詰め替え
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
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
