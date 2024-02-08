using MC.ApplicationServices.Messaging;
using MC.ApplicationServices.Interfaces;
using MC.Data;
using MC.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MC.ApplicationServices.Implementation;

public class MovieServices : IMovieServices
{
    public readonly MovieDbContext _context;

    public MovieServices(MovieDbContext context)
    {
        _context = context;
    }

    public async Task<GetByTitleResponse> GetByTitleAsync(GetByTitleRequest request)
    {
        string title = request.Title;
        var movie = await _context.Movies.SingleOrDefaultAsync(x => x.Title.Contains(title));

        GetByTitleResponse response = new GetByTitleResponse();

        if(movie == null) {
            response.Status = BusinessStatusCodeEnum.NotFound;
            return response;
        }
        response.Movie = new Movie {
            Title = movie.Title,
            Description = movie.Description,
            ReleaseDate = movie.ReleaseDate,
        };

        return response;
    }
}
