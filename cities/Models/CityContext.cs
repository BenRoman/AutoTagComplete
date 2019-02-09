using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace cities.Models
{
    public class CityContext:DbContext
    {

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
    }

    public class MyContextInitializer : DropCreateDatabaseAlways<CityContext>
    {
        protected override void Seed(CityContext db)
        {
            db.Countries.Add(new Country() { Name = "Ukraine", Cities = new List<City>() { new City() { Name = "Lviv" } , new City() { Name = "Odessa" }, new City() { Name = "Kyiv" } } });
            db.Countries.Add(new Country() { Name = "Russia", Cities = new List<City>() { new City() { Name = "Moscow" } , new City() { Name = "SPB" } } });

            db.SaveChanges();
        }
    }

}