using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using vidl.Models;
using System.Web;
using System.Web.Mvc;
using vidl.ViewModel;
using System.Data.Common;
using System.Web.Security;

namespace vidl.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;
        // GET: Movie

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Random()
        {
            if(User.IsInRole(RoleName.CanManageMovies))
            return View("List");
            return View("ReadOnly");

        }


        [Authorize(Roles=RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            { 
                Genres = genres
            };
             return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("New", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Random", "Movie");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                
                Genres=_context.Genres.ToList()

            };
            return View("New", viewModel);
        }

public ActionResult Details(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);

        }
    }
}