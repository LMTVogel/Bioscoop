namespace Bioscoop.OrderStates;

public class ProvisionalOrderState : IOrderState
{
    public ProvisionalOrderState(IOrder order)
    {
        IEnumerable<MovieTicket> movieTickets = order.GetMovieTickets();
        
        if (movieTickets.Any(ticket => ticket.MovieScreening.GetDateAndTime() - DateTime.Now < TimeSpan.FromHours(12)))
        {
            this.Cancel(order);
        }
    }
    public void Submit(IOrder order)
    {
        throw new NotImplementedException();
    }

    public void Cancel(IOrder order)
    {
        order.SetState(new CancelledOrderState());
        Console.WriteLine("Order is cancelled.");
    }

    public void Pay(IOrder order)
    {
        order.SetState(new PaidOrderState());
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