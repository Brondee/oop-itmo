namespace DeliveryApp;

public abstract class PriceCalculatorDecorator : IPriceCalculator
{
  public IPriceCalculator calculator;

  public PriceCalculatorDecorator(IPriceCalculator calculator)
  {
    this.calculator = calculator;
  }

  public abstract decimal CalculateTotal(Order order);
}