using Microsoft.EntityFrameworkCore;
using MC.Data.Entities;

namespace MC.WebApiServices.Data
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; } 

        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
            
        }
    }
}
