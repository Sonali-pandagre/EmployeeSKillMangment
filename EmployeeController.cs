using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Employeeskillmanagment.Data;
using Employeeskillmanagment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Employeeskillmanagment.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db) => _db = db;
        public IActionResult Index()
        {
            List<Employee> employeeEmployeeList = _db.Employees.ToList();
            return View(employeeEmployeeList);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee employee)

        {
            _db.Employees.Add(employee);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
         
          public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
          
            if (ModelState.IsValid)
            {
                _db.Employees.Update(employee);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }


    }

}

