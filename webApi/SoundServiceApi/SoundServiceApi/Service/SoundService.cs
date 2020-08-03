using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using Common;
using SoundServiceApi.ViewModel;
using Common.Attribute;

namespace SoundServiceApi.Service
{
    /// <summary>
    /// audioファイルを返す
    /// </summary>
    public class SoundService : IMyService
    {
        private readonly SoundServiceApiContext _context;

        public SoundService(SoundServiceApiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// ファイル名より検索
        /// </summary>
        /// <param name="_fileName"></param>
        /// <returns></returns>
        public AudioViewModel GetByFileName(string _fileName)
        {
            return ViewModelFactory.GetMusicVMInstance(IOUtillity.GetBytesByFileName(_context.Parameter.FirstOrDefault().RootDir, _fileName),
                                                       _context.MusicInfo.Where(w => w.FileName.Equals(_fileName)).FirstOrDefault());
        }

        /// <summary>
        /// ファイルが存在するかチェック
        /// たぶんいらない
        /// </summary>
        /// <param name="_fileName"></param>
        /// <returns></returns>
        public bool Exist(string _fileName)
        {
            return IOUtillity.GetAudioByFileName(_context.Parameter.FirstOrDefault().RootDir, _fileName).Any() && _context.MusicInfo.Where(w => w.FileName.Equals(_fileName)).Any();
        }
    }
}
