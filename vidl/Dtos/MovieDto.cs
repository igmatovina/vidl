using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidl.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public byte GenreId { get; set; }
        public GenreDto Genre { get; set; }

        public DateTime DateAdded { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [Range(1, 30)]
        public byte NumberInStock { get; set; }
        public byte NumberAvailable { get; set; }
    }
}