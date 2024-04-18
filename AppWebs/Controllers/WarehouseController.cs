using AppWebs.Data;
using AppWebs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;



namespace AppWebs.Controllers
{
    public class WarehouseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WarehouseController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Warehouses> warehouses = _context.Warehouses.Include(l => l.Locations).ToList();
            return View(warehouses);
        }

        public IActionResult Create()
        {
            var locations = _context.Locations.ToList();
            ViewBag.Locations = new SelectList(locations, "LocationId", "City");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Warehouses warehouses)
        {
            if (ModelState.IsValid)
            {
                _context.Warehouses.Add(warehouses);
                _context.SaveChanges();

                TempData["Message"] = "Warehouse created successfully";

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
            var warehouse = _context.Warehouses.Include(l => l.Locations).FirstOrDefault(w => w.WarehouseId == id);
            if (warehouse == null)
            {
                return NotFound();
            }
            ViewBag.IsEdit = isEdit;
            ViewBag.IsDelete = isDelete;

            return View(warehouse);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var warehouse = _context.Warehouses.Find(id);

            if (warehouse == null)
            {
                return NotFound();
            }

            var locations = _context.Locations.ToList();
            ViewBag.Locations = new SelectList(locations, "LocationId", "City");

            return View(warehouse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Warehouses warehouse)
        {
            if (ModelState.IsValid)
            {
                _context.Warehouses.Update(warehouse);
                _context.SaveChanges();

                TempData["Message"] = "Warehouse updated successfully";

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult DeleteWarehouse(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var warehouse = _context.Warehouses.Find(id);
            if (warehouse == null)
            {
                return NotFound();
            }

            _context.Warehouses.Remove(warehouse);
            _context.SaveChanges();
            TempData["Message"] = "Location deleted successfully";
            return RedirectToAction("Index");
        }
    }
}

