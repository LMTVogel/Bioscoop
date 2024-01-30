namespace Bioscoop;

public class MovieTicket
{
    private MovieScreening movieScreening;
    private int rowNr;
    private int seatNr;
    private bool isPremium;

    public MovieTicket(MovieScreening movieScreening, int seatRow, int seatNr, bool isPremiumReservation)
    {
        this.movieScreening = movieScreening;
        this.rowNr = seatRow;
        this.seatNr = seatNr;
        this.isPremium = isPremiumReservation;
    }

    public bool isPremiumTicket()
    {
        return false;
    }

    public double getPrice()
    {
        return 0.1;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}