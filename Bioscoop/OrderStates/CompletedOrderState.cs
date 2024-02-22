namespace Bioscoop.OrderStates;

public class CompletedOrderState : IOrderState
{
    private IOrder _order;

    public CompletedOrderState(IOrder order)
    {
        _order = order;
    }

    public void Submit()
    {
        throw new NotImplementedException();
    }

    public void Cancel()
    {
        throw new NotImplementedException();
    }

    public void Pay()
    {
        throw new NotImplementedException();
    }

    public void Edit()
    {
        throw new NotImplementedException();
    }

    public void Complete()
    {
        throw new NotImplementedException();
    }

    public void Remind()
    {
        throw new NotImplementedException();
    }
}