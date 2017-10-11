using System;
using System.Collections.Generic;
using System.Text;
using List.Entities;
using List.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace List.Repositories
{
    class OrderRipository : IOrderRepository
    {
        MusicAppContext _context;
        public OrderRipository(MusicAppContext context)
        {
            _context = context;
        }
        public Order Add(Order order)
        {
            _context.Orders.Add(order);
            return order;
        }

        public Order Delete(int Id)
        {
            var order = Get(Id);
            _context.Orders.Remove(order);
            return order;
        }

        public List<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public Order Get(int Id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == Id);
        }
    }
}
