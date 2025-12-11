using DeliveryApp;
using Xunit;

public class OrderFactoryTests
{
  [Fact]
  public void CreatesStandardOrder()
  {
    var item = new MenuItem(1, "Test", 100m);

    var request = new OrderRequestBuilder()
        .SetCustomer("Test")
        .SetAddress("Street 1")
        .AddItem(item, 1)
        .Build();

    var factory = new StandardOrderFactory();

    var order = factory.CreateOrder(request);

    Assert.NotNull(order.PriceCalculator);
  }
}