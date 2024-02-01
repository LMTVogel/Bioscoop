namespace Bioscoop;

public class MovieTicket
{
    public MovieScreening MovieScreening;
    private int _rowNr;
    private int _seatNr;
    private bool _isPremium;

    public MovieTicket(MovieScreening movieScreening, int seatRow, int seatNr, bool isPremiumReservation)
    {
        this.MovieScreening = movieScreening;
        this._rowNr = seatRow;
        this._seatNr = seatNr;
        this._isPremium = isPremiumReservation;
    }

    public bool IsPremiumTicket()
    {
        return this._isPremium;
    }

    public double GetPrice()
    {
        return MovieScreening.GetPricePerSeat();
    }

    public override string ToString()
    {
        return base.ToString();
    }
}