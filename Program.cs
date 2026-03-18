using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopPV521.Context;
using ShopPV521.Entities;
using ShopPV521.Managers;
using ShopPV521.Repositories;
using ShopPV521.Seeders;
using ShopPV521.Services;
using System.Diagnostics;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var connectionString = configuration.GetConnectionString("MSSQLConnection");

var options = new DbContextOptionsBuilder<ShopDbContext>()
    .UseSqlServer(connectionString)
    .Options;

var db = new ShopDbContext(options);

var seeder = new ProductSeeder(db);

Console.WriteLine("Testing search WITHOUT index...");

var stopwatch = Stopwatch.StartNew();

var product = db.Products
    .FirstOrDefault(p => p.Name == "Product_90000");

stopwatch.Stop();

Console.WriteLine($"Запрос выполнился за {stopwatch.ElapsedMilliseconds} ms");
//Без индекса. Inserted 100000 products
//Testing search WITHOUT index...
//Запрос выполнился за 601 ms
//C:\Users\Lenovo\source\repos\ShopApp\bin\Debug\net10.0\ShopApp.exe (process 2240) exited with code 0 (0x0).
//To automatically close the console when debugging stops, enable Tools->Options->Debugging->Automatically close the console when debugging stops.
//Press any key to close this window . . .

//С индексом. Testing search WITHOUT index...
//Запрос выполнился за 1040 ms
//C:\Users\Lenovo\source\repos\ShopApp\bin\Debug\net10.0\ShopApp.exe (process 16532) exited with code 0 (0x0).
//To automatically close the console when debugging stops, enable Tools->Options->Debugging->Automatically close the console when debugging stops.
//Press any key to close this window . . .