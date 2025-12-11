namespace DeliveryApp;

public class ExpressPriceCalculator : IPriceCalculator
{
  public decimal CalculateTotal(Order order)
  {
    decimal sum = 0;
    foreach (var item in order.Items)
    {
      sum += item.GetSubtotal();
    }

    return sum * 1.1m;
  }
}