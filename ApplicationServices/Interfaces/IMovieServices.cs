using MC.ApplicationServices.Messaging;

namespace MC.ApplicationServices.Interfaces;

public interface IMovieServices
{
    public Task<GetByTitleResponse> GetByTitleAsync(GetByTitleRequest request);
}
