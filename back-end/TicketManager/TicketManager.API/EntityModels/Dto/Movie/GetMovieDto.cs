using System.ComponentModel.DataAnnotations;

namespace TicketManager.API.EntityModels.Dto.Movie
{
    public class GetMovieDto : BaseMovieDto
    {
        public string Id { get; set; } = string.Empty;
    }
}
