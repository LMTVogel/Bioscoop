namespace Bioscoop.OrderStates;

public class SubmittedOrderState : IOrderState
{
    public SubmittedOrderState(IOrder order)
    {
        IEnumerable<MovieTicket> movieTickets = order.GetMovieTickets();
        
        if (movieTickets.Any(ticket => ticket.MovieScreening.GetDateAndTime() - DateTime.Now < TimeSpan.FromHours(24)))
        {
            this.Remind(order);
        }
    }
    
    public void Submit(IOrder order)
    {
        throw new NotImplementedException();
    }

    public void Cancel(IOrder order)
    {
        order.SetState(new CancelledOrderState());
    }

    public void Pay(IOrder order)
    {
        order.SetState(new PaidOrderState());
    }

    public void Edit(IOrder order)
    {
        Console.WriteLine("Order is edited.");
    }

    public void Complete(IOrder order)
    {
        throw new NotImplementedException();
    }

    public void Remind(IOrder order)
    {
        order.SetState(new ProvisionalOrderState(order));
        Console.WriteLine("Reminder: Your movie starts in 24 hours. You need to pay for your order.");
    }
}