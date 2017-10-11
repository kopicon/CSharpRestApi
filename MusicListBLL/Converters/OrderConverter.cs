using MusicListBLL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;
using List.Entities;
namespace MusicListBLL.Converters
{
    class OrderConverter
    {
        internal Order Convert(OrderBO order)
        {
            if (order == null) { return null; }
            return new Order()
            {
                Id = order.Id,
                DeliveryDate = order.DeliveryDate,
                OrderDate = order.OrderDate,
                Music = new MusicConverter().Convert(order.Music),
                MusicId = order.MusicId
            };
        }

        internal OrderBO Convert(Order order)
        {
            if (order == null) { return null; }
            return new OrderBO()
            {
                Id = order.Id,
                DeliveryDate = order.DeliveryDate,
                OrderDate = order.OrderDate,
                Music = new MusicConverter().Convert(order.Music),
                MusicId = order.MusicId
            };
        }
    }
}
    

    


