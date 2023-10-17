using System.ComponentModel.DataAnnotations;

namespace CarSales.Data
{
    public class Car
    {
        public Car(int id,
            string name,
            string manufacturer,
            int year,
            Fuel fuel,
            double price,
            DateTime dateAdded,
            bool sold)
        {
            Id = id;
            Name = name;
            Manufacturer = manufacturer;
            Year = year;
            Fuel = fuel;
            Price = price;
            DateAdded = dateAdded;
            Sold = sold;
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public int Year { get; set; }
        public Fuel Fuel { get; set; }
        public double Price { get; set; }
        public DateTime DateAdded { get; set; }
        public bool Sold { get; set; }

        public override string? ToString()
        {
            return Id + ": " + Manufacturer + " - " +
                Name + "(" + Year + ") £" + Price + " "
                + Fuel + "(" +
                DateAdded.ToShortDateString() + ") " +
                (Sold ? "**" : "");
        }
    }
}
