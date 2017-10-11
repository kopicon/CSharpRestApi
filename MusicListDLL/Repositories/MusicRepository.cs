using System;
using System.Collections.Generic;
using System.Text;
using List.Context;
using System.Linq;
using List.Entities;
using Microsoft.EntityFrameworkCore;

namespace List.Repositories
{
    class MusicRepositoryEFMemory : IMusicRepository
    {
        MusicAppContext context;
        public MusicRepositoryEFMemory(MusicAppContext context)
        {
            this.context = context;
        }
        public Music Add(Music music)
        {
            context.Musics.Add(music);
            return music;
        }

        public Music Delete(int Id)
        {
            var music = GetMusic(Id);
            context.Musics.Remove(music);
            return music;
        }

        public List<Music> GetAllMusic()
        {
            return context.Musics.Include(c => c.Orders).ToList();
        }

        public Music GetMusic(int Id)
        {
            return context.Musics.FirstOrDefault(x => x.Id == Id);
        }
    }
}
