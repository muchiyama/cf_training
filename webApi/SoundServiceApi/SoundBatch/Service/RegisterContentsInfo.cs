using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using DataAccess.Models;
using DataAccess.Factory;
using DataAccess;
using Common;

namespace SoundBatch.Service
{
    internal class RegisterContentsInfo
    {

        private readonly SoundServiceApiContext context = new SoundServiceApiContext();

        public void Update()
        {

            var files = IOUtillity.GetMp3FileList(context.Parameter.FirstOrDefault().RootDir, 
                                              context.PlayingExtensionConfiguration.FirstOrDefault().Convert()).ToDictionary(k => k.Name, v => v.LastWriteTime);
            var records = context.MusicPath.ToDictionary(k => k.FileName, v => (DateTime)v.UpdatedDate);

            context.Database.BeginTransaction();
            DeleteDifferent(records.Except(files).ToDictionary(k => k.Key, v => v.Value));
            Console.WriteLine(context.SaveChanges()); 
            InsertDifferent(files.Except(records).ToDictionary(k => k.Key, v => v.Value));
            Console.WriteLine(context.SaveChanges()); 
            context.SaveChanges();
            context.Database.CommitTransaction();
        }

        private void InsertDifferent(IDictionary<string, DateTime> target)
        {
            if (!target.Any())
                return;

            InsertPath(target);
            InsertInfo(target);
        }

        private void InsertPath(IDictionary<string, DateTime> target)
        {
            var factory = ModelFactory.GetInstance();
            foreach (var kvp in target)
                context.MusicPath.Add(factory.CreateMusicPath(kvp));
        }

        private void InsertInfo(IDictionary<string, DateTime> target)
        {
            var factory = ModelFactory.GetInstance();
            foreach (var kvp in target) 
                context.MusicInfo.Add(factory.CreateMusicInfo(kvp, TagLib.File.Create($@"{this.context.Parameter.FirstOrDefault().RootDir}\{kvp.Key}")));
        }
        private void DeleteDifferent(IDictionary<string, DateTime> target)
        {
            if (!target.Any())
                return;

            DeletePath(target);
            DeleteInfo(target);
        }

        private void DeletePath(IDictionary<string, DateTime> target)
        {
            foreach(var kvp in target)
                context.MusicPath.Remove(context.MusicPath.Where(w => w.FileName.Equals(kvp.Key)).FirstOrDefault());
        }

        private void DeleteInfo(IDictionary<string, DateTime> target)
        {
            foreach (var kvp in target)
                context.MusicInfo.Remove(context.MusicInfo.Where(w => w.FileName.Equals(kvp.Key)).FirstOrDefault());
        }
    }
}
