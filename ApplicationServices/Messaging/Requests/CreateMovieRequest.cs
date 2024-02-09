namespace MC.ApplicationServices.Messaging.Requests;

public class CreateMovieRequest : RequestServiceBase
{
    public MovieModel Movie { get; set; }

    public CreateMovieRequest(MovieModel movie)
    {
        Movie = movie;
    }
};
