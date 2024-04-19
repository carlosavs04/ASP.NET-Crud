using AppWebs.Data;
using AppWebs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AppWebs.Controllers;

public class OrdersController : Controller
{
     private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Orders> orders = _context.Orders.Include(o => o.Customers).Include(o => o.Employees);
            return View(orders);
        }

        public IActionResult Create()
        {
            var customers = _context.Customers.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.CustomerId.ToString()
            }).ToList();

            var employees = _context.Employees.Select(e => new SelectListItem
            {
                Text = e.FirstName,
                Value = e.EmployeeId.ToString()
            }).ToList();

            ViewBag.Customers = customers;
            ViewBag.Employees = employees;


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Orders order)
        {
            if (!ModelState.IsValid) return View(order);

            _context.Orders.Add(order);
            _context.SaveChanges();

            TempData["Message"] = "Order created successfully";

            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id, bool isEdit = false, bool isDelete = false)
        {
            if (id is null or 0)
            {
                return NotFound();
            }

            var order = _context.Orders.Include(o => o.Customers).Include(o => o.Employees).FirstOrDefault(o => o.OrderId == id);

            if (order == null)
            {
                return NotFound();
            }

            ViewBag.IsEdit = isEdit;
            ViewBag.IsDelete = isDelete;


            return View(order);
        }

        public IActionResult Edit(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }

            var order = _context.Orders.Find(id);

            if (order == null)
            {
                return NotFound();
            }


            var customers = _context.Customers.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.CustomerId.ToString()
            }).ToList();

            var employees = _context.Employees.Select(e => new SelectListItem
            {
                Text = e.FirstName,
                Value = e.EmployeeId.ToString()
            }).ToList();

            ViewBag.Customers = customers;
            ViewBag.Employees = employees;

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Orders order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(order);

            _context.Orders.Update(order);
            _context.SaveChanges();

            TempData["Message"] = "Order updated successfully";

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }

            var order = _context.Orders.Find(id);

            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            _context.SaveChanges();
            TempData["Message"] = "Order deleted successfully";
            return RedirectToAction("Index");
        }

}