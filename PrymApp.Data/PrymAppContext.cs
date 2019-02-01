using PrymApp.Data.Model;
using System.Data.Entity;

namespace PrymApp.Data
{
    public class PrymAppContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
     

        //public Database Database => base.Database;
        //public int SaveChanges()
        //{
        //    return base.SaveChanges();
        //}

        public PrymAppContext() 
            : base("name=PrymAppConnection")
        {

        }

        public static PrymAppContext Create()
        {
            return new PrymAppContext();
        }

       
    }
}
