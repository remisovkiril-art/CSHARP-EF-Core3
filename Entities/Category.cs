namespace ShopPV521.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<Product> Products { get; set; } = new();
    }
}