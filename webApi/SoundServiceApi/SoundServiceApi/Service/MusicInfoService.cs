using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using SoundServiceApi.ViewModel;

namespace SoundServiceApi.Service
{
    /// <summary>
    /// コンテンツ情報を返す
    /// </summary>
    public class MusicInfoService : IMyService
    {
        private readonly SoundServiceApiContext _context;

        public MusicInfoService(SoundServiceApiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// コンテンツ一覧取得
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ContentsInfoViewModel> GetAll()
        {
            foreach(var r in _context.MusicInfo)
                yield return ViewModelFactory.GetContentsInfoVMInstance(r);
        }

        /// <summary>
        /// アーティスト名より取得
        /// 部分一致検索
        /// </summary>
        /// <param name="_artist"></param>
        /// <returns></returns>
        public IEnumerable<ContentsInfoViewModel> GetByArtist(string _artist)
        {
            foreach (var r in _context.MusicInfo.Where(w => w.Artist.Contains(_artist)))
                yield return ViewModelFactory.GetContentsInfoVMInstance(r);
        }

        /// <summary>
        /// ファイル名より取得
        /// </summary>
        /// <param name="_fileName"></param>
        /// <returns></returns>
        public MusicInfo GetByFileName(string _fileName)
        {
            return _context.MusicInfo.Where(w => w.FileName.Equals(_fileName)).FirstOrDefault();
        }
    }
}
