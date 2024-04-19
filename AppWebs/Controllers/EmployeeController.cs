using AppWebs.Data;
using AppWebs.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppWebs.Controllers;

public class EmployeeController(ApplicationDbContext context) : Controller
{
    public IActionResult Index()
    {
        IEnumerable<Employees> employees = context.Employees;
        return View(employees);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Employees employee)
    {
        if (!ModelState.IsValid) return View(employee);

        context.Employees.Add(employee);
        context.SaveChanges();

        TempData["Message"] = "Employee created successfully";

        return RedirectToAction("Index");
    }

    public IActionResult Details(int? id, bool isEdit = false, bool isDelete = false)
    {
        if (id is null or 0)
        {
            return NotFound();
        }
        var employee = context.Employees.Find(id);
        if (employee == null)
        {
            return NotFound();
        }
        ViewBag.IsEdit = isEdit;
        ViewBag.IsDelete = isDelete;

        return View(employee);
    }

    public IActionResult Edit(int? id)
    {
        if (id is null or 0)
        {
            return NotFound();
        }
        var employee = context.Employees.Find(id);
        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Employees employee)
    {
        if (!ModelState.IsValid) return View(employee);
        context.Employees.Update(employee);
        context.SaveChanges();

        TempData["Message"] = "Employee updated successfully";

        return RedirectToAction("Index");

    }
    public IActionResult Delete(int? id)
    {
        if (id is null or 0)
        {
            return NotFound();
        }

        var employee = context.Employees.Find(id);
        if (employee == null)
        {
            return NotFound();
        }

        context.Employees.Remove(employee);
        context.SaveChanges();
        TempData["Message"] = "Employee deleted successfully";
        return RedirectToAction("Index");
    }

}