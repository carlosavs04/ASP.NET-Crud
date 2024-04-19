using AppWebs.Data;
using AppWebs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AppWebs.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Products> contacts = _context.Products.Include(c => c.Product_Categories).ToList();
            return View(contacts);
        }

        public IActionResult Create()
        {
            var customers = _context.Products.ToList();
            ViewBag.Products = new SelectList(customers, "ProductId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Products contact)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(contact);
                _context.SaveChanges();

                TempData["Message"] = "Contact created successfully";

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
            var product = _context.Products.Include(c => c.Product_Categories).FirstOrDefault(c => c.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.IsEdit = isEdit;
            ViewBag.IsDelete = isDelete;

            return View(product);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var contact = _context.Products.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            var customers = _context.Products.ToList();
            ViewBag.Products = new SelectList(customers, "ProductId", "Name");  

            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Products contact)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(contact);
                _context.SaveChanges();

                TempData["Message"] = "Contact updated successfully";

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult DeleteProduct(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var contact = _context.Products.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            _context.Products.Remove(contact);
            _context.SaveChanges();
            TempData["Message"] = "Contact deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
