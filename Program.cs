using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

//Logging in file
LoggingConfig.Configure();
var services = new ServiceCollection();
services.AddLogging(config =>
{
    config.AddSerilog(Log.Logger);
});
//////////////////////////For logging in console/////////////////////////
///
/*
services.AddLogging(config =>
{
    config.AddConsole();
});
*/
services.AddTransient<IOrderRepo,OrderRepo>();
services.AddTransient<IProductRepo, ProductRepo>();
services.AddTransient<UnitOfWork>();
services.AddTransient<IOrderService, OrderService>();

var serviceProvider = services.BuildServiceProvider();
var orderService = serviceProvider.GetRequiredService<IOrderService>();


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
orderService.placeOrder(product, orders);








