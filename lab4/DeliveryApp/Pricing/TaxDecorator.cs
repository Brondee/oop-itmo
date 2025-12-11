namespace DeliveryApp;

public class TaxDecorator : PriceCalculatorDecorator
{
  public TaxDecorator(IPriceCalculator calculator) : base(calculator)
  {
  }

  public override decimal CalculateTotal(Order order)
  {
    var baseTotal = calculator.CalculateTotal(order);
    return baseTotal * 1.05m;
  }
}