using Bioscoop.Observable;

namespace Bioscoop.OrderStates;

public class CancelledOrderState : IOrderState
{
    private IOrder _order;
    private IObservable _observable;

    public CancelledOrderState(IOrder order, IObservable observable)
    {
        _order = order;
        _observable = observable;
        _observable.Notify("Order is cancelled");
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