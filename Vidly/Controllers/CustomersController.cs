using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public ApplicationDbContext _context { get; set; }
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }
        public ActionResult New() {
            var membershipTypes = _context.MembershipTypes.ToList();
            var ViewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm",ViewModel);
        }
        [HttpPost]
        public ActionResult Create(CustomerFormViewModel viewModel) {
            _context.Customer.Add(viewModel.Customer);
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }

        public ActionResult Edit(int id) {

            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                HttpNotFound();
            var viewModel = new CustomerFormViewModel {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm",viewModel);

        }
        // GET: Customers
        public ViewResult Index()
        {
            var customers = _context.Customer.Include(c => c.MembershipType).ToList();

            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customer.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
        
    }
}