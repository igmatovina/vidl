﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidl.Models;
using System.ComponentModel.DataAnnotations;
namespace vidl.ViewModel
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }


        public int? Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Display(Name = "ReleaseDate")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number In Stock")]
        [Range(1, 30)]
        [Required]
        public byte? NumberInStock { get; set; }      

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";

            }
        }


        public MovieFormViewModel()
        {
            Id = 0;
            
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}