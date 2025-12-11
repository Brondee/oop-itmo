namespace DeliveryApp;

public class CreatedState : OrderState
{
  public CreatedState(Order order) : base(order) { }

  public override void StartPreparing()
  {
    _order.State = new PreparingState(_order);
  }

  public override void StartDelivery()
  {
    throw new InvalidOperationException("Нельзя передать в доставку сразу");
  }

  public override void Complete()
  {
    throw new InvalidOperationException("Нельзя завершить сразу");
  }

  public override void Cancel()
  {
    _order.State = new CancelledState(_order);
  }
}