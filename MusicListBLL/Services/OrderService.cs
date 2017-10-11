using MusicListBLL.BusinessObjects;
using MusicListBLL.Converters;
using List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicListBLL.Services
{
    class OrderService : IOrderService
    {
        private DALFacade _facade;
        OrderConverter conv = new OrderConverter();
        public OrderService(DALFacade facade)
        {
            _facade = facade;
        }
        public OrderBO Add(OrderBO order)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var orderEntity = uow.OrderRepository.Add(conv.Convert(order));
                uow.Complete();
                return conv.Convert(orderEntity);
            }
        }

        public OrderBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var orderEntity = uow.OrderRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(orderEntity);
            }
        }

        public OrderBO Edit(OrderBO order)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var orderEntity = uow.OrderRepository.Get(order.Id);
                if (orderEntity == null)
                {
                    throw new InvalidOperationException("Order not Found");
                }
                orderEntity.DeliveryDate = order.DeliveryDate;
                orderEntity.OrderDate = order.OrderDate;
                orderEntity.MusicId = order.MusicId;
                uow.Complete();

                orderEntity.Music = uow.MusicRepository.GetMusic(orderEntity.MusicId);
                return conv.Convert(orderEntity);
            }
        }

        public List<OrderBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.OrderRepository.GetAll().Select(conv.Convert).ToList();
            }
        }

        public OrderBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var orderEntity = uow.OrderRepository.Get(Id);
                orderEntity.Music = uow.MusicRepository.GetMusic(orderEntity.MusicId);
                return conv.Convert(orderEntity);
            }
        }
    }
}
