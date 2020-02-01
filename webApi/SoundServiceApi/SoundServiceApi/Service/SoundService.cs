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
    /// audioファイルを返す
    /// </summary>
    public class SoundService
    {
        private readonly SoundServiceApiContext context = new SoundServiceApiContext();

        /// <summary>
        /// ファイル名より検索
        /// </summary>
        /// <param name="_fileName"></param>
        /// <returns></returns>
        public AudioViewModel GetByFileName(string _fileName)
        {
            return ViewModelFactory.GetMusicVMInstance(IOUtillity.GetBytesByFileName(context.Parameter.FirstOrDefault().RootDir, _fileName),
                                                       context.MusicInfo.Where(w => w.FileName.Equals(_fileName)).FirstOrDefault());
        }

        /// <summary>
        /// ファイルが存在するかチェック
        /// たぶんいらない
        /// </summary>
        /// <param name="_fileName"></param>
        /// <returns></returns>
        public bool Exist(string _fileName)
        {
            return IOUtillity.GetAudioByFileName(context.Parameter.FirstOrDefault().RootDir, _fileName).Any() && context.MusicInfo.Where(w => w.FileName.Equals(_fileName)).Any();
        }
    }
}
