using Bioscoop.Observable;

namespace Bioscoop.OrderStates;

public class ProvisionalOrderState : IOrderState
{

    private IOrder _order;
    private IObservable _observable;

    public ProvisionalOrderState(IOrder order, IObservable observable)
    {
        _order = order;
        _observable = observable;
        observable.Notify("Order is provisional");
        IEnumerable<MovieTicket> movieTickets = _order.GetMovieTickets();
        
        if (movieTickets.Any(ticket => ticket.MovieScreening.GetDateAndTime() - DateTime.Now < TimeSpan.FromHours(12)))
        {
            this.Cancel();
        }
    }
    public void Submit()
    {
        throw new NotImplementedException();
    }

    public void Cancel()
    {
        _order.SetState(new CancelledOrderState(_order, _observable));
        Console.WriteLine("Order is cancelled.");
    }

    public void Pay()
    {
        _order.SetState(new PaidOrderState(_order, _observable));
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