using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Data;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.DatabaseContexts
{
    public class EventDbContext : DbContext
    {
        public DbSet<Data.Event> Events { get; set; }

        public DbSet<Data.Staff> Staff { get; set; }

        public DbSet<Data.Guest> Guests { get; set; }

        public DbSet<Data.Staffing> Staffing { get; set; }

        public DbSet<Data.GuestBooking> GuestBookings { get; set; }

        #region SettingUpContext

        private readonly IHostEnvironment _hostEnv;
        private readonly string DbPath;

        public EventDbContext(DbContextOptions<EventDbContext> options, IHostEnvironment hostEnv)
        {
            _hostEnv = hostEnv;

            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "ThAmCo.Events.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        #endregion

        #region Model Creation

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region Model Creation

        public DbSet<ThAmCo.Events.Models.Venue> Venue { get; set; }

        #endregion

    }
}
