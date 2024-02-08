using MC.Data.Entities;

namespace MC.ApplicationServices.Messaging;

public class GetByIdRequest : RequestServiceBase
{
    public int Id { get; set; }

    public GetByIdRequest(int id)
    {
        Id = id;
    }
};
