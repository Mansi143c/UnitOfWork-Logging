using Microsoft.Extensions.Logging;
public class ProductRepo : IProductRepo
{
    public readonly ILogger<ProductRepo> _logger;
    private List<Products> _products = new List<Products>();
    public ProductRepo(ILogger<ProductRepo> logger)
    {
        _logger = logger;
    }
    public void add(Products p)
    {
        _products.Add(p);
        Console.WriteLine("Products added");
        _logger.LogInformation("Product {Id} added", p.Id);

    }
    public void ReduceStock(Products product)
    {
        product.Stock = product.Stock - 1;
        Console.WriteLine("Stock reduced to " + product.Stock);
        _logger.LogInformation("Remaining items " +  product.Stock);

    }
}