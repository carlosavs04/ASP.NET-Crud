using AppWebs.Data;
using AppWebs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AppWebs.Controllers
{
    public class LocationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Locations> locations = _context.Locations.Include(l => l.Countries).ToList();
            return View(locations);
        }

        public IActionResult Create()
        {
            var countries = _context.Countries.ToList();
            ViewBag.Countries = new SelectList(countries, "CountryId", "CountryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Locations location)
        {
            if (ModelState.IsValid)
            {
                _context.Locations.Add(location);
                _context.SaveChanges();

                TempData["Message"] = "Location created successfully";

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Details(int? id, bool isEdit = false, bool isDelete = false)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var location = _context.Locations.Include(c => c.Countries).FirstOrDefault(l => l.LocationId == id);
            if (location == null)
            {
                return NotFound();
            }
            ViewBag.IsEdit = isEdit;
            ViewBag.IsDelete = isDelete;

            return View(location);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var location= _context.Locations.Find(id);

            if (location == null)
            {
                return NotFound();
            }

            var countries = _context.Countries.ToList();
            ViewBag.Countries = new SelectList(countries, "CountryId", "CountryName", location.CountryId);

            return View(location);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Locations locations)
        {
            if (ModelState.IsValid)
            {
                _context.Locations.Update(locations);
                _context.SaveChanges();

                TempData["Message"] = "Location updated successfully";

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult DeleteLocation(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var location = _context.Locations.Find(id);
            if (location == null)
            {
                return NotFound();
            }

            _context.Locations.Remove(location);
            _context.SaveChanges();
            TempData["Message"] = "Location deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
