using Microsoft.EntityFrameworkCore;
using ShopPV521.Context;
using ShopPV521.Entities;

namespace ShopPV521.Services
{
    public class OrderService
    {
        private readonly ShopDbContext _db;

        public OrderService(ShopDbContext db)
        {
            _db = db;
        }

        public void CreateOrder(int userId, List<(int productId, int quantity)> items)
        {
            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                Status = "New",
                Items = new List<OrderItem>()
            };

            decimal total = 0;

            foreach (var item in items)
            {
                var product = _db.Products.FirstOrDefault(p => p.Id == item.productId);

                if (product == null)
                    continue;

                var orderItem = new OrderItem
                {
                    ProductId = product.Id,
                    Quantity = item.quantity,
                    Price = product.Price
                };

                total += product.Price * item.quantity;

                order.Items.Add(orderItem);
            }

            order.TotalAmount = total;

            _db.Orders.Add(order);
            _db.SaveChanges();
        }
    }
}