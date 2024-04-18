using AppWebs.Data;
using AppWebs.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppWebs.Controllers
{
    public class ProductCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Product_Categories> categories = _context.Product_Categories;
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product_Categories categories)
        {
           if (ModelState.IsValid)
           {
                _context.Product_Categories.Add(categories);
                _context.SaveChanges();

                TempData["Message"] = "Customer created successfully";

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
            var categories = _context.Product_Categories.Find(id);
            if (categories == null)
            {
                return NotFound();
            }
            ViewBag.IsEdit = isEdit;
            ViewBag.IsDelete = isDelete;

            return View(categories);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categories = _context.Product_Categories.Find(id);
            if (categories == null)
            {
                return NotFound();
            }
 
            return View(categories);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product_Categories categories)
        {
            if (ModelState.IsValid)
            {
                _context.Product_Categories.Update(categories);
                _context.SaveChanges();

                TempData["Message"] = "Customer updated successfully";  

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categories = _context.Product_Categories.Find(id);
            if (categories == null)
            {
                return NotFound();
            }
            _context.Product_Categories.Remove(categories);
            _context.SaveChanges();
            TempData["Message"] = "Customer deleted successfully";

            return RedirectToAction("Index");
        }
    }


}
