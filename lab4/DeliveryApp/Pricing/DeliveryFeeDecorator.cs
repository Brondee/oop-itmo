namespace DeliveryApp;

public class DeliveryFeeDecorator : PriceCalculatorDecorator
{
  public DeliveryFeeDecorator(IPriceCalculator calculator) : base(calculator)
  {
  }

  public override decimal CalculateTotal(Order order)
  {
    var baseTotal = calculator.CalculateTotal(order);
    return baseTotal + 200m;
  }
}