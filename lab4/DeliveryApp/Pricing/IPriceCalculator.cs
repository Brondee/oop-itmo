namespace DeliveryApp;

public interface IPriceCalculator
{
  decimal CalculateTotal(Order order);
}