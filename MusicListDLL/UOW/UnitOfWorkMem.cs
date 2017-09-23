using MusicListDAL.Context;
using MusicListDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicListDAL.UOW
{
    public class UnitOfWorkMem : IUnitOfWork
    {
        public IMusicRepository MusicRepository { get; internal set; }
        private InMemoryContext context;

        public UnitOfWorkMem()
        {
            context = new InMemoryContext();
            MusicRepository = new MusicRepositoryEFMemory(context);
        }
        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
