using MusicListBLL.BusinessObjects;
using List.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicListBLL.Converters
{
    class MusicConverter
    {
        internal Music Convert(MusicBO music)
        {
            if (music == null) { return null; }           
            return new Music()
            {
                Id = music.Id,
                Name = music.Name,
                Style = music.Style
            };
        }
        internal MusicBO Convert(Music music)
        {
            if (music == null) { return null; }
            return new MusicBO()
            {
                Id = music.Id,
                Name = music.Name,
                Style = music.Style
            };
        }
    }
}
