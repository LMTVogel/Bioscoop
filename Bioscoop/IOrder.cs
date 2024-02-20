using Bioscoop.OrderStates;

namespace Bioscoop;

public interface IOrder
{
    int GetOrderNr();
    void AddSeatReservation(MovieTicket movieTicket);
    decimal CalculatePrice();
    void Export(TicketExportFormat exportFormat);
    IEnumerable<MovieTicket> GetMovieTickets();
    void SetState(IOrderState state);
}