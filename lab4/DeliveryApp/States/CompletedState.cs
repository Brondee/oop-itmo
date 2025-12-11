namespace DeliveryApp;

public class CompletedState : OrderState
{
  public CompletedState(Order order) : base(order) { }

  public override void StartPreparing() { }

  public override void StartDelivery() { }

  public override void Complete() { }

  public override void Cancel() { }
}