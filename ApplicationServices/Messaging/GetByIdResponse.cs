using MC.Data.Entities;

namespace MC.ApplicationServices.Messaging;

public class GetByIdResponse : ResponseServiceBase
{
    public Movie Movie { get; set; }
};
