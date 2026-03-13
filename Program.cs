using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopPV521.Context;
using ShopPV521.Repositories;
using ShopPV521.Services;
using ShopPV521.Managers;
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();
var connectionString = configuration.GetConnectionString("MSSQLConnection");
var options = new DbContextOptionsBuilder<ShopDbContext>()
    .UseSqlServer(connectionString)
    .Options;
var db = new ShopDbContext(options);
var repo = new ProductRepository(db);
var service = new ProductService(repo);
var manager = new ShopManager(service);
manager.Start();
// Test CreateOrder
// var orderService = new OrderService(db);
// orderService.CreateOrder(
//     1,
//     new List<(int,int)>
//     {
//         (1,2),
//         (2,1)
//     }
// );