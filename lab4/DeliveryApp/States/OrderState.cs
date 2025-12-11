namespace DeliveryApp;

public abstract class OrderState
{
    public readonly Order _order;

    public OrderState(Order order)
    {
        _order = order;
    }

    public abstract void StartPreparing();
    public abstract void StartDelivery();
    public abstract void Complete();
    public abstract void Cancel();
}