namespace ShopPV521.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; }

        public User User { get; set; }

        public List<OrderItem> Items { get; set; } = new();
    }
}