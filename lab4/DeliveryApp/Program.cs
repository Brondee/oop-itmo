namespace DeliveryApp;

public static class Program
{
  public static void Main(string[] args)
  {
    var burger = new MenuItem(1, "Burger", 300m);
    var fries = new MenuItem(2, "Fries", 150m);

    var request = new OrderRequestBuilder()
        .SetCustomer("Иван")
        .SetAddress("Невский проспект, 1")
        .AddItem(burger, 2)
        .AddItem(fries, 1)
        .SetIsExpress()
        .Build();

    OrderFactory factory = request.IsExpress
        ? new ExpressOrderFactory()
        : new StandardOrderFactory();

    var order = factory.CreateOrder(request);

    order.State.StartPreparing();
    order.State.StartDelivery();
    order.State.Complete();

    var total = order.GetTotalPrice();

    Console.WriteLine($"Заказ #{order.Id}, Статус: {order.State.GetType().Name}, Всего: {total} ₽");
  }
}
