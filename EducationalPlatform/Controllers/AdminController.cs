using EducationalPlatform.Models;
using EducationalPlatform.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace EducationalPlatform.Controllers
{
    public class AdminController : Controller
    {
        EducationalPlatformContext db = new EducationalPlatformContext();
        [Route("/loginView/")]
        public IActionResult loginView()
        {
            return View();


        }

        [HttpPost("login")]

        public IActionResult login(string Email, string password)
        {
            var instructor = db.Instructors.SingleOrDefault
                (x => x.Email == Email && x.Password == password && x.IsDelete =="false");
            var check = db.Admins.SingleOrDefault
                (x => x.Email == Email && x.Password == password );
            var check2 = db.Students.SingleOrDefault
                (x => x.Email == Email && x.Password == password && x.IsDelete == "false");
            if (check != null)
            {
                return RedirectToAction("AdminViw", "Admin");

            }
            else if (check2 != null)
            {
                return RedirectToAction("home", "student" , new {id = check2.Id});
            }
            else if (instructor != null)
            {
                return RedirectToAction("MyProfile", "Instructor", new { id = instructor.Id });
            }
            else
            {
                return RedirectToAction("loginView");

            }


        }
        [Route("/forgot/")]
        public IActionResult forgotPasswerdView()
        {
            return View();
        }
        [Route("/checkPhone/")]
        public IActionResult forgotCheck(string Phone)
        {
            var Check = db.Admins.SingleOrDefault(x => x.Phone == Phone);
            var check2 = db.Students.SingleOrDefault(x => x.Phone == Phone);

            if (Check != null)
            {
                return RedirectToAction("AdminViw", "Admin");

            }
            else if (check2 != null)
            {
                return RedirectToAction("Index", "home" );
            }
            else
            {
                return RedirectToAction("loginView");

            }
        }
        //[Authorize(Roles = "Admin")]
        public IActionResult AdminViw()
        {
            ViewBag.category = db.Categories.Where(x=> x.IsDelete == "false").ToList();
            ViewBag.students = db.Students.Where(x => x.IsDelete == "false").ToList();
            //ViewBag.category = db.Categories.ToList();
            ViewBag.cou = db.Courses.Where(x => x.IsDelete == "false").ToList();

            List<coursesModel> coursesModels = new List<coursesModel>();
            var f = db.Courses.Include(i => i.Instructor).Include(i => i.Cate).Where(x => x.IsDelete == "false")
                .Select(i => new coursesModel
                {
                    Id=i.Id,
                    CourseName = i.CourseName,
                    Price = i.Price,
                    Level = i.Level,    
                    CreationDate = i.CreationDate,
                    Content = i.Content,
                    Hours = i.Hours,
                    student_nuber = i.Regestrations.Count,
                }).ToList();    

            ViewBag.f = f;

            var insts = db.Instructors.Where(x => x.IsDelete == "false").ToList();
            return View(insts);

        }
        //[HttpGet]
        //[Route("/AdminViewTables/")]
        public IActionResult AdminViwe(int id)
        {
            ViewBag.cours_search = db.Courses.Where((x) => x.Id == id && x.IsDelete == "false")
                .FirstOrDefault().CourseName;
            ViewBag.category = db.Categories.Where(x => x.IsDelete == "false").ToList();
            ViewBag.students = db.Regestrations.Include(i => i.Student)
                .Where(i => i.CourseId == id).Select(i => i.Student).ToList();
            //ViewBag.category = db.Categories.ToList();
            ViewBag.cou = db.Courses.Where(x => x.IsDelete == "false").ToList();

            List<coursesModel> coursesModels = new List<coursesModel>();
            var f = db.Courses.Include(i => i.Instructor).Include(i => i.Cate).Where(x => x.IsDelete == "false")
                .Select(i => new coursesModel
                {
                    Id = i.Id,
                    CourseName = i.CourseName,
                    Price = i.Price,
                    Level = i.Level,
                    CreationDate = i.CreationDate,
                    Content = i.Content,
                    Hours = i.Hours,
                    student_nuber = i.Regestrations.Count,
                }).ToList();

            ViewBag.f = f;

            var insts = db.Instructors.Where(x => x.IsDelete == "false").ToList();
            return View(insts);

        }


        public IActionResult ProfileData()//view Data
        {
            Admin admin = db.Admins.First();
            return View(admin);
        }

        [Route("/SaveEdit/")]
        public IActionResult SaveEdit(Admin newadmin)
        {
            Admin oldinAdmin = db.Admins.FirstOrDefault();
            if (newadmin != null)
            {

                if (oldinAdmin != null)
                {
                    oldinAdmin.FullName = newadmin.FullName;
                    oldinAdmin.Email = newadmin.Email;
                    oldinAdmin.Password = newadmin.Password;
                    oldinAdmin.Phone = newadmin.Phone;
                    db.SaveChanges();

                }
            }
            return RedirectToAction("ProfileData", "Admin", oldinAdmin);
        }

        [Route("/AdminHome/")]
        public IActionResult Home()
        {
            ViewBag.AllCategories = db.Categories.Where(x => x.IsDelete == "false").ToList();
            ViewBag.AllInstructors = db.Instructors.Where(x => x.IsDelete == "false").ToList();
            return View();
        }

    }
}
