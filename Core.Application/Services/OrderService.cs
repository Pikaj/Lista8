using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.Shop;

namespace Core.Application
{
    public class OrderService : IOrderService
    {
        private IOrderRepository OrderRepository;

        public OrderService()
        {
           throw new NotImplementedException();
        }

        public OrderService(IOrderRepository OrderRepository)
        {
            this.OrderRepository = OrderRepository;
        }

        public Order CreateNewOrder(int CustomerId, DateTime date, OrderAddress OrderAddress, List<ElementOrder> ElementsOrder)
        {
            throw new NotImplementedException();
        }

        public ElementOrder CreateNewElementOrder(int quantity, int OrderID, Product Product)
        {
            throw new NotImplementedException();
        }


        public List<Order> FindAllOrders(int CustomerId)
        {
            return OrderRepository.RetrieveAllOrders(CustomerId);
        }

        public List<ElementOrder> FindAllElementOrders(int OrderId)
        {
            throw new NotImplementedException();
        }

    }
}
