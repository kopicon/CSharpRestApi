using System;
using System.Collections.Generic;
using List;
using MusicListBLL.BusinessObjects;
using List.Entities;
using System.Linq;
using MusicListBLL.Converters;

namespace MusicListBLL.Services
{
    public class MusicService : IMusicService
    {
        MusicConverter conv = new MusicConverter();
        DALFacade facade;

        public MusicService(DALFacade facade)
        {
            this.facade = facade;
        }

        public MusicBO Add(MusicBO music)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newMusic = uow.MusicRepository.Add(conv.Convert(music));
                uow.Complete();
                return conv.Convert(newMusic);
            }
        }
        public void AddAll(List<MusicBO> musics)
        {
            using (var uow = facade.UnitOfWork)
            {
                foreach (var music in musics)
                {
                    uow.MusicRepository.Add(conv.Convert(music));
                    
                }
                uow.Complete(); ;
            }
        }

        public MusicBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newMusic = uow.MusicRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(newMusic);
            }
        }

        public MusicBO Edit(MusicBO music)
        {
            using (var uow = facade.UnitOfWork)
            {
                var musicFromDb = uow.MusicRepository.GetMusic(music.Id);
                if (musicFromDb == null)
                {
                    throw new InvalidOperationException("Music not found");
                }
                musicFromDb.Name = music.Name;
                musicFromDb.Style = music.Style;
                uow.Complete();
                return conv.Convert(musicFromDb);
            }
        }

        public List<MusicBO> GetAllMusic()
        {
            using (var uow = facade.UnitOfWork)
            {
                //return uow.MusicRepository.GetAllMusic();
                return uow.MusicRepository.GetAllMusic().Select(conv.Convert).ToList();
            }
        }

        public MusicBO GetMusic(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return conv.Convert(uow.MusicRepository.GetMusic(Id));
            }
        }

    }
}
