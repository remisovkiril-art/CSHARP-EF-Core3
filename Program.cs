using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopPV521.Context;
using ShopPV521.Services;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var connectionString = configuration.GetConnectionString("MSSQLConnection");

var options = new DbContextOptionsBuilder<ShopDbContext>()
    .UseSqlServer(connectionString)
    .Options;

var db = new ShopDbContext(options);

Console.WriteLine("Shop database ready.");

var service = new OrderService(db);

service.CreateOrder(
    1,
    new List<(int, int)>
    {
        (1,2),
        (2,1)
    }
);

Console.WriteLine("Test order created.");