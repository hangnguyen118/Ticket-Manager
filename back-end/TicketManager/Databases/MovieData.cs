using TicketManagerBE.Model;

namespace TicketManagerBE.Databases
{
    public class MovieData
    {
        public static IEnumerable<Movie> Movies = [
            new Movie{
                Id = 1,
                Title = "Test",
                Description = "Test",
                Author = "Test"
            },
            new Movie{
                Id = 2,
                Title = "Test",
                Description = "Test",
                Author = "Test"
            },
            new Movie{
                Id = 3,
                Title = "Test",
                Description = "Test",
                Author = "Test"
            }
        ];
        public async Task<IEnumerable<Movie>> GetAsyncMovies(CancellationToken token)
        {
            return Movies;
        }
    }
}
