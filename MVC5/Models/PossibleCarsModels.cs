namespace MVC5.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PossibleCarsModels : DbContext
    {

        public PossibleCarsModels()
            : base("name=PossibleCars")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    public class PossibleCar
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal RetailPrice { get; set; }
    }

    public class PossibleCarDbContext : CarDbContext
    {
        public DbSet<PossibleCar> PossibleCars { get; set; }        
    }
}