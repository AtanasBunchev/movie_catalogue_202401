using MC.Data.Entities;

namespace MC.ApplicationServices.Messaging;

public class GetByTitleResponse : ResponseServiceBase
{
    public Movie Movie { get; set; }

    /*
    public GetByTitleResponse(Movie movie)
    {
        Movie = movie;
    }
    */
};
