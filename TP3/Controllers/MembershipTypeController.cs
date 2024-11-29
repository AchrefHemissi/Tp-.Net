using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP3.Models;

namespace TP3.Controllers
{
    public class MembershipTypeController : Controller
    {

        private readonly AppDbContext _db;

        public MembershipTypeController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var MembershipTypes = _db.MembershipTypes.ToList();
            return View(MembershipTypes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MembershipType membership)
        {
            _db.MembershipTypes.Add(membership);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}
