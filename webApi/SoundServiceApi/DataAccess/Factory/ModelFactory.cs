using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace DataAccess.Factory
{
    public class ModelFactory
    {
        private static ModelFactory instance = new ModelFactory();

        public static ModelFactory GetInstance()
        {
            return instance;
        }

        private ModelFactory()
        {

        }

        public MusicInfo CreateMusicInfo()
        {
            return new MusicInfo();
        }

        public MusicInfo CreateMusicInfo(KeyValuePair<string, DateTime> kvp, TagLib.File _metaData)
        {
            return new MusicInfo()
            {
                FileName = kvp.Key,
                Artist = _metaData.Tag.FirstAlbumArtist ?? Const.a_Artist,
                Title = _metaData.Tag.Title ?? Const.a_Title,
                Album = _metaData.Tag.Album ?? Const.a_Album,
                Year = _metaData.Tag.Year.ToString() ?? Const.a_Year,
                Genre = _metaData.Tag.FirstGenre ?? Const.a_Genre,
                CreatedDate = kvp.Value,
                UpdatedDate = kvp.Value
            };
        }

        public MusicPath CreateMusicPath()
        {
            return new MusicPath();
        }

        public MusicPath CreateMusicPath(KeyValuePair<string, DateTime> kvp)
        {
            return new MusicPath 
            {
                FileName = kvp.Key,
                CreatedDate = kvp.Value,
                UpdatedDate = kvp.Value
            };
        }
    }
}
