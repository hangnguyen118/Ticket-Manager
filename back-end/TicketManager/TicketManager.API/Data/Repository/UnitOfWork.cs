using TicketManager.API.Data.Repository.IRepository;
using TicketManager.API.EntityModels;

namespace TicketManager.API.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IBaseRepository<Cinema> Cinema { get; private set; }
        public IBaseRepository<Screen> Screen { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Cinema = new BaseRepository<Cinema>(_db);
            Screen = new BaseRepository<Screen>(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
