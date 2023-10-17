using Microsoft.EntityFrameworkCore;

namespace CarSales.Data
{
    public class CarSalesDbContext : DbContext
    {
        public string DbPath { get; }

        public CarSalesDbContext()
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "cars.db");
        }

        public DbSet<Car> Cars => Set<Car>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>().HasData(
                new Car(1, "Polo", "Volkswagen", 2013, Fuel.PETROL, 4795, DateTime.Parse("2022-07-10"), true),
                new Car(2, "Fiesta", "Ford", 2017, Fuel.PETROL, 9597, DateTime.Parse("2022-07-13"), false),
                new Car(3, "1 Series", "BMW", 2016, Fuel.DIESEL, 11749, DateTime.Parse("2022-07-19"), true),
                new Car(4, "2 Series", "BMW", 2017, Fuel.HYBRID, 18989, DateTime.Parse("2022-07-21"), true),
                new Car(5, "Prius", "Toyota", 2014, Fuel.HYBRID, 13490, DateTime.Parse("2022-07-21"), true),
                new Car(6, "Focus", "Ford", 2015, Fuel.DIESEL, 3995, DateTime.Parse("2022-07-25"), false),
                new Car(7, "Golf", "Volkswagen", 2018, Fuel.ELECTRIC, 21000, DateTime.Parse("2022-07-30"), true),
                new Car(8, "Yaris", "Toyota", 2021, Fuel.HYBRID, 18990, DateTime.Parse("2022-08-01"), false),
                new Car(9, "i3", "BMW", 2014, Fuel.ELECTRIC, 14990, DateTime.Parse("2022-08-01"), false),
                new Car(10, "RAV4", "Toyota", 2018, Fuel.HYBRID, 18495, DateTime.Parse("2022-08-03"), true),
                new Car(11, "3 Series", "BMW", 2017, Fuel.HYBRID, 15000, DateTime.Parse("2022-08-07"), true),
                new Car(12, "Focus", "Ford", 2014, Fuel.DIESEL, 4995, DateTime.Parse("2022-08-08"), false),
                new Car(13, "1 Series", "BMW", 2018, Fuel.PETROL, 17250, DateTime.Parse("2022-08-10"), true),
                new Car(14, "Fiesta", "Ford", 2015, Fuel.PETROL, 5400, DateTime.Parse("2022-08-15"), true),
                new Car(15, "Z4", "BMW", 2014, Fuel.PETROL, 8990, DateTime.Parse("2022-08-20"), false),
                new Car(16, "4 Series", "BMW", 2015, Fuel.DIESEL, 16990, DateTime.Parse("2022-08-27"), true),
                new Car(17, "Zoe", "Renault", 2014, Fuel.ELECTRIC, 8995, DateTime.Parse("2022-09-02"), true),
                new Car(18, "Fiesta", "Ford", 2016, Fuel.PETROL, 9380, DateTime.Parse("2022-09-05"), false),
                new Car(19, "3 Series", "BMW", 2014, Fuel.PETROL, 11595, DateTime.Parse("2022-09-07"), false),
                new Car(20, "Focus", "Ford", 2017, Fuel.PETROL, 8495, DateTime.Parse("2022-09-10"), false)
            );
        }
    }
}
