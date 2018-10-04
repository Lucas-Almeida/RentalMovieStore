using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult ReturnRental(NewRentalDto rentalDto)
        {
            var rental = _context.Rentals.Single(r => rentalDto.Id == r.Id);
            rental.DateReturned = DateTime.Today;

            var rentalMovies = _context.Movies.Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();
            foreach (var movie in rentalMovies)
            {
                movie.NumberAvailable++;
            }
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            //if (newRental.MovieIds.Count == 0) return BadRequest("No Movies Ids were given");

            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            //if (movies.Count != newRental.MovieIds.Count) return BadRequest("One or more MovieIds are invalid");

            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);
            //var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);
            //if (customer == null) return BadRequest();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0) return BadRequest(movie.Name + " is not avaiable");
                
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now,
                };
                movie.NumberAvailable--;
                _context.Rentals.Add(rental);
                                           
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
