namespace Bioscoop.PriceCalculatorBehavior;

public class StudentPriceCalculator : IPriceCalculator
{
    public decimal CalculatePrice(List<MovieTicket> movieTickets)
    {
        decimal price = Decimal.Zero;
        double premiumPriceAdjustment = 2;
        
        for (int i = 0; i < movieTickets.Count; i++)
        {
            if (i % 2 == 0)
            {
                // Checks if the ticket is a premium ticket and adds the premium price adjustment if it is
                price += (decimal)(movieTickets[i].IsPremiumTicket() ? movieTickets[i].GetPrice() + premiumPriceAdjustment : movieTickets[i].GetPrice());
            }
        }
        
        return price;
    }
}