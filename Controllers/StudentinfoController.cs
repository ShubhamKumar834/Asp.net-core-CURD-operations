using Microsoft.AspNetCore.Mvc;
using ShubhamDhimanWebApp1.Data;
using ShubhamDhimanWebApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShubhamDhimanWebApp1.Controllers
{
    public class StudentinfoController : Controller
    {

        StudentDataContext studentDataContext;

        public StudentinfoController(StudentDataContext studentContext)
        {
            studentDataContext = studentContext;
        }
        public IActionResult GetAllData()
        {
            var Stud = studentDataContext.StudentsData.ToList();
            return View(Stud);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddnewStudent(StudentData Student)
        {
            var allready = studentDataContext.StudentsData.SingleOrDefault(all => all.RollNumber==Student.RollNumber);
            if (allready != null)
            {
                string msg = "Rollnumber Allready Exixts.";
                ViewBag.message = msg;
            }
            else if (ModelState.IsValid)
            {
                studentDataContext.StudentsData.Add(Student);
                studentDataContext.SaveChanges();
                return RedirectToAction("GetAllData");
            }
                
            return View("Create");
        }
    
        [HttpGet]
        public IActionResult StudentDetail(int id)
        {
            var detail = studentDataContext.StudentsData.SingleOrDefault(d => d.ID == id);
            return View(detail);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Stud = studentDataContext.StudentsData.SingleOrDefault(Stu => Stu.ID == id);
            return View(Stud);
        }

        [HttpPost]
        public IActionResult EditStudent(StudentData Student)
        {
            if (ModelState.IsValid)
            {
                studentDataContext.StudentsData.Update(Student);
                studentDataContext.SaveChanges();
                return RedirectToAction("GetAllData");
            }
            return View("Edit");
        }
       
        public IActionResult DeleteStudentInfo(int id)
        {
            var Stud = studentDataContext.StudentsData.SingleOrDefault(Stu => Stu.ID == id);
            studentDataContext.StudentsData.Remove(Stud);
            studentDataContext.SaveChanges();
            return RedirectToAction("GetAllData");
        }
        
    }
}
