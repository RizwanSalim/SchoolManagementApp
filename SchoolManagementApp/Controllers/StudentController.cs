using Microsoft.AspNetCore.Http;
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
            var username = HttpContext.Session.GetString("Username");
            var password = HttpContext.Session.GetString("Password");

            var model = new Student { Qualifications = new List<Qualification> { new Qualification() },
                Username = username, 
                Password = password  
            };
            ViewBag.Students = _studentService.GetAllStudents();
            return View(model);
        }

        [HttpPost]
        public IActionResult Register(Student student)
        {
            if (ModelState.IsValid)
            {
                var username = HttpContext.Session.GetString("Username");
                var password = HttpContext.Session.GetString("Password");
                _studentService.RegisterStudent(student);

               
                ViewBag.Students = _studentService.GetAllStudents();

               
                ModelState.Clear(); 
                var newModel = new Student { Qualifications = new List<Qualification> { new Qualification() },
                    Username = username,
                    Password = password
                };
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
            if (!string.IsNullOrEmpty(student.Username) && !string.IsNullOrEmpty(student.Password))
            {
               
                HttpContext.Session.SetString("Username", student.Username);
                HttpContext.Session.SetString("Password", student.Password);

                return RedirectToAction("Register");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(student);
        }

    }
}
