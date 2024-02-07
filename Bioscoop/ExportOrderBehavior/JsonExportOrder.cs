using System.Text.Json;

namespace Bioscoop.ExportOrderBehavior;

public class JsonExportOrder : IExportOrder
{
    public void ExportOrder(Order order, string path)
    {
        try {
            string jsonPath = $"{path}.json";
            File.Create(jsonPath).Close();
            var data = new
            {
                OrderNumber = order.GetOrderNr(),
                TotalPrice = order.CalculatePrice(),
                MovieTickets = order.GetMovieTickets().Select(ticket => new
                {
                    Movie = ticket.MovieScreening.Movie.ToString(),
                    DateAndTime = ticket.MovieScreening.GetDateAndTime(),
                })
            };

            string jsonData = JsonSerializer.Serialize(data);
            File.WriteAllText(jsonPath, jsonData);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
            throw new Exception("Error exporting order to JSON");
        }
    }
}