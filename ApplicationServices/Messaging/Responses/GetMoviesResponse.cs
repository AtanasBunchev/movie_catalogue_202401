namespace MC.ApplicationServices.Messaging.Responses;

public class GetMoviesResponse : ResponseServiceBase
{
    public List<MovieModel> Movies { get; set; }
};
