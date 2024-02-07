using System.Text.Json;
using Bioscoop.PriceCalculatorBehavior;

namespace Bioscoop;

public class Order
{
    private int _orderNr;
    private List<MovieTicket> _movieTickets;
    private IPriceCalculator _priceCalculator;

    public Order(int orderNr, IPriceCalculator priceCalculator)
    {
        this._orderNr = orderNr;
        this._movieTickets = new List<MovieTicket>();
        this._priceCalculator = priceCalculator;
    }

    public int GetOrderNr()
    {
        return this._orderNr;
    }

    public void AddSeatReservation(MovieTicket movieTicket)
    {
        this._movieTickets.Add(movieTicket);
    }

    public decimal CalculatePrice()
    {
        return _priceCalculator.CalculatePrice(_movieTickets);
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