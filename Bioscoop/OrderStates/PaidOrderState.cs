using Bioscoop.Observable;

namespace Bioscoop.OrderStates;

public class PaidOrderState : IOrderState
{
    private IOrder _order;
    private IObservable _observable;

    public PaidOrderState(IOrder order, IObservable observable)
    {
        _order = order;
        _observable = observable;
        observable.Notify("Order is paid");
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

    public void Edit() { throw new InvalidOperationException("Order has been paid. Editing is not possible."); }

    public void Complete()
    {
        throw new NotImplementedException();
    }

    public void Remind()
    {
        throw new NotImplementedException();
    }
}