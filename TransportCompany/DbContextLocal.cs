using Microsoft.EntityFrameworkCore;
using Models;
using TransportCompany.ViewModels;

namespace TransportCompany
{
    public class DbContextLocal: DbContext
    {
        public DbContextLocal(DbContextOptions options): base(options)
        {

            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            var user1 = new User
            {
                Id = 1,
                Login = "admin",
                Password = "admin",
                Name = "Админ",
                UserGroup = UserGroup.Manager
            };
            var user2 = new User
            {
                Id = 2,
                Login = "driver",
                Password = "driver",
                Name = "Водитель",
                UserGroup = UserGroup.Driver
            };
            var user3 = new User
            {
                Id = 3,
                Login = "agent",
                Password = "agent",
                Name = "Контрагент",
                UserGroup = UserGroup.Contragent
            };

            var contragent = new Contragent
            {
                Adres = "Пушкина, д. Кол",
                Country = "Россия",
                GenDirector = "Иванов",
                Id = 1,
                Name = "Петр",
                Phone = "8987957289",
                UserId = 3
            };

            var driver = new Driver
            {
                Id = 1,
                DriverCategory = DriverCategory.C,
                Address = "Ул. Леннина",
                Name = "Валя",
                Otchestvo = "Петрович",
                Surname = "Снегирев",
                Phone = "89984395879",
                IsDriverFree = true,
                UserId = 2,
            };

            modelBuilder.Entity<User>().HasData(user1, user2, user3);
            modelBuilder.Entity<Driver>().HasData(driver);
            modelBuilder.Entity<Contragent>().HasData(contragent);

        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Driver> Drivers => Set<Driver>();
        public DbSet<Route> Routes => Set<Route>();
        public DbSet<Transp> Transps => Set<Transp>();
        public DbSet<Models.Transit> Transits => Set<Transit>();
        public DbSet<Models.Gruz> Gruzs => Set<Gruz>();
        public DbSet<Models.Reys> Reys => Set<Reys>();
        public DbSet<Models.Contragent> Contragents => Set<Contragent>();
    }
}
