using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopPV521.Context;

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
