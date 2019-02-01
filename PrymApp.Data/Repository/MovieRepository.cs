using PrymApp.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace PrymApp.Data.Repository
{
    public class MovieRepository : BaseRepository, IRepository<Movie>
    {
        public Movie Create(Movie item)
        {
            DbContext.Movies.Add(item);
            DbContext.SaveChanges();
            return item;

        }

        public void Delete(Movie item)
        {
            var dbItem = DbContext.Movies.Single(m => m.Id == item.Id);
            DbContext.Movies.Single(m => m.Id == item.Id);
            DbContext.Movies.Remove(dbItem);
            DbContext.SaveChanges();
        }

        public Movie Get(int id)
        {
            return DbContext.Movies.SingleOrDefault(m => m.Id == id);
        }

        public IList<Movie> GetAll()
        {
            return DbContext.Movies.ToList();
        }

        public void Update(Movie item)
        {
            var dbMovie = DbContext.Movies.FirstOrDefault(m =>
               m.Id == item.Id);

            dbMovie.Name = item.Name;
            dbMovie.DirectorName = item.DirectorName;
            dbMovie.ReleaseDate = item.ReleaseDate;
            dbMovie.Genre = item.Genre;

            DbContext.SaveChanges();
        }
    }
}
