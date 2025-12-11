namespace DeliveryApp;

public abstract class OrderFactory
{
  public abstract Order CreateOrder(OrderRequest request);
}