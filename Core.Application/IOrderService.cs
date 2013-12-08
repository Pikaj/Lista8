using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Domain.Model.Shop;

namespace Core.Application
{
    public interface IOrderService
    {
        Order CreateNewOrder(int CustomerId, DateTime date, OrderAddress OrderAddress, List<ElementOrder> ElementsOrder);
        ElementOrder CreateNewElementOrder(int quantity, int OrderID, Product Product);

        List<Order> FindAllOrders(int CustomerId);
        List<ElementOrder> FindAllElementOrders(int OrderId);
    }
}
