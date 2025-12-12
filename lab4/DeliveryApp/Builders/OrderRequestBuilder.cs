namespace DeliveryApp;

public class OrderRequestBuilder
{
  private string _customerName = "";
  private string _address = "";
  private bool _isExpress = false;
  private List<OrderItem> _items = new();

  public OrderRequestBuilder SetCustomer(string name)
  {
    _customerName = name;
    return this;
  }

  public OrderRequestBuilder SetAddress(string address)
  {
    _address = address;
    return this;
  }

  public OrderRequestBuilder SetIsExpress()
  {
    _isExpress = true;
    return this;
  }

  public OrderRequestBuilder AddItem(MenuItem item, int quantity)
  {
    _items.Add(new OrderItem(item, quantity));
    return this;
  }

  public OrderRequest Build()
  {
    return new OrderRequest(_customerName, _address, _isExpress, _items);
  }
}