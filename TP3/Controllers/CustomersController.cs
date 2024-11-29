using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP3.Models;


namespace TP3.Controllers
{
    public class CustomersController : Controller
    {
        private readonly AppDbContext _db;

        public CustomersController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var customers = _db.Customers
                                .Include(c => c.MembershipType)  // Eagerly load MembershipType
                                .ToList();
            return View(customers);
        }

        private void PopulateMembershipTypes()
        {
            var members = _db.MembershipTypes.ToList();
            ViewBag.member = members.Select(m => new SelectListItem
            {
                Text = m.Name,
                Value = m.Id.ToString()
            }).ToList();
        }

        public IActionResult Create()
        {
            PopulateMembershipTypes();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customers customer)
        {
            // Check if MembershipTypeId is valid and populate the MembershipType
            if (customer.MembershipTypeId >=0) 
            {
                var membershipType = _db.MembershipTypes.FirstOrDefault(m => m.Id == customer.MembershipTypeId);

                if (membershipType != null)
                {
                    customer.MembershipType = membershipType; // Assign the MembershipType to the customer object
                }
            }

            // Initialize an empty list of Movies (if needed)
            customer.Movies = new List<Movies>();

            // If we don't want to validate navigation properties, clear the validation for them
            ModelState.Remove("MembershipType");
            ModelState.Remove("Movies");


            // Validate the model state
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values
                .SelectMany(v => v.Errors) // Flatten all error collections from ModelState.Values
                .Select(e => e.ErrorMessage) // Extract only the error messages
                .ToList(); // Convert to a list

                PopulateMembershipTypes();

                // Return the view with the model containing validation errors
                return View(customer);
            }

            // If the model is valid, proceed with saving the customer
            customer.Customerid = Guid.NewGuid(); // Generate a new GUID for the customer
            _db.Customers.Add(customer); // Add the customer to the database
            _db.SaveChanges(); // Save the changes

            // Redirect to the Index action to show the updated list of customers
            return RedirectToAction(nameof(Index));
        }

    }
}