using MC.ApplicationServices.Messaging;
using MC.ApplicationServices.Interfaces;
using MC.Data;
using MC.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MC.ApplicationServices.Implementation;

// TODO rename to MoviesService
public class MovieServices : IMovieServices
{
    public readonly MovieDbContext _context;

    public MovieServices(MovieDbContext context)
    {
        _context = context;
    }

    public async Task<GetMoviesResponse> GetMoviesAsync()
    {
        GetMoviesResponse response = new() { Movies = new() };

        var movies = await _context.Movies.ToListAsync();

        foreach(var movie in movies)
        {
            response.Movies.Add(new Movie{
                Title = movie.Title,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate
            });
        }

        return response;
    }

    public async Task<GetByIdResponse> GetByIdAsync(GetByIdRequest request)
    {
        int id = request.Id;
        var movie = await _context.Movies.SingleOrDefaultAsync(x => x.ID == id);

        GetByIdResponse response = new GetByIdResponse();

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
