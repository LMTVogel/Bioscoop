namespace Bioscoop.OrderStates;

public class CreatedOrderState : IOrderState
{
    public void Submit(IOrder order)
    {
        order.SetState(new SubmittedOrderState(order));
    }

    public void Cancel(IOrder order)
    {
        order.SetState(new CancelledOrderState());
    }

    public void Pay(IOrder order) { throw new InvalidOperationException("Order must be submitted before payment."); }
    public void Edit(IOrder order)
    {
        throw new NotImplementedException();
    }

    public void Complete(IOrder order)
    {
        throw new NotImplementedException();
    }

    public void Remind(IOrder order)
    {
        throw new NotImplementedException();
    }
}