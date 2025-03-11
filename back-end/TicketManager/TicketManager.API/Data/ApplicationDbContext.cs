using Microsoft.EntityFrameworkCore;

namespace TicketManager.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) { }
    }
}
