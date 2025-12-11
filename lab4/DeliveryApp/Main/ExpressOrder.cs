namespace DeliveryApp;

public class ExpressOrder : Order
{
  public ExpressOrder(OrderRequest request) : base(request)
  {
    Type = OrderType.Express;
  }
}