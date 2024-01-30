namespace Bioscoop;

public class MovieTicket
{
    private MovieScreening _movieScreening;
    private int _rowNr;
    private int _seatNr;
    private bool _isPremium;

    public MovieTicket(MovieScreening movieScreening, int seatRow, int seatNr, bool isPremiumReservation)
    {
        this._movieScreening = movieScreening;
        this._rowNr = seatRow;
        this._seatNr = seatNr;
        this._isPremium = isPremiumReservation;
    }

    public bool IsPremiumTicket()
    {
        return false;
    }

    public double GetPrice()
    {
        return _movieScreening.GetPricePerSeat();
    }

    public override string ToString()
    {
        return base.ToString();
    }
}