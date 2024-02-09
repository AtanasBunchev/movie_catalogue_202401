using MC.ApplicationServices.Messaging;
using MC.ApplicationServices.Messaging.Responses;
using MC.ApplicationServices.Messaging.Requests;
using MC.ApplicationServices.Interfaces;
using MC.Data.Contexts;
using MC.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MC.ApplicationServices.Implementation;

public class MoviesService : IMoviesService
{
    private readonly MovieDbContext _context;
    private readonly ILogger<MoviesService> _logger;

    public MoviesService(MovieDbContext context, ILogger<MoviesService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<GetMoviesResponse> GetMoviesAsync()
    {
        GetMoviesResponse response = new() { Movies = new() };

        var movies = await _context.Movies.ToListAsync();

        foreach(var movie in movies)
        {
            response.Movies.Add(new Messaging.Responses.MovieModel{
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

        if (movie == null)
        {
            response.Status = BusinessStatusCodeEnum.MovieNotExists;
            return response;
        }

        response.Movie = new Messaging.Responses.MovieModel {
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

        if(movie == null)
        {
            response.Status = BusinessStatusCodeEnum.NotFound;
            return response;
        }

        response.Movie = new Messaging.Responses.MovieModel {
            Title = movie.Title,
            Description = movie.Description,
            ReleaseDate = movie.ReleaseDate,
        };

        return response;
    }

    public async Task<CreateMovieResponse> CreateMovieAsync(CreateMovieRequest request)
    {
        CreateMovieResponse response = new();

        try
        {

            Movie movie = new () {
                Title = request.Title,
                Description = request.Description,
                ReleaseDate = request.ReleaseDate
            };

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            response.Id = movie.ID;
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Failed Creating Movie");
            response.Status = BusinessStatusCodeEnum.Failed;
        }

        return response;
    }

    public async Task<DeleteMovieResponse> DeleteMovieAsync(GetByIdRequest request)
    {
        DeleteMovieResponse response = new();
        var id = request.Id;

        var movie = await _context.Movies.SingleOrDefaultAsync(x => x.ID == id);
        if(movie == null) {
            response.Status = BusinessStatusCodeEnum.MovieNotExists;
            return response;
        }

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();

        return response;
    }

    public async Task<PatchIsActiveResponse> PatchIsActiveAsync(PatchIsActiveRequest request)
    {
        PatchIsActiveResponse response = new();
        var id = request.Id;

        var movie = await _context.Movies.SingleOrDefaultAsync(x => x.ID == id);
        if(movie == null) {
            response.Status = BusinessStatusCodeEnum.MovieNotExists;
            return response;
        }

        movie.IsActive = request.IsActive;
        _context.Movies.Update(movie);
        await _context.SaveChangesAsync();

        return response;
    }
}
