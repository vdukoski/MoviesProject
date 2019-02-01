using PrymApp.Data.Model;
using System;

namespace PrymApps.Business.DtoModel
{
    public class DtoMovie
    {
        public int Id { get; set; }

        public string Name { get; set; }
 
        public string DirectorName { get; set; }

        public Genre Genre { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DtoMovie()
        {

        }

        public DtoMovie(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            Genre = movie.Genre;
            DirectorName = movie.DirectorName;
            ReleaseDate = movie.ReleaseDate;
            
        }
    }
}
