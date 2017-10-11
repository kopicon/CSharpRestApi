using List.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public interface IOrderRepository
    {
        Order Get(int Id);
        List<Order> GetAll();
        Order Add(Order music);
        Order Delete(int Id);
    }
}
