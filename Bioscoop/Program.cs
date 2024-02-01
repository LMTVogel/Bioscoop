// See https://aka.ms/new-console-template for more information

using Bioscoop;

class Program
{
    static void Main(string[] args)
    {
        Movie movie = new Movie("The Matrix");
        MovieScreening movieScreening = new MovieScreening(movie, new System.DateTime(2024, 2, 2, 20, 0, 0), 10);
        MovieTicket movieTicket1 = new MovieTicket(movieScreening, 1, 1, false);
        MovieTicket movieTicket2 = new MovieTicket(movieScreening, 1, 2, false);
        MovieTicket movieTicket3 = new MovieTicket(movieScreening, 1, 3, false);
        MovieTicket movieTicket4 = new MovieTicket(movieScreening, 1, 4, false);
        MovieTicket movieTicket5 = new MovieTicket(movieScreening, 1, 5, false);
        MovieTicket movieTicket6 = new MovieTicket(movieScreening, 1, 6, true);
        Order order = new Order(1, false);
        
        order.AddSeatReservation(movieTicket1);
        order.AddSeatReservation(movieTicket2);
        order.AddSeatReservation(movieTicket3);
        order.AddSeatReservation(movieTicket4);
        order.AddSeatReservation(movieTicket5);
        order.AddSeatReservation(movieTicket6);
        
        System.Console.WriteLine(order.CalculatePrice());
        // order.Export(TicketExportFormat.JSON);
    }
}