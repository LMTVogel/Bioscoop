namespace Bioscoop;

public class Order
{
    private int _orderNr;
    private bool _isStudentOrder;
    private List<MovieTicket> _movieTickets;

    public Order(int orderNr, bool isStudentOrder)
    {
        this._orderNr = orderNr;
        this._isStudentOrder = isStudentOrder;
        this._movieTickets = new List<MovieTicket>();
    }

    public int GetOrderNr()
    {
        return this._orderNr;
    }
    
    public void AddSeatReservation(MovieTicket movieTicket)
    {
        
    }

    public double CalculatePrice()
    {
        double price = 0.0;

        for (int i = 0; i < _movieTickets.Count; i++)
        {
            if (i % 2 == 0)
            {
                price += _movieTickets[i].GetPrice();
            }
        }
        
        return price;
    }

    public void Export(TicketExportFormat exportFormat)
    {
        
    }
}