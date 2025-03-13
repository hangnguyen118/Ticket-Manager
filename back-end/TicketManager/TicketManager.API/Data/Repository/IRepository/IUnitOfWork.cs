using TicketManager.API.EntityModels;

namespace TicketManager.API.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IBaseRepository<Cinema> Cinema { get; }
        IBaseRepository<Screen> Screen { get; }
        IBaseRepository<Seat> Seat { get; }
        void Save();
    }
}
