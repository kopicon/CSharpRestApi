using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public interface IUnitOfWork : IDisposable
    {
        IMusicRepository MusicRepository { get; }
        IOrderRepository OrderRepository { get; }

        int Complete();
    }
}
