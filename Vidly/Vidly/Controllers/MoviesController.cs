using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private CustomerMovieViewModel customerMovieVM;
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
            customerMovieVM = new CustomerMovieViewModel();
            customerMovieVM.Movie = new Movie();
            customerMovieVM.Movies = new List<Movie>();
            customerMovieVM.Genre = new Genre();
            customerMovieVM.Genres = new List<Genre>();

            foreach (var movie in _context.Movies)
            {
                customerMovieVM.Movies.Add(movie);
            }

            foreach (var genre in _context.Genres)
            {
                customerMovieVM.Genres.Add(genre);
            }
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genres,
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList(),
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            } else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.GenreId = movie.GenreId;
            }
                
            try
            {
                _context.SaveChanges();
            }       
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "Movies");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Details(int? id)
        {
            customerMovieVM.Movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            if (customerMovieVM.Movie == null) return HttpNotFound();
            
            return View(customerMovieVM);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null) return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {                                
                Genres = _context.Genres.ToList(),
            };

            return View("MovieForm", viewModel);
        }

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}

        //[Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{

        //    return Content(year + "/" + month);
        //}
    }
}