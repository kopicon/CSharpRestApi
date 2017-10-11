using List.Context;
using List.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace List.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public IMusicRepository MusicRepository { get; internal set; }
        public IOrderRepository OrderRepository { get; internal set; }
        private MusicAppContext context;

        public UnitOfWork()
        {
            context = new MusicAppContext();
            MusicRepository = new MusicRepositoryEFMemory(context);
            OrderRepository = new OrderRipository(context);
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
