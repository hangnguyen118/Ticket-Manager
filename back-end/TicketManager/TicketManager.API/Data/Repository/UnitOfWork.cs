using TicketManager.API.Data.Repository.IRepository;
using TicketManager.API.EntityModels;

namespace TicketManager.API.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IBaseRepository<Cinema> Cinema { get; private set; }
        public IBaseRepository<Screen> Screen { get; private set; }
        public IBaseRepository<Seat> Seat { get; private set; }
        public IBaseRepository<ShowTime> ShowTime { get; private set; }
        public IBaseRepository<Movie> Movie { get; private set; }
        public IBaseRepository<PaymentMethod> PaymentMethod { get; private set; }
        public IBaseRepository<ApplicationUser> ApplicationUser { get; private set; }
        public IBaseRepository<Image> Image { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Cinema = new BaseRepository<Cinema>(_db);
            Screen = new BaseRepository<Screen>(_db);
            Seat = new BaseRepository<Seat>(_db);
            ShowTime = new BaseRepository<ShowTime>(_db);
            Movie = new BaseRepository<Movie>(_db);
            PaymentMethod = new BaseRepository<PaymentMethod>(_db);
            ApplicationUser = new BaseRepository<ApplicationUser>(_db);
            Image = new BaseRepository<Image>(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
