using MC.Data.Entities;

namespace MC.ApplicationServices.Messaging;

public class GetMoviesResponse : ResponseServiceBase
{
    public List<Movie> Movies { get; set; }
};
