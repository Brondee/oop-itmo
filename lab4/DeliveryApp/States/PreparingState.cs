namespace DeliveryApp;

public class PreparingState : OrderState
{
  public PreparingState(Order order) : base(order) { }

  public override void StartPreparing()
  {
    throw new InvalidOperationException("Заказ уже готовится");
  }

  public override void StartDelivery()
  {
    _order.State = new DeliveringState(_order);
  }

  public override void Complete()
  {
    throw new InvalidOperationException("Нельзя завершить заказ сразу");
  }

  public override void Cancel()
  {
    _order.State = new CancelledState(_order);
  }
}