namespace DeliveryApp;

public class DeliveringState : OrderState
{
  public DeliveringState(Order order) : base(order) { }

  public override void StartPreparing()
  {
    throw new InvalidOperationException("Заказ уже готовится");
  }

  public override void StartDelivery()
  {
    throw new InvalidOperationException("Заказ уже в доставке");
  }

  public override void Complete()
  {
    _order.State = new CompletedState(_order);
  }

  public override void Cancel()
  {
    _order.State = new CancelledState(_order);
  }
}