using Bioscoop.Observable;

namespace Bioscoop.OrderStates;

public class SubmittedOrderState : IOrderState
{
    private IOrder _order;
    private IObservable _observable;

    public SubmittedOrderState(IOrder order, IObservable observable)
    {
        _order = order;
        _observable = observable;
        observable.Notify("Order is submitted");
        IEnumerable<MovieTicket> movieTickets = order.GetMovieTickets();
        
        if (movieTickets.Any(ticket => ticket.MovieScreening.GetDateAndTime() - DateTime.Now < TimeSpan.FromHours(24)))
        {
            this.Remind();
        }
    }
    
    public void Submit()
    {
        throw new NotImplementedException();
    }

    public void Cancel()
    {
        _order.SetState(new CancelledOrderState(_order, _observable));
    }

    public void Pay()
    {
        _order.SetState(new PaidOrderState(_order, _observable));
    }

    public void Edit()
    {
        Console.WriteLine("Order is edited.");
    }

    public void Complete()
    {
        throw new NotImplementedException();
    }

    public void Remind()
    {
        _order.SetState(new ProvisionalOrderState(_order, _observable));
        Console.WriteLine("Reminder: Your movie starts in 24 hours. You need to pay for your order.");
    }
}