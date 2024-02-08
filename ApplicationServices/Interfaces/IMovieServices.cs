using MC.ApplicationServices.Messaging;

namespace MC.ApplicationServices.Interfaces;

public interface IMovieServices
{
    public Task<GetMoviesResponse> GetMoviesAsync();

    public Task<GetByTitleResponse> GetByTitleAsync(GetByTitleRequest request);
    public Task<GetByIdResponse> GetByIdAsync(GetByIdRequest request);
}
