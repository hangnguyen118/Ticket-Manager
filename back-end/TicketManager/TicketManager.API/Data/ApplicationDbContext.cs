using Microsoft.EntityFrameworkCore;
using TicketManager.API.EntityModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TicketManager.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<ShowTime> ShowTimes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser { Id = "1", FullName = "Nguyễn Văn Thanh" },
                new ApplicationUser { Id = "2", FullName = "Trần Thị Mai" },
                new ApplicationUser { Id = "3", FullName = "Lê Hoàng Nam" },
                new ApplicationUser { Id = "4", FullName = "Phạm Quốc Đạt" },
                new ApplicationUser { Id = "5", FullName = "Võ Thị Hạnh" }
                );
            builder.Entity<Cinema>().HasData(
                new Cinema { Id = "1", Name = "Galaxy Cinema", City = "Hồ Chí Minh", State = "HCM", StreetAddress = "123 Lê Lợi" },
                new Cinema { Id = "2", Name = "CGV Cinema", City = "Hà Nội", State = "HN", StreetAddress = "45 Trần Duy Hưng" },
                new Cinema { Id = "3", Name = "Lotte Cinema", City = "Đà Nẵng", State = "DN", StreetAddress = "67 Nguyễn Văn Linh" },
                new Cinema { Id = "4", Name = "BHD Star", City = "Hồ Chí Minh", State = "HCM", StreetAddress = "91 Phạm Văn Đồng" },
                new Cinema { Id = "5", Name = "Mega GS", City = "Cần Thơ", State = "CT", StreetAddress = "12 Lý Thái Tổ" }
                );
            builder.Entity<Image>().HasData(
                new Image { Id = "1", ImageUrl = "https://th.bing.com/th/id/OIP.OcMcFzlthlJMwSmoetYzUwHaJ6?rs=1&pid=ImgDetMain", ApplicationUserId = "1", ImageType = "IMG_USER" },
                new Image { Id = "2", ImageUrl = "https://th.bing.com/th/id/OIP.OcMcFzlthlJMwSmoetYzUwHaJ6?rs=1&pid=ImgDetMain", MovieId = "1", ImageType = "IMG_MOVIE" },
                new Image { Id = "3", ImageUrl = "https://th.bing.com/th/id/OIP.OcMcFzlthlJMwSmoetYzUwHaJ6?rs=1&pid=ImgDetMain", ApplicationUserId = "1", ImageType = "IMG_USER" },
                new Image { Id = "4", ImageUrl = "https://th.bing.com/th/id/OIP.OcMcFzlthlJMwSmoetYzUwHaJ6?rs=1&pid=ImgDetMain", MovieId = "1", ImageType = "IMG_MOVIE" },
                new Image { Id = "5", ImageUrl = "https://th.bing.com/th/id/OIP.OcMcFzlthlJMwSmoetYzUwHaJ6?rs=1&pid=ImgDetMain", MovieId = "1", ImageType = "IMG_MOVIE" },
                new Image { Id = "6", ImageUrl = "https://th.bing.com/th/id/OIP.OcMcFzlthlJMwSmoetYzUwHaJ6?rs=1&pid=ImgDetMain", MovieId = "2", ImageType = "IMG_MOVIE" },
                new Image { Id = "7", ImageUrl = "https://th.bing.com/th/id/OIP.OcMcFzlthlJMwSmoetYzUwHaJ6?rs=1&pid=ImgDetMain", MovieId = "3", ImageType = "IMG_MOVIE" },
                new Image { Id = "8", ImageUrl = "https://th.bing.com/th/id/OIP.OcMcFzlthlJMwSmoetYzUwHaJ6?rs=1&pid=ImgDetMain", MovieId = "3", ImageType = "IMG_MOVIE" },
                new Image { Id = "9", ImageUrl = "https://th.bing.com/th/id/OIP.OcMcFzlthlJMwSmoetYzUwHaJ6?rs=1&pid=ImgDetMain", MovieId = "4", ImageType = "IMG_MOVIE" }
                );
            builder.Entity<Movie>().HasData(
                new Movie { Id = "1", Title = "Inception", Description = "A mind-bending thriller by Christopher Nolan.", Genre = "Sci-Fi", ReleaseDate = new DateTime(2010, 7, 16), Rating = 8.8f, Duration = 148 },
                new Movie { Id = "2", Title = "The Dark Knight", Description = "Batman battles the Joker in Gotham City.", Genre = "Action", ReleaseDate = new DateTime(2008, 7, 18), Rating = 9.0f, Duration = 152 },
                new Movie { Id = "3", Title = "Interstellar", Description = "A journey through space and time to save humanity.", Genre = "Sci-Fi", ReleaseDate = new DateTime(2014, 11, 7), Rating = 8.6f, Duration = 169 },
                new Movie { Id = "4", Title = "Parasite", Description = "A gripping story of class struggle in South Korea.", Genre = "Thriller", ReleaseDate = new DateTime(2019, 5, 30), Rating = 8.6f, Duration = 132 },
                new Movie { Id = "5", Title = "Avengers: Endgame", Description = "The epic conclusion to the Avengers saga.", Genre = "Action", ReleaseDate = new DateTime(2019, 4, 26), Rating = 8.4f, Duration = 181 }
            );
            builder.Entity<Seat>().HasData(
                new Seat { Id = "1", Row = "A", Column = "1", ScreenId = "1", Aisle = null, SeatType = "Regular", Price = 100.0 },
                new Seat { Id = "2", Row = "A", Column = "2", ScreenId = "1", Aisle = null, SeatType = "Regular", Price = 100.0 },
                new Seat { Id = "3", Row = "B", Column = "1", ScreenId = "2", Aisle = "Left", SeatType = "VIP", Price = 150.0 },
                new Seat { Id = "4", Row = "B", Column = "2", ScreenId = "2", Aisle = null, SeatType = "VIP", Price = 150.0 },
                new Seat { Id = "5", Row = "C", Column = "1", ScreenId = "3", Aisle = "Right", SeatType = "Couple", Price = 200.0 }
                );
            builder.Entity<ShowTime>().HasData(
                new ShowTime { Id = "1", StartTime = new DateTime(2024, 3, 10, 10, 00, 00), EndTime = new DateTime(2024, 3, 10, 12, 30, 00), MovieId = "1", ScreenId = "1" },
                new ShowTime { Id = "2", StartTime = new DateTime(2024, 3, 10, 13, 00, 00), EndTime = new DateTime(2024, 3, 10, 15, 15, 00), MovieId = "2", ScreenId = "1" },
                new ShowTime { Id = "3", StartTime = new DateTime(2024, 3, 11, 17, 30, 00), EndTime = new DateTime(2024, 3, 11, 19, 45, 00), MovieId = "3", ScreenId = "2" },
                new ShowTime { Id = "4", StartTime = new DateTime(2024, 3, 12, 20, 00, 00), EndTime = new DateTime(2024, 3, 12, 22, 30, 00), MovieId = "4", ScreenId = "3" },
                new ShowTime { Id = "5", StartTime = new DateTime(2024, 3, 13, 22, 00, 00), EndTime = new DateTime(2024, 3, 14, 00, 30, 00), MovieId = "5", ScreenId = "3" }
                );            
            builder.Entity<PaymentMethod>().HasData(
                new PaymentMethod { Id = "1", Name = "Credit Card" },
                new PaymentMethod { Id = "2", Name = "PayPal" },
                new PaymentMethod { Id = "3", Name = "Stripe" }
                );
            builder.Entity<Screen>().HasData(
                new Screen { Id = "1", ScreenNumber = "S01", Capacity = 100, CinemaId = "1" },
                new Screen { Id = "2", ScreenNumber = "S02", Capacity = 120, CinemaId = "1" },
                new Screen { Id = "3", ScreenNumber = "S03", Capacity = 150, CinemaId = "2" },
                new Screen { Id = "4", ScreenNumber = "S04", Capacity = 80, CinemaId = "3" },
                new Screen { Id = "5", ScreenNumber = "S05", Capacity = 200, CinemaId = "3" }
                );
            builder.Entity<Order>().HasData(
               new Order { Id = "1", CreateAt = new DateTime(2024, 3, 1, 12, 0, 0), PaymentMethodId = "1", TransactionId = "TXN12345", PaymentStatus = "Paid", PaymentIntentId = "PI98765", ApplicationUserId = "1", ShowTimeId = "1", TotalPrice = 250.00, OrderStatus = "Completed" },
               new Order { Id = "2", CreateAt = new DateTime(2024, 3, 2, 14, 30, 0), PaymentMethodId = "2", TransactionId = "TXN67890", PaymentStatus = "Pending", PaymentIntentId = "PI54321", ApplicationUserId = "2", ShowTimeId = "2", TotalPrice = 180.50, OrderStatus = "Pending" },
               new Order { Id = "3", CreateAt = new DateTime(2024, 3, 3, 10, 15, 0), PaymentMethodId = "3", TransactionId = "TXN11111", PaymentStatus = "Failed", PaymentIntentId = null, ApplicationUserId = "3", ShowTimeId = "3", TotalPrice = 320.75, OrderStatus = "Cancelled" },
               new Order { Id = "4", CreateAt = new DateTime(2024, 3, 4, 18, 45, 0), PaymentMethodId = "1", TransactionId = "TXN22222", PaymentStatus = "Paid", PaymentIntentId = "PI22222", ApplicationUserId = "4", ShowTimeId = "4", TotalPrice = 410.25, OrderStatus = "Completed" },
               new Order { Id = "5", CreateAt = new DateTime(2024, 3, 5, 20, 0, 0), PaymentMethodId = "2", TransactionId = "TXN33333", PaymentStatus = "Pending", PaymentIntentId = "PI33333", ApplicationUserId = "5", ShowTimeId = "5", TotalPrice = 275.00, OrderStatus = "Pending" }
                );
           
        }
    }
}
