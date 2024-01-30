namespace Bioscoop;

public class MovieScreening
{
    private DateTime dateAndTime;
    private double pricePerSeat;
    private Movie movie;

    public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
    {
        this.movie = movie;
        this.dateAndTime = dateAndTime;
        this.pricePerSeat = pricePerSeat;
    }
    
    public double getPricePerSeat()
    {
        return pricePerSeat;
    }
    
    public override string ToString()
    {
        return base.ToString();
    }
}