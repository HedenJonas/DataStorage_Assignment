namespace Business.Models;

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }
    public int Units { get; set; }
    public decimal Rate { get; set; }

}
