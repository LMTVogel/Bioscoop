namespace Bioscoop;

public class Movie
{
    private string _title;
    private List<MovieScreening> _screenings;

    public Movie(string title)
    {
        this._title = title;
        this._screenings = new List<MovieScreening>();
    }

    public void AddScreening(MovieScreening movieScreening)
    {
        _screenings.Add(movieScreening);
    }

    public override string ToString()
    {
        return _title;
    }
}