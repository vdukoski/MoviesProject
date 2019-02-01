using System;
using System.ComponentModel.DataAnnotations;

namespace PrymApp.Data.Model
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string  Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string DirectorName { get; set; }

        public Genre Genre { get; set; }

        public DateTime ReleaseDate { get; set; }










    }
}
