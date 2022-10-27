using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Watchlist.Data;
using Watchlist.Data.Models;
using Watchlist.Models;
using Watchlist.Services.Contracts;

namespace Watchlist.Services
{
    public class MovieService : IMovieService
    {
        private readonly UserManager<User> userManager;
        private readonly WatchlistDbContext db;

        public MovieService(WatchlistDbContext _db,
                            UserManager<User> _userManager)
        {
            db = _db;
            userManager = _userManager;
        }

        public async Task AddMovieAsync(AddMovieViewModel model)
        {
            var entity = new Movie()
            {
                Director = model.Director,
                ImageUrl = model.ImageUrl,
                Title = model.Title,
                Rating = model.Rating,
                GenreId = model.GenreId
            };

            await db.Movies.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task AddMovieToCollectionAsync(int movieId, string userId)
        {
            var user = await db.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .FirstOrDefaultAsync();

            if(user == null)
            {
                throw new ArgumentException("Invalid User ID");
            }

            var movie = await db.Movies.FirstOrDefaultAsync(m => m.Id == movieId);

            if(movie == null)
            {
                throw new ArgumentException("Invalid Movie ID");
            }

            if(!user.UsersMovies.Any(m => m.MovieId == movieId))
            {
                user.UsersMovies
                    .Add(new UserMovie { UserId = userId, MovieId = movieId });
            }

            await db.SaveChangesAsync();
        }

       

        public async Task<IEnumerable<MovieViewModel>> GetAllAsync()
        {
            return await db.Movies.Select(m => new MovieViewModel()
            {
                Id = m.Id,
                ImageUrl = m.ImageUrl,
                Title = m.Title,
                Director = m.Director,
                Rating = m.Rating,
                Genre = m.Genre.Name,
            }).ToListAsync();
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await db.Genres.ToListAsync();
        }

        public async Task<IEnumerable<MovieViewModel>> GetWatchedAsync(string userId)
        {
            var user = await db.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .ThenInclude(um =>um.Movie)
                .ThenInclude(m => m.Genre)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid User ID");
            }

            return user.UsersMovies.Select(x => new MovieViewModel()
            {
                Director = x.Movie.Director,
                Genre = x.Movie.Genre.Name,
                Id = x.MovieId,
                ImageUrl = x.Movie.ImageUrl,
                Title = x.Movie.Title,
                Rating = x.Movie.Rating
            });
        }

        public async Task RemoveFromCollectionAsync(int movieId, string userId)
        {
            var user = await db.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid User ID");
            }

            var movie = user.UsersMovies.FirstOrDefault(m => m.MovieId == movieId);

            if (movie != null)
            {
                user.UsersMovies.Remove(movie);

                await db.SaveChangesAsync();
            }
        }
    }
}
