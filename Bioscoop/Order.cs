using System.Text.Json;

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
        double price = 0.0; // Initialize the total price to 0.0
        bool groupDiscount = false; // Initialize the default for the group discount
        double preimiumPriceAdjustment = _isStudentOrder ? 2 : 3; // Checks whether the order is a student order and sets the premium price adjustment accordingly

        for (int i = 0; i < _movieTickets.Count; i++)
        {
            bool isWeekday = (int)_movieTickets[i].MovieScreening.GetDateAndTime().DayOfWeek <= 4; // Checks whether the movie screening is on a weekday
            if (isWeekday || _isStudentOrder)
            {
                // Checks if every second ticket is free
                if (i % 2 == 0)
                {
                    // Checks if the ticket is a premium ticket and adds the premium price adjustment if it is
                    price += (_movieTickets[i].IsPremiumTicket() ? _movieTickets[i].GetPrice() + preimiumPriceAdjustment : _movieTickets[i].GetPrice());
                }
            }
            else
            {
                // Checks if the order contains 6 or more tickets
                groupDiscount = _movieTickets.Count >= 6;
                // Checks if the ticket is a premium ticket and adds the premium price adjustment if it is
                price += (_movieTickets[i].IsPremiumTicket() ? _movieTickets[i].GetPrice() + preimiumPriceAdjustment : _movieTickets[i].GetPrice());

            }
        }

        if (groupDiscount) price *= 0.9; // Apply a 10% discount if the order contains 6 or more tickets, is a weekend order and is not a student order

        // Return the total price of the order
        return price;
    }

    public void Export(TicketExportFormat exportFormat)
    {
        string currentDirectory = Directory.GetCurrentDirectory();

        // Find the solution directory
        while (!File.Exists(Path.Combine(currentDirectory, "Bioscoop.sln")))
        {
            currentDirectory = Directory.GetParent(currentDirectory).FullName;
        }

        string pathName = $"{currentDirectory}/order_{GetOrderNr()}";


        switch (exportFormat)
        {
            case TicketExportFormat.PLAINTEXT:
                string txtPath = $"{pathName}.txt";
                File.Create(txtPath).Close();
                using (StreamWriter writer = new(txtPath))
                {
                    writer.WriteLine($"Order number: {GetOrderNr()}");
                    writer.WriteLine($"Total price: {CalculatePrice()}\n");
                    writer.WriteLine("Movies:");
                    foreach (var movieTicket in _movieTickets)
                    {
                        writer.WriteLine($"{movieTicket.MovieScreening.Movie}");
                        writer.WriteLine($"Date and time: {movieTicket.MovieScreening.GetDateAndTime()}");
                    }
                }
                break;

            case TicketExportFormat.JSON:
                string jsonPath = $"{pathName}.json";
                File.Create(jsonPath).Close();
                var data = new
                {
                    OrderNumber = GetOrderNr(),
                    TotalPrice = CalculatePrice(),
                    MovieTickets = _movieTickets.Select(ticket => new
                    {
                        Movie = ticket.MovieScreening.Movie.ToString(),
                        DateAndTime = ticket.MovieScreening.GetDateAndTime(),
                    })
                };

                string jsonData = JsonSerializer.Serialize(data);
                File.WriteAllText(jsonPath, jsonData);
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(exportFormat), exportFormat, null);
        }
    }
}