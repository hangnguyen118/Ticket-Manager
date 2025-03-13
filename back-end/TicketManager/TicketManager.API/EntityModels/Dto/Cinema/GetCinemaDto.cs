using System.ComponentModel.DataAnnotations;

namespace TicketManager.API.EntityModels.Dto.Cinema
{
    public class GetCinemaDto : BaseCinemaDto
    {
        public string Id { get; set; } = string.Empty;
    }
}
