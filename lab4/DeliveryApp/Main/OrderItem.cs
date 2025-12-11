namespace DeliveryApp;

public class OrderItem
{
  public MenuItem Item { get; }
  public int Quantity { get; }

  public OrderItem(MenuItem item, int quantity)
  {
    Item = item;
    Quantity = quantity;
  }

  public decimal GetSubtotal()
  {
    return Item.Price * Quantity;
  }
}