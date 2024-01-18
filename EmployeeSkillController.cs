using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Employeeskillmanagment.Data;
using Employeeskillmanagment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employeeskillmanagment.Controllers;


// [ApiController]
// [Route("api/[controller]")]
public class EmployeeSkillController : Controller
{
  private readonly ApplicationDbContext _db;
  public EmployeeSkillController(ApplicationDbContext db) => _db = db;

  public IActionResult Index()
  {
    List<EmployeeSkill> objEmployeeSkillList = _db.EmployeeSkills.ToList();
    return View(objEmployeeSkillList);
  }


  [HttpPost]
  public IActionResult Create([FromBody] EmployeeSkill obj)
  {
    IEnumerable<EmployeeSkill> EmployeeSkills = _db.EmployeeSkills.Where(u => u.EmployeeId == obj.EmployeeId);
    if (ModelState.IsValid)
    {
      if (EmployeeSkills.Any(es => es.SkillId == obj.SkillId))
      {
        TempData["message"] = "Skill already exists for the employee";
        return Conflict(new { message = "Skill already exists for the employee" });
      }
      _db.EmployeeSkills.Add(obj);
      _db.SaveChanges();
      TempData["success"] = "Skill added successfully";
      return Ok(new { message = "Skill added successfully" });
    }
    else
    {
      // TempData["error"] = "Invalid data";
      return BadRequest(new { message = "Invalid data" });
    }


  }

  public IActionResult AssignSkill(){
    List<Skill> skills = _db.Skills.ToList();
    return View(skills);
  }


}
// public IActionResult Edit(int employeeId)
// {

//     Employee Employee = _db.Employees.Find(employeeId);
//     EmployeeSkillVM EmployeeWithSkills = new()
//     {
//             Employee = Employee                    
//         ,
//         EmployeeSkills = _db.EmployeeSkills.Where(u=>u.EmployeeId == employeeId),
//     };
//        return View(EmployeeWithSkills);
//    }





