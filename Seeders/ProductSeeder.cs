using ShopPV521.Context;
using ShopPV521.Entities;

namespace ShopPV521.Seeders
{
    public class ProductSeeder
    {
        private readonly ShopDbContext _db;

        public ProductSeeder(ShopDbContext db)
        {
            _db = db;
        }

        public void GenerateProducts(int count)
        {
            var rnd = new Random();

            var category = _db.Categories.FirstOrDefault();

            if (category == null)
            {
                category = new Category
                {
                    Name = "Default",
                    CreatedAt = DateTime.Now
                };

                _db.Categories.Add(category);
                _db.SaveChanges();
            }

            var products = new List<Product>();

            for (int i = 0; i < count; i++)
            {
                products.Add(new Product
                {
                    Name = "Product_" + i,
                    Price = rnd.Next(10, 1000),
                    StockQuantity = rnd.Next(1, 100),
                    CategoryId = category.Id,
                    CreatedAt = DateTime.Now
                });
            }

            _db.Products.AddRange(products);
            _db.SaveChanges();

            Console.WriteLine($"Inserted {count} products");
        }
    }
}