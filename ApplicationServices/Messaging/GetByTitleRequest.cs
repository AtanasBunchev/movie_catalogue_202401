using MC.Data.Entities;

namespace MC.ApplicationServices.Messaging;

public class GetByTitleRequest : RequestServiceBase
{
    public string Title { get; set; }

    public GetByTitleRequest(string title)
    {
        Title = title;
    }
};
