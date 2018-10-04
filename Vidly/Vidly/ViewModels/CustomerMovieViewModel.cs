using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerMovieViewModel
    {
        public List<Movie> Movies { get; set; }
        public Movie Movie { get; set; }

        public List<Customer> Customers { get; set; }        
        public Customer Customer { get; set; }

        public List<Genre> Genres { get; set; }
        public Genre Genre { get; set; }

        public List<MembershipType> MembershipTypes { get; set; }
        public MembershipType MembershipType { get; set; }
    }
}