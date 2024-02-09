using MC.ApplicationServices.Messaging.Responses;
using MC.ApplicationServices.Messaging.Requests;

namespace MC.ApplicationServices.Interfaces;

/// <summary>
/// Movie service.
/// </summary>
public interface IMoviesService
{
    // <summary>
    // Get all movies
    // </summary>
    // <returns>Return list of movies.</returns>
    public Task<GetMoviesResponse> GetMoviesAsync();

    // <summary>
    // Get movie by title
    // </summary>
    // <param name="request">Get title by request object</param>
    // <returns>Return single movie by title.</returns>
    public Task<GetByTitleResponse> GetByTitleAsync(GetByTitleRequest request);

    // <summary>
    // Get movie by id
    // </summary>
    // <param name="request">Get id by request object</param>
    // <returns>Return single movie by id.</returns>
    public Task<GetByIdResponse> GetByIdAsync(GetByIdRequest request);

    // <summary>
    // Create Movie
    // </summary>
    // <param name="request">Get movie data by request object</param>
    public Task<CreateMovieResponse> CreateMovieAsync(CreateMovieRequest request);

    // <summary>
    // Deletes Movie
    // </summary>
    // <param name="request">Get id by request object</param>
    public Task<DeleteMovieResponse> DeleteMovieAsync(GetByIdRequest request);
}
