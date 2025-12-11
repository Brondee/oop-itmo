namespace DeliveryApp;

public class MenuItem
{
  public int Id { get; }
  public string Name { get; }
  public decimal Price { get; }

  public MenuItem(int id, string name, decimal price)
  {
    Id = id;
    Name = name;
    Price = price;
  }
}