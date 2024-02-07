using System.Text.Json;
using Bioscoop.ExportOrderBehavior;
using Bioscoop.PriceCalculatorBehavior;

namespace Bioscoop;

public class Order
{
    private int _orderNr;
    private List<MovieTicket> _movieTickets;
    private IPriceCalculator _priceCalculator;
    private IExportOrder _exportOrder;

    public Order(int orderNr, IPriceCalculator priceCalculator, IExportOrder exportOrder)
    {
        this._orderNr = orderNr;
        this._movieTickets = new List<MovieTicket>();
        this._priceCalculator = priceCalculator;
        this._exportOrder = exportOrder;
    }

    public int GetOrderNr()
    {
        return this._orderNr;
    }

    public List<MovieTicket> GetMovieTickets()
    {
        return this._movieTickets;
    }
    
    public void AddSeatReservation(MovieTicket movieTicket)
    {
        this._movieTickets.Add(movieTicket);
    }

    public decimal CalculatePrice()
    {
        return _priceCalculator.CalculatePrice(_movieTickets);
    }

    public void Export()
    {
        string currentDirectory = Directory.GetCurrentDirectory();

        // Find the solution directory
        while (!File.Exists(Path.Combine(currentDirectory, "Bioscoop.sln")))
        {
            currentDirectory = Directory.GetParent(currentDirectory).FullName;
        }

        string pathName = $"{currentDirectory}/order_{GetOrderNr()}";

        _exportOrder.ExportOrder(this, pathName);
    }
}