namespace ShopPV521.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int Role { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<Order> Orders { get; set; } = new();
    }
}