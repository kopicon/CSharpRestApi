using MusicListDAL.Repositories;
using MusicListDAL.UOW;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicListDAL
{
    public class DALFacade
    {
        public IMusicRepository MusicRepository
        {
            get
            {
                return new MusicRepositoryEFMemory(
                    new Context.InMemoryContext());
            }
        }
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new UnitOfWorkMem();
            }
        }
    }
}
