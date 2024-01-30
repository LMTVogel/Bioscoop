namespace Bioscoop;

public class MovieScreening
{
    private DateTime _dateAndTime { get; }
    private double _pricePerSeat;
    private Movie _movie;

    public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
    {
        this._movie = movie;
        this._dateAndTime = dateAndTime;
        this._pricePerSeat = pricePerSeat;
    }
    
    public double GetPricePerSeat()
    {
        return _pricePerSeat;
    }
    
    public override string ToString()
    {
        return base.ToString();
    }
}