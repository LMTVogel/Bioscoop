namespace Bioscoop.ExportOrderBehavior;

public class PlainTextExportOrder : IExportOrder
{
    public void ExportOrder(Order order, string path)
    {
        string txtPath = $"{path}.txt";
        File.Create(txtPath).Close();
        using (StreamWriter writer = new(txtPath))
        {
            writer.WriteLine($"Order number: {order.GetOrderNr()}");
            writer.WriteLine($"Total price: {order.CalculatePrice()}\n");
            writer.WriteLine("Movies:");
            foreach (var movieTicket in order.GetMovieTickets())
            {
                writer.WriteLine($"{movieTicket.MovieScreening.Movie}");
                writer.WriteLine($"Date and time: {movieTicket.MovieScreening.GetDateAndTime()}");
            }
        }
    }
}