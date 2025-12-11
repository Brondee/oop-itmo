using DeliveryApp;
using Xunit;

public class PricingTests
{
  [Fact]
  public void AddTaxAndDeliveryFee()
  {
    var item = new MenuItem(1, "Test", 100m);
    var request = new OrderRequestBuilder()
        .SetCustomer("Test")
        .SetAddress("Street 1")
        .AddItem(item, 1)
        .Build();

    var order = new StandardOrder(request);

    IPriceCalculator calc = new StandardPriceCalculator();
    calc = new TaxDecorator(calc);
    calc = new DeliveryFeeDecorator(calc);

    order.PriceCalculator = calc;

    var total = order.GetTotalPrice();

    Assert.Equal(305m, total);
  }
}