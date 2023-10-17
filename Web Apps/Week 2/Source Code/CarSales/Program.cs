using CarSales.Data;
using System;
using System.Linq;

using var db = new CarSalesDbContext();

var cars = db.Cars.ToList();
foreach (Car car in cars)
{
    Console.WriteLine(car);
}