using MusicListBLL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicListBLL
{
    public interface IOrderService
    {
        OrderBO Get(int Id);
        List<OrderBO> GetAll();
        OrderBO Add(OrderBO music);
        OrderBO Delete(int Id);
        OrderBO Edit(OrderBO music);
    }
}
