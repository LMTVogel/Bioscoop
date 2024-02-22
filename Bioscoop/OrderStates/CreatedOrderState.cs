using Bioscoop.Observable;

namespace Bioscoop.OrderStates;

public class CreatedOrderState : IOrderState
{
    private IOrder _order;
    private IObservable _observable;

    public CreatedOrderState(IOrder order, IObservable observable)
    {
        _order = order;
        _observable = observable;
    }

    public void Submit()
    {
        _order.SetState(new SubmittedOrderState(_order, _observable));
    }

    public void Cancel()
    {
        _order.SetState(new CancelledOrderState(_order, _observable));
    }

    public void Pay() { throw new InvalidOperationException("Order must be submitted before payment."); }
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