public class ProductRepo : IProductRepo
{
    private List<Products> _products = new List<Products>();
    public void add(Products p)
    {
        _products.Add(p);
        Console.WriteLine("Products added");
    }
    public void ReduceStock(Products product)
    {
        product.Stock = product.Stock - 1;
        Console.WriteLine("Stock reduced to " + product.Stock);
    }
}