namespace DeliveryApp;

public class OrderRequest
{
  public string CustomerName { get; }
  public string Address { get; }
  public bool IsExpress { get; }
  public List<OrderItem> Items { get; }

  public OrderRequest(string customerName, string address, bool isExpress, List<OrderItem> items)
  {
    CustomerName = customerName;
    Address = address;
    IsExpress = isExpress;
    Items = items;
  }
}