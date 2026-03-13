using ShopPV521.Entities;
using ShopPV521.Repositories;
namespace ShopPV521.Services
{
    public class ProductService
    {
        private readonly ProductRepository _repo;

        public ProductService(ProductRepository repo)
        {
            _repo = repo;
        }
        public void CreateProduct(string name, decimal price, int stock, int categoryId)
        {
            var product = new Product
            {
                Name = name,
                Price = price,
                StockQuantity = stock,
                CategoryId = categoryId,
                CreatedAt = DateTime.Now
            };

            _repo.CreateProduct(product);
        }
        public void CreateCategory(string name)
        {
            var category = new Category { Name = name, CreatedAt = DateTime.Now };
            _repo.CreateCategory(category);
        }
        public List<Category> GetCategories()
        {
            return _repo.GetAllCategories();
        }
        public List<Product> GetProducts()
        {
            return _repo.GetAllProducts();
        }
        public void UpdatePrice(int id, decimal price)
        {
            _repo.UpdatePrice(id, price);
        }
        public void DeleteProduct(int id)
        {
            _repo.DeleteProduct(id);
        }
    }
}
