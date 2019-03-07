using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerAppBLL.BusinessObjects;
using CustomerAppBLL.Converters;
using CustomerAppDAL;

namespace CustomerAppBLL.Services
{
    class OrderService : IOrderService
    {
        OrderConverter conv = new OrderConverter();
        private DALFacade _facade;

        public OrderService(DALFacade facade)
        {
            _facade = facade;
        }


        public OrderBO Create(OrderBO order)
        {
            using (var uow = _facade.UnitOfWork)  //enter the access to database
            {
                var orderEntity = uow.OrderRepository.Create(conv.Convert(order));   //create a order
                uow.Complete();   //save changes
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



        public OrderBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var orderEntity = uow.OrderRepository.Get(Id);
                orderEntity.Customer = uow.CustomerRepository.Get(orderEntity.CustomerId);    //get all customer information when getting a specific order
                return conv.Convert(uow.OrderRepository.Get(Id));               
            }
        }


        public List<OrderBO> GetAll()
        {
            //use of landa expression
            using (var uow = _facade.UnitOfWork)
            {
                return uow.OrderRepository.GetAll().Select(o => conv.Convert(o)).ToList();
                //SECOND WAY - return uow.OrderRepository.GetAll().Select(conv.Convert).ToList();
            }
        }


        public OrderBO Update(OrderBO order)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var orderEntity = uow.OrderRepository.Get(order.Id);
                if(orderEntity == null)
                {
                    throw new InvalidOperationException("Order not found!");
                }
                orderEntity.DeliveryDate = order.DeliveryDate;
                orderEntity.OrderDate = order.OrderDate;
                orderEntity.CustomerId = order.CustomerId;
                uow.Complete();
                orderEntity.Customer = uow.CustomerRepository.Get(orderEntity.CustomerId);  /*this makes possible that when you update one order,
                the customerID you updated will be also updated for the real customer and once you make the request, his data will be appeared*/
                return conv.Convert(orderEntity);
            }
        }
    }
}
