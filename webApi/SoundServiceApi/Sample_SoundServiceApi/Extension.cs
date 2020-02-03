using Sample_SoundServiceApi.Models;
using Sample_SoundServiceApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_SoundServiceApi
{
    public static class Extension
    {
        public static IEnumerable<ContentViewModel> ConvertToViewModel(this IEnumerable<MusicInfo> models)
        {
            foreach (var m in models)
                yield return new ContentViewModel
                {
                    artist = m.Artist,
                    title = m.Title,
                    genre = m.Genre,
                    fileName = m.FileName
                };
        }

        public static AudioViewModel ConvertToViewModel(this MusicInfo model, byte[] audio)
        {
            return new AudioViewModel
            {
                artist = model.Artist,
                title = model.Title,
                fileName = model.FileName,
                content = audio
            };
        }
    }
}
