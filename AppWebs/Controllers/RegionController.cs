using AppWebs.Data;
using AppWebs.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppWebs.Controllers
{
    public class RegionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Regions> regions = _context.Regions;
            return View(regions);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Regions region)
        {
            if (ModelState.IsValid)
            {
                _context.Regions.Add(region);
                _context.SaveChanges();

                TempData["Message"] = "Region created successfully";

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
            var region = _context.Regions.Find(id);
            if (region == null)
            {
                return NotFound();
            }
            ViewBag.IsEdit = isEdit;
            ViewBag.IsDelete = isDelete;

            return View(region);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var region = _context.Regions.Find(id);
            if (region == null)
            {
                return NotFound();
            }

            return View(region);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Regions region)
        {
            if (ModelState.IsValid)
            {
                _context.Regions.Update(region);
                _context.SaveChanges();

                TempData["Message"] = "Region updated successfully";

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult DeleteRegion(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var region = _context.Regions.Find(id);
            if (region == null)
            {
                return NotFound();
            }

            _context.Regions.Remove(region);
            _context.SaveChanges();
            TempData["Message"] = "Region deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
