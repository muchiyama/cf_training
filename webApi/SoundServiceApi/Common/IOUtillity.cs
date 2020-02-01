using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Common
{
    public static class IOUtillity
    {
        /// <summary>
        /// フォルダを取得する
        /// </summary>
        /// <param name="_path"></param>
        /// <returns></returns>
        public static DirectoryInfo GetDerectory(string _path)
        {
            return new DirectoryInfo(_path);
        }

        /// <summary>
        /// 音楽ファイルを取得する
        /// </summary>
        /// <param name="_path"></param>
        /// <param name="_conf"></param>
        /// <returns></returns>
        public static IEnumerable<FileInfo> GetAudioFiles(string _path, IDictionary<string, bool> _conf)
        {
            var res = new List<FileInfo>();
            foreach (var e in _conf.Where(w => w.Value)) 
                res.AddRange(IOUtillity.GetDerectory(_path).GetFiles(@$"*.{e.Key}").ToList());
            return res;
        }

        /// <summary>
        /// ファイル名からAudioを取得する
        /// </summary>
        /// <param name="_path"></param>
        /// <param name="_fileName"></param>
        /// <returns></returns>
        public static IEnumerable<FileInfo> GetAudioByFileName(string _path, string _fileName)
        {
            return IOUtillity.GetDerectory(_path).GetFiles(_fileName);
        }

        /// <summary>
        /// バイト配列でAudioを取得する
        /// </summary>
        /// <param name="_path"></param>
        /// <param name="_fileName"></param>
        /// <returns></returns>
        public static byte[] GetBytesByFileName(string _path, string _fileName)
        {
            return File.ReadAllBytes($"{_path}/{_fileName}") ?? new byte[0];
        }

        /// <summary>
        /// ストリームでAudioを取得する
        /// </summary>
        /// <param name="_path"></param>
        /// <param name="_fileName"></param>
        /// <returns></returns>
        public static Stream GetStreamByFileName(string _path, string _fileName)
        {
            return GetAudioByFileName(_path, _fileName).FirstOrDefault().OpenRead();
        }
    }
}
