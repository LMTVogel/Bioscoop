namespace Bioscoop.OrderStates;

public class CompletedOrderState : IOrderState
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