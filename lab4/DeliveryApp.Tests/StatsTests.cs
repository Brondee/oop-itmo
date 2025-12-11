using DeliveryApp;
using Xunit;

public class StateTests
{
  [Fact]
  public void StatesChangesInCorrectOrder()
  {
    var item = new MenuItem(1, "Test", 100m);
    var request = new OrderRequestBuilder()
        .SetCustomer("Test")
        .SetAddress("Street 1")
        .AddItem(item, 1)
        .Build();

    var order = new StandardOrder(request);
    order.State = new CreatedState(order);

    order.State.StartPreparing();
    Assert.IsType<PreparingState>(order.State);

    order.State.StartDelivery();
    Assert.IsType<DeliveringState>(order.State);

    order.State.Complete();
    Assert.IsType<CompletedState>(order.State);
  }
}