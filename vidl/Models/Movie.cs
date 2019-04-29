using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace vidl.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
        public DateTime DateAdded { get; set; }
  
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [Range(1, 30)]
        public byte NumberInStock { get; set; }
        public byte NumberAvailable { get; set; }
    }
}