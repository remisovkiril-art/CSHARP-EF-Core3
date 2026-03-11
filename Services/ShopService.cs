using ShopPV521.Context;

namespace ShopPV521.Services
{
    public class ShopService
    {
        private readonly ShopDbContext _db;

        public ShopService(ShopDbContext db)
        {
            _db = db;
        }

        public void ShowProducts()
        {
            var products = _db.Products.ToList();

            foreach (var p in products)
            {
                Console.WriteLine($"{p.Id} {p.Name} {p.Price}");
            }
        }
    }
}
