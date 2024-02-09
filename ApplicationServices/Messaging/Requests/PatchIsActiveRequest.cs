namespace MC.ApplicationServices.Messaging.Requests;

public class PatchIsActiveRequest : RequestServiceBase
{
    public int Id { get; set; }

    // <summary>
    // Gets or sets movie active flag
    // </summary>
    public bool IsActive { get; set; }

    public PatchIsActiveRequest(int id, bool active)
    {
        Id = id;
        IsActive = active;
    }
};
