namespace DeliveryApp;

public class StandardOrder : Order
{
  public StandardOrder(OrderRequest request) : base(request)
  {
    Type = OrderType.Standard;
  }
}