namespace Bioscoop;

public class Order
{
    private int orderNr;
    private bool isStudentOrder;

    public Order(int orderNr, bool isStudentOrder)
    {
        this.orderNr = orderNr;
        this.isStudentOrder = isStudentOrder;
    }

    public int getOrderNr()
    {
        return this.orderNr;
    }
    
    public void addSeatReservation(MovieTicket movieTicket)
    {
        
    }

    public double calculatePrice()
    {
        return 0.1;
    }

    public void export(TicketExportFormat exportFormat)
    {
        
    }
}