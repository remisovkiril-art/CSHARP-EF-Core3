using ShopPV521.Enums;
using ShopPV521.Services;

namespace ShopPV521.Managers
{
    public class ShopManager
    {
        private readonly ProductService _service;

        public ShopManager(ProductService service)
        {
            _service = service;
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("\n0 - Create category");
                Console.WriteLine("1 - Create product");
                Console.WriteLine("2 - Show products");
                Console.WriteLine("3 - Update price");
                Console.WriteLine("4 - Delete product");
                Console.WriteLine("5 - Exit");
                Console.Write("Select: ");

                var input = Console.ReadLine();
                if (!int.TryParse(input, out int actionInt)) continue;

                var action = (MenuAction)actionInt;

                switch (action)
                {
                    case 0:
                        CreateCategory();
                        break;
                    case MenuAction.CreateProduct:
                        CreateProduct();
                        break;
                    case MenuAction.ShowProducts:
                        ShowProducts();
                        break;
                    case MenuAction.UpdatePrice:
                        UpdatePrice();
                        break;
                    case MenuAction.DeleteProduct:
                        DeleteProduct();
                        break;
                    case MenuAction.Exit:
                        return;
                }
            }
        }

        private void CreateCategory()
        {
            Console.Write("Category Name: ");
            var name = Console.ReadLine();
            _service.CreateCategory(name);
            Console.WriteLine("Category created!");
        }

        private void CreateProduct()
        {
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Price: ");
            var price = decimal.Parse(Console.ReadLine());
            Console.Write("Stock: ");
            var stock = int.Parse(Console.ReadLine());

            var cats = _service.GetCategories();
            Console.WriteLine("Available Categories:");
            foreach (var c in cats) Console.WriteLine($"ID: {c.Id} - {c.Name}");

            Console.Write("Enter Category ID: ");
            var catId = int.Parse(Console.ReadLine());

            _service.CreateProduct(name, price, stock, catId);
            Console.WriteLine("Done!");
        }

        private void ShowProducts()
        {
            var products = _service.GetProducts();
            foreach (var p in products)
                Console.WriteLine($"{p.Id} {p.Name} {p.Price} Stock:{p.StockQuantity}");
        }

        private void UpdatePrice()
        {
            Console.Write("Product Id: ");
            var id = int.Parse(Console.ReadLine());
            Console.Write("New Price: ");
            var price = decimal.Parse(Console.ReadLine());
            _service.UpdatePrice(id, price);
        }

        private void DeleteProduct()
        {
            Console.Write("Product Id: ");
            var id = int.Parse(Console.ReadLine());
            _service.DeleteProduct(id);
        }
    }
}
