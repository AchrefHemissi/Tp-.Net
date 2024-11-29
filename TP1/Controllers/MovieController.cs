using Microsoft.AspNetCore.Mvc;
using TP1.Models;
using TP1.Models.ViewModels;

namespace TP1.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            Movie movie = new Movie()
            {
                Name = "movie 1"
            };
            List<Movie> movies = new List<Movie>()
                {
                    new Movie{Name="movie 2"},
                    new Movie{Name="movie 3"},
                };
            return View(movies);
        }

        public IActionResult Edit(int id)
        {
            return Content("Test Id" + id);
        }

        [Route("Movie/released/{year}/{month}")]
        public IActionResult ByRelease(int year, int month)
        {
            return Content($"Movies released in {month}/{year}");
        }

        [Route("Movie/released/2024/11")]
        public IActionResult SpecificRelease()
        {
            return Content("Movies released in November 2024");
        }

        public IActionResult Details()
        {
            var movie = new Movie { Id = 1, Name = "Inception" };

            var customers = new List<Customer> {
                new Customer { Id = 1, Name = "Alice" },
                new Customer { Id = 2, Name = "Bob" }
             };

            var viewModel = new MovieCustomerViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public IActionResult CustomerDetails(int id)
        {
            var customers = new List<Customer>
    {
        new Customer { Id = 1, Name = "Alice" },
        new Customer { Id = 2, Name = "Bob" }
    };

            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null) return NotFound();

            return Content($"Customer Details: {customer.Name}");
        }


    }

}
