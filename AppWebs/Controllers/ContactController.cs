using AppWebs.Data;
using AppWebs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AppWebs.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Contacts> contacts = _context.Contacts.Include(c => c.Customers).ToList();
            return View(contacts);
        }

        public IActionResult Create()
        {
            var customers = _context.Customers.ToList();
            ViewBag.Customers = new SelectList(customers, "CustomerId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contacts contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(contact);
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
            var contact = _context.Contacts.Include(c => c.Customers).FirstOrDefault(c => c.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }
            ViewBag.IsEdit = isEdit;
            ViewBag.IsDelete = isDelete;

            return View(contact);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            var customers = _context.Customers.ToList();
            ViewBag.Customers = new SelectList(customers, "CustomerId", "Name", contact.CustomerId);

            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Contacts contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Update(contact);
                _context.SaveChanges();

                TempData["Message"] = "Contact updated successfully";

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult DeleteContact(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            TempData["Message"] = "Contact deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
