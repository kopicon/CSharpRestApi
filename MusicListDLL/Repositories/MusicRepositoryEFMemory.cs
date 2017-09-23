using System;
using System.Collections.Generic;
using System.Text;
using MusicListDAL.Context;
using System.Linq;
using MusicListDAL.Entities;

namespace MusicListDAL.Repositories
{
    class MusicRepositoryEFMemory : IMusicRepository
    {
        InMemoryContext context;
        public MusicRepositoryEFMemory(InMemoryContext context)
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
            return context.Musics.ToList();
        }

        public Music GetMusic(int Id)
        {
            return context.Musics.FirstOrDefault(x => x.Id == Id);
        }
    }
}
