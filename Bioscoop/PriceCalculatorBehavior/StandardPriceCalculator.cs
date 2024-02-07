using Bioscoop;
using Bioscoop.PriceCalculatorBehavior;

public class StandardPriceCalculator : IPriceCalculator
{
    public decimal CalculatePrice(List<MovieTicket> movieTickets)
    {
        decimal price = Decimal.Zero;
        bool groupDiscount = movieTickets.Count >= 6; // Initialize the default for the group discount

        for (int i = 0; i < movieTickets.Count; i++)
        {
            var dayOfWeek = (int)movieTickets[i].MovieScreening.GetDateAndTime().DayOfWeek;
            bool isWeekday = dayOfWeek is <= 4 and > 0; // Checks whether the movie screening is on a weekday. It also checks for zero to avoid Sunday, because Sunday is 0 in the DayOfWeek enum

            if (isWeekday && i % 2 == 0)
            {
                price += CalculateTicketPrice(movieTickets[i]);
            }
            else
            {
                price += CalculateTicketPrice(movieTickets[i]);
            }
        }

        if (groupDiscount) price *= 0.9M; // Apply a 10% discount if the order contains 6 or more tickets, is a weekend order and is not a student order

        // Return the total price of the order
        return price;
    }
    
    private static decimal CalculateTicketPrice(MovieTicket ticket)
    {
        double premiumPriceAdjustment = 3;
        // Checks if the ticket is a premium ticket and adds the premium price adjustment if it is
        return (decimal)(ticket.IsPremiumTicket() ? ticket.GetPrice() + premiumPriceAdjustment : ticket.GetPrice());
    }
}