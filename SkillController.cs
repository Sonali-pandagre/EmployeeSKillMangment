using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employeeskillmanagment.Data;
using Employeeskillmanagment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employeeskillmanagment.Controllers
{
    public class SkillController: Controller
    {
       private readonly ApplicationDbContext _db;

       public SkillController(ApplicationDbContext db) => _db = db;

        public IActionResult Index()
        {
            List<Skill> objSkillList = _db.Skills.ToList();
            return View(objSkillList);
        }

        public IActionResult Edit(int id)
        {
 
            Skill? Skill = _db.Skills.Find(id);
            return View(Skill);
        }
        [HttpPost]
        public IActionResult Edit(Skill obj)
        {
 
            if (ModelState.IsValid)
            {
                _db.Skills.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "skill updated successfully";
                return RedirectToAction("Index");
            }
            return View();
 
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Skill obj)
        {
 
            if (ModelState.IsValid)
            {
              List<Skill> Skills = _db.Skills.ToList();
              if(Skills.Any(s=>s.SkillName == obj.SkillName)){
                TempData["error"] = "Skill already exists";
                return View();
 
              }
                _db.Skills.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "skill Added successfully";
                return RedirectToAction("Index");
            }
            return View();
 
        }
        // #region API CALLS
 
        //  [HttpDelete]
        //  public IActionResult Delete(int? id)
        // {
        //     var skillToBeDeleted = _unitOfWork.Skill.Get(u => u.Id == id);
        //     if (skillToBeDeleted == null)
        //     {
        //          return Json(new { success = false, message = "Error while deleting" });
        //     }
             
        //      _unitOfWork.Skill.Remove(skillToBeDeleted);
        //     _unitOfWork.Save();
        //      return Json(new { success = true, message = "Delete Successful" });
        // }
        // #endregion
    }
}