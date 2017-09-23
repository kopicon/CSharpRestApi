using System;
using System.Collections.Generic;
using System.Text;

namespace MusicListDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IMusicRepository MusicRepository { get; }

        int Complete();
    }
}
