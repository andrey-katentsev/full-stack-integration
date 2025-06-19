using shared;

public class Data
{
public static List<Product> LoadProducts()
{
	return new List<Product>
	{
		new Product { Id = 1, Name = "Laptop", Price = 1199.95, Stock = 25, Category = new Category { Id = 101, Name = "Electronics" } },
		new Product { Id = 2, Name = "Headphones", Price = 49.95, Stock = 100, Category = new Category { Id = 102, Name = "Accessories" } }
	};
}
}