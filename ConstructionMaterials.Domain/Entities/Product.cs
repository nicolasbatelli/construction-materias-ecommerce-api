public class Product : IAggregateRoot
{ 
    public int? Id { get; private set; } 
    public string Name { get; private set; } 
    public decimal Price { get; private set; } 
    public Product(string name, decimal price, int? id = null) 
    { 
        Id = id;
        Name = name; 
        Price = price; 
    } 
}