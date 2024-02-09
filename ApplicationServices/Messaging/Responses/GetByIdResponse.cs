namespace MC.ApplicationServices.Messaging.Responses;

public class GetByIdResponse : ResponseServiceBase
{
    public MovieModel Movie { get; set; }
};
