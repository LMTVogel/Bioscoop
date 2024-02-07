namespace Bioscoop.PriceCalculatorBehavior;

public interface IPriceCalculator
{
    decimal CalculatePrice(List<MovieTicket> movieTickets);
}