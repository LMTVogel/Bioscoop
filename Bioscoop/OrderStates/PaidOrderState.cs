namespace Bioscoop.OrderStates;

public class PaidOrderState : IOrderState
{
    public void Submit(IOrder order)
    {
        throw new NotImplementedException();
    }

    public void Cancel(IOrder order)
    {
        throw new NotImplementedException();
    }

    public void Pay(IOrder order)
    {
        throw new NotImplementedException();
    }

    public void Edit(IOrder order) { throw new InvalidOperationException("Order has been paid. Editing is not possible."); }

    public void Complete(IOrder order)
    {
        throw new NotImplementedException();
    }

    public void Remind(IOrder order)
    {
        throw new NotImplementedException();
    }
}