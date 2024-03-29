namespace Bioscoop;

public class MovieScreening
{
    private DateTime _dateAndTime;
    private double _pricePerSeat;
    public Movie Movie;

    public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
    {
        this.Movie = movie;
        this._dateAndTime = dateAndTime;
        this._pricePerSeat = pricePerSeat;
    }
    
    public double GetPricePerSeat()
    {
        return _pricePerSeat;
    }

    public DateTime GetDateAndTime()
    {
        return _dateAndTime;
    }
    
    public override string ToString()
    {
        return base.ToString();
    }
}