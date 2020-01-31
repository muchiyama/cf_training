using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Common
{
    public static class IOUtillity
    {
        public static DirectoryInfo GetDerectory(string _path)
        {
            return new DirectoryInfo(_path);
        }

        public static IEnumerable<FileInfo> GetMp3FileList(string _path, IDictionary<string, bool> _conf)
        {
            var res = new List<FileInfo>();
            foreach (var e in _conf.Where(w => w.Value)) 
                res.AddRange(IOUtillity.GetDerectory(_path).GetFiles(@$"*.{e.Key}").ToList());

            return res;
        }

        public static IEnumerable<FileInfo> GetByFileName(string _path, string _fileName)
        {
            return IOUtillity.GetDerectory(_path).GetFiles(_fileName);
        }

        public static byte[] GetBytesByFileName(string _path, string _fileName)
        {
            return File.ReadAllBytes($"{_path}/{_fileName}") ?? new byte[0];
        }
        public static Stream GetStreamByFileName(string _path, string _fileName)
        {
            return GetByFileName(_path, _fileName).FirstOrDefault().OpenRead();
        }
    }
}
