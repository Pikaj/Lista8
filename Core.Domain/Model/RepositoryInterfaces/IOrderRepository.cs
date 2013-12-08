using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model.Shop
{
    public interface IOrderRepository
    {
        // Order
        void InsertOrder(int customerId, Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
        Order RetrieveOrder(int id);
        List<Order> RetrieveAllOrders(int customerId);

    }
}
