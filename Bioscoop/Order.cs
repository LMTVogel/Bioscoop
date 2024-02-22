using System.Text.Json;
using Bioscoop.Observable;
using Bioscoop.OrderStates;
using Bioscoop.subscribers;

namespace Bioscoop;

public class Order : IOrder
{
    private int _orderNr;
    private bool _isStudentOrder;
    private List<MovieTicket> _movieTickets;
    public IOrderState CurrentState { get; set; }
    private IObservable _observable;

    public Order(int orderNr, bool isStudentOrder)
    {
        this._orderNr = orderNr;
        this._isStudentOrder = isStudentOrder;
        this._movieTickets = new List<MovieTicket>();
        _observable = new Observable.Observable();
        this.CurrentState = new CreatedOrderState(this, _observable);
    }
    
    public void SetState(IOrderState state)
    {
        this.CurrentState = state;
    }

    public void Submit() => CurrentState.Submit();
    public void Cancel() => CurrentState.Cancel();
    public void Pay() => CurrentState.Pay();
    public void Remind() => CurrentState.Remind();
    public void Complete() => CurrentState.Complete();
    public void Edit() => CurrentState.Edit();

    public int GetOrderNr()
    {
        return this._orderNr;
    }
    
    public IEnumerable<MovieTicket> GetMovieTickets()
    {
        return this._movieTickets;
    }

    public void AddSeatReservation(MovieTicket movieTicket)
    {
        this._movieTickets.Add(movieTicket);
    }

    public decimal CalculatePrice()
    {
        decimal price = Decimal.Zero;
        bool groupDiscount = false; // Initialize the default for the group discount
        double premiumPriceAdjustment = _isStudentOrder ? 2 : 3; // Checks whether the order is a student order and sets the premium price adjustment accordingly

        for (int i = 0; i < _movieTickets.Count; i++)
        {
            var dayOfWeek = (int)_movieTickets[i].MovieScreening.GetDateAndTime().DayOfWeek;
            bool isWeekday = dayOfWeek is <= 4 and > 0; // Checks whether the movie screening is on a weekday. It also checks for zero to avoid Sunday, because Sunday is 0 in the DayOfWeek enum
            if (isWeekday || _isStudentOrder)
            {
                // Checks if every second ticket is free
                if ((i + 1) % 2 == 0)
                {
                    // Checks if the ticket is a premium ticket and adds the premium price adjustment if it is
                    price += (decimal)(_movieTickets[i].IsPremiumTicket() ? _movieTickets[i].GetPrice() + premiumPriceAdjustment : _movieTickets[i].GetPrice());
                }
            }
            else
            {
                // Checks if the order contains 6 or more tickets
                groupDiscount = _movieTickets.Count >= 6;
                // Checks if the ticket is a premium ticket and adds the premium price adjustment if it is
                price += (decimal)(_movieTickets[i].IsPremiumTicket() ? _movieTickets[i].GetPrice() + premiumPriceAdjustment : _movieTickets[i].GetPrice());

            }
        }

        if (groupDiscount) price *= 0.9M; // Apply a 10% discount if the order contains 6 or more tickets, is a weekend order and is not a student order

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

    public void Subscribe(ISubscriber subscriber)
    {
        _observable.Subscribe(subscriber);
    }
}