using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using vidl.Dtos;
using vidl.Models;
namespace vidl.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        //get/api/customer
        public IHttpActionResult GetMovies()
        {
            var movieDtos = _context.Movies
                  .Include(c => c.Genre)
                  .ToList()
                  .Select(Mapper.Map<Movie, MovieDto>);
              return Ok(movieDtos);
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            try
            {
                _context.SaveChanges();
            }

            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var MovieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (MovieInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map<MovieDto, Movie>(movieDto, MovieInDb);

            _context.SaveChanges();
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public void DeleteMovie(int id)
        {
            var MovieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (MovieInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(MovieInDb);
            _context.SaveChanges();
        }
    }
}