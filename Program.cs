UnitOfWork unitOfWork = new UnitOfWork();
Product product = new Product
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
unitOfWork.Orders.Add(orders);
unitOfWork.Products.Add(product);
unitOfWork.Products.ReduceStock(product);
unitOfWork.SaveChanges();
class Orders
{
    public int Id { get; set; }
    public string ProductName { get; set; }
}

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
}

class OrderRepo
{
    private List<Orders> _orders = new List<Orders>();
    public void Add(Orders o)
    {
        _orders.Add(o);
        Console.WriteLine("Order added");
    }
}

class ProductRepo
{
    private List<Product> _orders = new List<Product>();
    public void Add(Product p)
    {
        _orders.Add(p);
        Console.WriteLine("Products added");
    }
    public void ReduceStock(Product product)
    {
        product.Stock = product.Stock - 1;
        Console.WriteLine("Stock reduced to "+ product.Stock);
    }
}

class UnitOfWork
{
    public OrderRepo Orders { get; }
    public ProductRepo Products { get; }

    public UnitOfWork()
    {
        Orders = new OrderRepo();
        Products = new ProductRepo();
    }
    public void SaveChanges()
    {
        Console.WriteLine("All changes saved!");
    }
}