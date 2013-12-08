using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.Shop;

namespace Core.ObjectsMother
{
    public class ShopObjectMother
    {
        public string Phrase { get; set; }

        public Customer CreateShopCustomerWithOrders(string TestName)
        {
            Phrase = TestName;
            CustomerData cd = CreateCustomerData();
            Order o = CreateOrder();
            CustomerRabate r = CreateCustomerRabate();
            Customer c = new Customer { CustomerData = cd, Orders = new List<Order>(), Rabate = r };
            c.Orders.Add(o);
            o.Customer = c;
            r.Customers.Add(c);
            
            return c;
         }

         public Order CreateOrder()
         {
             OrderAddress oa = CreateOrderAddress();
             ElementOrder eo = CreateElementOrder();
             string date = DateTime.Now.AddDays(1).ToString("d");
             Order o = new Order { Date = date, OrderAddress = oa, ElementsOrder = new List<ElementOrder>() };
             o.ElementsOrder.Add(eo);
             eo.Order = o;

             return o;
         }

         public OrderAddress CreateOrderAddress()
         {
             return new OrderAddress { City = "City "+ Phrase, Number = "1", Street = "Street "+ Phrase, PostalCode = "00-000" };
         }

         public ElementOrder CreateElementOrder()
         {
             Product p = CreateProduct(0, 0.0f);
             return new ElementOrder {  Quantity = 1, Product = p};
         }

         public Product CreateProduct(int quantity, float price)
         {
             ProductData pd = CreateProductData(price);
             Category c = CreateCategory();
             Product p = new Product { Quantity = quantity, ProductData = pd, Category = c};
             c.Products.Add(p);
             return p;
         }

         public Category CreateCategory()
         {
             return new Category { Name = "Category " + Phrase, Products = new List<Product>() };
         }

         public ProductData CreateProductData(float price)
         {
             ProductDescription pd = CreateProductDescription();
               
             return new ProductData { Description = pd, Name = "Product "+ Phrase, Price = price};
         }

         public ProductDescription CreateProductDescription()
         {
             return new ProductDescription { Description = "About Product "+ Phrase };
         }

         public CustomerRabate CreateCustomerRabate()
         {
             return new CustomerRabate {Name = "Rabate"+ Phrase, Percent = 0.1f, Customers = new List<Customer>()};
         }

         public CustomerAddress CreateCustomerAddress()
         {
             return new CustomerAddress { City = "City "+ Phrase, Number = "1", Street = "Street "+ Phrase, PostalCode = "00-000" };
         }

         public CustomerData CreateCustomerData()
         {
             CustomerAddress ca = CreateCustomerAddress();
             return new CustomerData { Firstname = "Name "+ Phrase, Lastname = "Surname "+ Phrase, CustomerAddress = ca };
         }


    }
}
