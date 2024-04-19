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
        public async Task<ActionResult<Inventories>> CreateOrUpdate(Inventories inventories)
        {
            var inventory = await _context.Inventories.FirstOrDefaultAsync(i => i.ProductId == inventories.ProductId && i.WarehouseId == inventories.WarehouseId);

            if (inventory != null)
            {
                if (ModelState.IsValid)
                {
                    _context.Entry(inventory).CurrentValues.SetValues(inventories);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "Inventory updated successfully";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _context.Inventories.Add(inventories);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "Inventory created successfully";
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        public async Task<ActionResult<Inventories>> Details(int productId, int warehouseId, bool isDelete = false)
        {
            var inventory = await _context.Inventories.Include(w => w.Warehouses).Include(p => p.Products).FirstOrDefaultAsync(i => i.ProductId == productId && i.WarehouseId == warehouseId);
            
            if (inventory == null)
            {
                return NotFound();
            }
            ViewBag.IsDelete = isDelete;

            return View(inventory);
        }

        public async Task<ActionResult<Inventories>> DeleteInventory(int productId, int warehouseId)
        {
           var inventory = await _context.Inventories.FirstOrDefaultAsync(i => i.ProductId == productId && i.WarehouseId == warehouseId);
           if (inventory == null)
            {
               return NotFound();
           }
           _context.Inventories.Remove(inventory);
            await _context.SaveChangesAsync();
            TempData["Message"] = "Inventory deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
