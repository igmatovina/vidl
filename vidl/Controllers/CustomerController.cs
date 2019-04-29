using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidl.Models;
using vidl.ViewModel;
namespace vidl.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [Authorize]

        // GET: Customer
        public ActionResult Index()
        {
            
            return View();

        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
              
        }

       public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("New", viewModel);
            }


            if (customer.Id==0)
            _context.Customers.Add(customer);

            else
            {
                 var CustomerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                CustomerInDb.Name = customer.Name;
                CustomerInDb.Birthdate = customer.Birthdate;
                CustomerInDb.MembershipTypeId = customer.MembershipTypeId;
                CustomerInDb.IsSubscribedToNewsletter=customer.IsSubscribedToNewsletter;
                    }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");        
        }


        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
             {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
                  
            };

            return View("New", viewModel);
        }

    }
};
    
