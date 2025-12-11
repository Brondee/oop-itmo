namespace DeliveryApp;

public class ExpressOrderFactory : OrderFactory
{
  public override Order CreateOrder(OrderRequest request)
  {
    var order = new ExpressOrder(request);

    order.State = new CreatedState(order);

    IPriceCalculator calculator = new ExpressPriceCalculator();
    calculator = new TaxDecorator(calculator);
    calculator = new DeliveryFeeDecorator(calculator);

    order.PriceCalculator = calculator;

    return order;
  }
}