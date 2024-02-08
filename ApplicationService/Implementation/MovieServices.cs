using MC.ApplicationServices.Messaging;
using MC.ApplicationServices.Interfaces;
namespace MC.ApplicationServices.Implementation;

public class MovieServices : IMovieServices
{
    

    public async Task<GetByTitleResponse> GetByTitleAsync(GetByTitleRequest request)
    {
        var movie = await _context.Movies.SingleOrDefaultAsync(x => x.Title.Contains(title));

        GetByTitleResponse response;

        if(movie == null) {
            response.Status = BusinessStatusCodeEnum.MovieNotFound;
            return response;
        }
        response.Movie = movie;

        return response;
    }
}
