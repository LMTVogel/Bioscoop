namespace Bioscoop;

public class Movie
{
    private string title;
    private List<MovieScreening> screenings;

    public Movie(string title)
    {
        this.title = title;
        screenings = new List<MovieScreening>();
    }
    
    public void addScreening(MovieScreening movieScreening)
    {
        
    }

    public override string ToString()
    {
        return base.ToString();
    }
}