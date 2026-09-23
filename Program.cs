using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


var services = new ServiceCollection();
services.AddLogging(config =>
{
    config.AddConsole();
});

services.AddTransient<IOrderRepo,OrderRepo>();
services.AddTransient<IProductRepo, ProductRepo>();
services.AddTransient<UnitOfWork>();

var serviceProvider = services.BuildServiceProvider();
var unitOfWork = serviceProvider.GetRequiredService<UnitOfWork>();


Products product = new Products
{
    Id = 1,
    Name = "Test",
    Stock = 10
};
Orders orders = new Orders
{
    Id = 1,
    ProductName = product.Name,
};
unitOfWork._orders.add(orders);
unitOfWork._products.add(product);
unitOfWork._products.ReduceStock(product);
unitOfWork.SaveChanges();








