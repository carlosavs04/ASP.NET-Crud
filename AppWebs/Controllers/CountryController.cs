using AppWebs.Data;
using AppWebs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AppWebs.Controllers
{
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Countries> countries = _context.Countries.Include(c => c.Regions).ToList();
            return View(countries);
        }

        public IActionResult Create()
        {
            var regions = _context.Regions.ToList();
            ViewBag.Regions = new SelectList(regions, "RegionId", "RegionName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Countries country)
        {
            if (ModelState.IsValid)
            {
                if (_context.Countries.Any(c => c.CountryId == country.CountryId))
                {
                    ModelState.AddModelError("CountryId", "Country Id already exists");
                    var regions = _context.Regions.ToList();
                    ViewBag.Regions = new SelectList(regions, "RegionId", "RegionName");
                    return View();
                }

                _context.Countries.Add(country);
                _context.SaveChanges();

                TempData["Message"] = "Country created successfully";

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Details(string? id, bool isEdit = false, bool isDelete = false)
        {
            if (id == null)
            {
                return NotFound();
            }
            var country = _context.Countries.Include(c => c.Regions).FirstOrDefault(c => c.CountryId == id);
            if (country == null)
            {
                return NotFound();
            }
            ViewBag.IsEdit = isEdit;
            ViewBag.IsDelete = isDelete;

            return View(country);
        }

        public IActionResult Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var country = _context.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }

            var regions = _context.Regions.ToList();
            ViewBag.Regions = new SelectList(regions, "RegionId", "RegionName", country.RegionId);
            return View(country);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Countries country)
        {
            if (ModelState.IsValid)
            {
                _context.Countries.Update(country);
                _context.SaveChanges();

                TempData["Message"] = "Country updated successfully";

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult DeleteCountry(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var country = _context.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            _context.SaveChanges();
            TempData["Message"] = "Country deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
