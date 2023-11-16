using System.Runtime.ConstrainedExecution;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using ThAmCo.Catering.Data;

namespace ThAmCo.Catering.DatabaseContexts
{
    public class CateringDbContext : DbContext
    {
        public DbSet<FoodItem> FoodItems { get; set; }
        
        public DbSet<Menu> Menus { get; set; }

        public DbSet<MenuFoodItems> MenusFoodItems { get; set; }

        public DbSet<FoodBooking> FoodBookings { get; set; }

        #region SettingUpContext

        private readonly IHostEnvironment _hostEnv;
        private readonly string DbPath;

        public CateringDbContext(DbContextOptions<CateringDbContext> options, IHostEnvironment hostEnv)
        {
            _hostEnv = hostEnv;

            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "ThAmCo.Catering.db");
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
            modelBuilder.Entity<FoodItem>()
                  .Property(p => p.Description)
                  .HasMaxLength(50);

            modelBuilder.Entity<Menu>()
                  .Property(p => p.MenuName)
                  .HasMaxLength(50);


            modelBuilder.Entity<FoodItem>().HasData(
                  // Starters
                  new FoodItem { FoodItemId = 1, Description = "Prawn Cocktail", UnitPrice = 6.99 },
                  new FoodItem { FoodItemId = 2, Description = "Scotch Egg", UnitPrice = 8.49 },
                  new FoodItem { FoodItemId = 3, Description = "Soup of the Day", UnitPrice = 4.99 },
                  new FoodItem { FoodItemId = 4, Description = "Deviled Whitebait", UnitPrice = 7.99 },
                  new FoodItem { FoodItemId = 5, Description = "Stilton and Broccoli Bites", UnitPrice = 6.49 },

                  // Main Courses
                  new FoodItem { FoodItemId = 6, Description = "Full-English Breakfast", UnitPrice = 9.99 },
                  new FoodItem { FoodItemId = 7, Description = "Shepherd's Pie", UnitPrice = 12.99 },
                  new FoodItem { FoodItemId = 8, Description = "Bangers and Mash", UnitPrice = 11.99 },
                  new FoodItem { FoodItemId = 9, Description = "Ploughman's Lunch", UnitPrice = 7.99 },
                  new FoodItem { FoodItemId = 10, Description = "Cornish Pasty", UnitPrice = 6.99 },
                  new FoodItem { FoodItemId = 11, Description = "Beef Wellington", UnitPrice = 18.99 },
                  new FoodItem { FoodItemId = 12, Description = "Black Pudding", UnitPrice = 8.99 },
                  new FoodItem { FoodItemId = 13, Description = "Bubble and Squeak", UnitPrice = 6.49 },
                  new FoodItem { FoodItemId = 14, Description = "Stilton Cheese", UnitPrice = 14.99 },
                  new FoodItem { FoodItemId = 15, Description = "Fish and Chips", UnitPrice = 8.99 },

                  // Desserts
                  new FoodItem { FoodItemId = 16, Description = "Sticky Toffee Pudding", UnitPrice = 7.49 },
                  new FoodItem { FoodItemId = 17, Description = "Trifle", UnitPrice = 6.99 },
                  new FoodItem { FoodItemId = 18, Description = "Apple Crumble", UnitPrice = 5.99 },
                  new FoodItem { FoodItemId = 19, Description = "Eton Mess", UnitPrice = 8.49 },
                  new FoodItem { FoodItemId = 20, Description = "Victoria Sponge Cake", UnitPrice = 9.99 }
            );

            base.OnModelCreating(modelBuilder);

        }

        #endregion

    }
}
