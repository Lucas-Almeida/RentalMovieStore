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
    public class CustomersController : Controller
    {
        private CustomerMovieViewModel customerMovieVM;
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
            customerMovieVM = new CustomerMovieViewModel();
            customerMovieVM.Customer = new Customer();
            customerMovieVM.Customers = new List<Customer>();

            foreach (var customer in _context.Customers)
            {
                customerMovieVM.Customers.Add(customer);
            }
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.Memberships.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes,
                Customer = new Customer()
            };

            return View("CustomerForm", viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.Memberships.ToList(),
                };

                return View("CustomerForm", viewModel);
            }
               
            if(customer.Id == 0)
            {
                _context.Customers.Add(customer);
            } else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;                 
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null) return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.Memberships.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        public ActionResult Details(int? id)
        {
            customerMovieVM.Customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customerMovieVM.Customer == null) return HttpNotFound();

            return View(customerMovieVM);
        }
    }
}