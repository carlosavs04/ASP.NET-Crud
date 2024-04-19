using AppWebs.Data;
using AppWebs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AppWebs.Controllers
{
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Inventories> inventories = _context.Inventories.Include(w => w.Warehouses).Include(p => p.Products).ToList();
            return View(inventories);
        }

        public IActionResult Create()
        {
            var products = _context.Products.ToList();
            var warehouses = _context.Warehouses.ToList();
            ViewBag.Products = new SelectList(products, "ProductId", "ProductName");
            ViewBag.Warehouses = new SelectList(warehouses, "WarehouseId", "WarehouseName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Inventories inventories)
        {
            if (ModelState.IsValid)
            {

                    _context.Inventories.Add(inventories);
                    _context.SaveChanges();
                    TempData["Message"] = "Inventory created successfully";
                    return RedirectToAction("Index");
                
            }

            return View();
        }
    }
}
