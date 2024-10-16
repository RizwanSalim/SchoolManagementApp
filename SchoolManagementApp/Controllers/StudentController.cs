using Microsoft.AspNetCore.Mvc;
using SchoolManagementApp.Business;
using SchoolManagementApp.Models;
using System.Collections.Generic;

namespace SchoolManagementApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            var model = new Student { Qualifications = new List<Qualification> { new Qualification() } };
            ViewBag.Students = _studentService.GetAllStudents();
            return View(model);
        }

        [HttpPost]
        public IActionResult Register(Student student)
        {
            if (ModelState.IsValid)
            {
                
                _studentService.RegisterStudent(student);

               
                ViewBag.Students = _studentService.GetAllStudents();

               
                ModelState.Clear(); 
                var newModel = new Student { Qualifications = new List<Qualification> { new Qualification() } };
                return View(newModel);
            }

            
            ViewBag.Students = _studentService.GetAllStudents();
            return View(student);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Student student)
        {
           
                return RedirectToAction("Register");
  
        }

    }
}
