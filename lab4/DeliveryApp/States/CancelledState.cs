namespace DeliveryApp;

public class CancelledState : OrderState
{
  public CancelledState(Order order) : base(order) { }

  public override void StartPreparing() { }

  public override void StartDelivery() { }

  public override void Complete() { }

  public override void Cancel() { }
}