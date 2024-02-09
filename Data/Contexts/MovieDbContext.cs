using MC.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MC.Data.Contexts
{
    /// <summary>
    /// Movie database context.
    /// </summary>
    public class MovieDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets movie dbset collection
        /// </summay>
        public DbSet<Movie> Movies { get; set; } 

        /// <summary>
        /// Gets or sets genre dbset collection
        /// </summay>
        public DbSet<Genre> Genres { get; set; } 

        /// <summary>
        /// Initializes a new instance of the <see cref="MoviesDbContext"/> class.
        /// </summary>
        /// <param name="options"> Database context options. </param>
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        { }
    }
}
