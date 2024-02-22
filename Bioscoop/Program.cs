// See https://aka.ms/new-console-template for more information

using Bioscoop.Subscribers;

namespace Bioscoop;

class Program
{
    static void Main(string[] args)
    {
        Movie movie = new("The Matrix");
        MovieScreening movieScreening = new(movie, new DateTime(2024, 2, 21, 20, 0, 0), 10);
        MovieTicket movieTicket1 = new(movieScreening, 1, 1, true);
        MovieTicket movieTicket2 = new(movieScreening, 1, 2, false);
        MovieTicket movieTicket3 = new(movieScreening, 1, 3, false);
        MovieTicket movieTicket4 = new(movieScreening, 1, 4, false);
        MovieTicket movieTicket5 = new(movieScreening, 1, 5, true);
        MovieTicket movieTicket6 = new(movieScreening, 1, 6, false);
        Order order = new(1, true);

        order.Subscribe(new DiscordSubscriber());

        order.AddSeatReservation(movieTicket1);
        order.AddSeatReservation(movieTicket2);
        // order.AddSeatReservation(movieTicket3);
        // order.AddSeatReservation(movieTicket4);
        // order.AddSeatReservation(movieTicket5);
        // order.AddSeatReservation(movieTicket6);

        order.Submit();

    }
}