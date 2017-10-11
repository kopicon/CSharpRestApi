using System;
using System.Collections.Generic;
using System.Text;
using MusicListBLL.Services;
using List;

namespace MusicListBLL
{
    public class BLLFacade
    {
        public IMusicService MusicService
        {
            get { return new MusicService(new DALFacade()); }
        }
        public IOrderService OrderService
        {
            get { return new OrderService(new DALFacade()); }
        }
    }
}
