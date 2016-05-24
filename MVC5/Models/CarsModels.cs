using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MVC5.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        [Required]
        public string Year { get; set; }

        public string Type { get; set; }
        public decimal RetailPrice { get; set; }
        public string Doors { get; set; }
        public string Fuel { get; set; }
        public string Transmission { get; set; }
        public string Interior { get; set; }
        public string Price { get; set; }
    }

    public class CarDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
    }
}