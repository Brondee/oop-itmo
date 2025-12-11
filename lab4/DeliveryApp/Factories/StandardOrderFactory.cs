namespace DeliveryApp;

public class StandardOrderFactory : OrderFactory
{
  public override Order CreateOrder(OrderRequest request)
  {
    var order = new StandardOrder(request);

    order.State = new CreatedState(order);

    IPriceCalculator calculator = new StandardPriceCalculator();
    calculator = new TaxDecorator(calculator);
    calculator = new DeliveryFeeDecorator(calculator);

    order.PriceCalculator = calculator;

    return order;
  }
}