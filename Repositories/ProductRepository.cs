using Microsoft.EntityFrameworkCore;
using ShopPV521.Context;
using ShopPV521.Entities;

namespace ShopPV521.Repositories
{
    public class ProductRepository
    {
        private readonly ShopDbContext _db;

        public ProductRepository(ShopDbContext db)
        {
            _db = db;
        }

        public void CreateProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public void CreateCategory(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
        }

        public List<Category> GetAllCategories()
        {
            return _db.Categories.AsNoTracking().ToList();
        }

        public List<Product> GetAllProducts()
        {
            return _db.Products
                .AsNoTracking()
                .ToList();
        }

        public Product FindByName(string name)
        {
            return _db.Products
                .FirstOrDefault(p => p.Name == name);
        }

        public void UpdatePrice(int id, decimal newPrice)
        {
            var product = _db.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return;

            product.Price = newPrice;
            _db.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = _db.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return;

            _db.Products.Remove(product);
            _db.SaveChanges();
        }
    }
}