namespace DeliveryApp;

public abstract class Order
{
  private static int _nextId = 1;

  public int Id { get; }
  public OrderType Type { get; protected set; }
  public string CustomerName { get; private set; }
  public string Address { get; private set; }
  public List<OrderItem> Items { get; private set; }

  public OrderState State { get; set; } = null!;

  public IPriceCalculator PriceCalculator { get; set; } = null!;

  public Order(OrderRequest request)
  {
    Id = _nextId++;
    CustomerName = request.CustomerName;
    Address = request.Address;
    Items = request.Items;
  }

  public decimal GetTotalPrice()
  {
    if (PriceCalculator == null)
    {
      throw new InvalidOperationException("Калькулятор цены не настроен");
    }

    return PriceCalculator.CalculateTotal(this);
  }
}
