using MusicListBLL.BusinessObjects;
using MusicListDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicListBLL.Converters
{
    class MusicConverter
    {
        internal Music Convert(MusicBO music)
        {
            return new Music()
            {
                Id = music.Id,
                Name = music.Name,
                Style = music.Style
            };
        }
        internal MusicBO Convert(Music music)
        {
            return new MusicBO()
            {
                Id = music.Id,
                Name = music.Name,
                Style = music.Style
            };
        }
    }
}
