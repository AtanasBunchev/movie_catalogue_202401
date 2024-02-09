namespace MC.ApplicationServices.Messaging.Requests;

public class GetByIdRequest : RequestServiceBase
{
    public int Id { get; set; }

    public GetByIdRequest(int id)
    {
        Id = id;
    }
};
