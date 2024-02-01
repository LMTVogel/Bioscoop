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
        this._movieTickets.Add(movieTicket);
    }

    public double CalculatePrice()
    {
        bool groupDiscount = false;
        double price = 0.0; // Initialize the total price to 0.0

        // Check if this order is placed by a student
        if (this._isStudentOrder)
        {
            // Loop through all the movie tickets in the order
            for (int i = 0; i < _movieTickets.Count; i++)
            {
                // Check if the current ticket is at an even index (1st, 3rd, 5th, etc.)
                if (i % 2 == 0)
                {
                    // If the ticket is a premium ticket, add the premium price (ticket price + 2)
                    // Otherwise, just add the standard ticket price
                    price += (_movieTickets[i].IsPremiumTicket() ? _movieTickets[i].GetPrice() + 2 : _movieTickets[i].GetPrice());
                }
            }
        }
        else // If the order is not placed by a student
        {
            // Loop through all the movie tickets
            for (int i = 0; i < _movieTickets.Count; i++)
            {
                // Check if the screening date is from Monday to Thursday (days 1 to 4)
                if ((int)_movieTickets[i].MovieScreening.GetDateAndTime().DayOfWeek <= 4)
                {
                    // Check if the current ticket is at an uneven index (1st, 3rd, 5th, etc.)
                    if (i % 2 == 0)
                    {
                        // If the ticket is a premium ticket, add the premium price (ticket price + 3)
                        // Otherwise, just add the standard ticket price
                        price += (_movieTickets[i].IsPremiumTicket() ? _movieTickets[i].GetPrice() + 3 : _movieTickets[i].GetPrice());
                    }
                }
                else
                {
                    // Apply a discount if there are 6 or more tickets in the order
                    if (_movieTickets.Count >= 6)
                    {
                        groupDiscount = true;
                    }
                    price += (_movieTickets[i].IsPremiumTicket() ? _movieTickets[i].GetPrice() + 3 : _movieTickets[i].GetPrice());
                }
            }
        }

        if (groupDiscount && !_isStudentOrder)
        {
            price *= 0.9;
        }

        // Return the total price of the order
        return price;
    }

    public void Export(TicketExportFormat exportFormat)
    {
        // Windows
        // string pathName = @"C:\export.txt";
        // macOS
        string pathName = @"/Users/luukvogel/Desktop/export.txt"; 

        File.Create(pathName).Close();

        using (StreamWriter writer = new StreamWriter(pathName))
        {
            writer.WriteLine($"Total price: {CalculatePrice()}");

            foreach (var movieTicket in _movieTickets)
            {
                writer.WriteLine($"{movieTicket.MovieScreening.Movie.ToString()}");
            }
        }
    }
}