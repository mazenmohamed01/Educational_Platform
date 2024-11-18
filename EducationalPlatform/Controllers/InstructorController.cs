using EducationalPlatform.Models;
using EducationalPlatform.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace EducationalPlatform.Controllers
{
    public class InstructorController : Controller
    {
        EducationalPlatformContext db = new EducationalPlatformContext();


        public InstructorController(IHostingEnvironment host)
        {
            _host = host;
        }
        private readonly IHostingEnvironment _host;

        //open Epty Form
        [HttpGet]
        public IActionResult New()
        {
            return View(new Instructor());
        }


        [HttpPost("/AddInstructor/")]
        public IActionResult SaveNew(Instructor newinstructor)
        {
            if (ModelState.IsValid)
            {
                string fileName = string.Empty;
                if (newinstructor.clientFile != null)
                {
                    try
                    {
                        string muupload = Path.Combine(_host.WebRootPath, "Images");
                        fileName = newinstructor.clientFile.FileName;
                        string fullpath = Path.Combine(muupload, fileName);
                        newinstructor.clientFile.CopyTo(new FileStream(fullpath, FileMode.Create));
                        newinstructor.Image = fileName;
                    }
                    catch
                    {
                        newinstructor.Image = newinstructor.clientFile.FileName;
                    }
                }

                db.Instructors.Add(newinstructor);
                db.SaveChanges();
                return RedirectToAction("New");
            }
            else
            {
                return View("New", newinstructor);
            }
        }


        public IActionResult EditView(int id , string name)
        {
            ViewBag.view = name;
            var item = db.Instructors.SingleOrDefault(c => c.Id == id);
            return View(item);
        }

        public IActionResult saveEdit(int id, Instructor Instructor , string name)
        {
            var item = db.Instructors.FirstOrDefault(c => c.Id == id);
            if (ModelState.IsValid && item != null)
            {
                string fileName = string.Empty;
                if (Instructor.clientFile != null)
                {
                    try
                    {
                        string muupload = Path.Combine(_host.WebRootPath, "Images");
                        fileName = Instructor.clientFile.FileName;
                        string fullpath = Path.Combine(muupload, fileName);
                        Instructor.clientFile.CopyTo(new FileStream(fullpath, FileMode.Create));
                        Instructor.Image = fileName;
                    }
                    catch
                    {
                        Instructor.Image = Instructor.clientFile.FileName;
                    }
                }
                item.FullName = Instructor.FullName;
                if (Instructor.Image != null)
                    item.Image = Instructor.Image;
                item.Email = Instructor.Email;
                item.Password = Instructor.Password;
                item .Gender = Instructor.Gender;

                db.SaveChanges();
            }
            if (name == "admin")
                return RedirectToAction("AdminViw", "admin");
            else
                return RedirectToAction("MyProfile", "Instructor", new { id = item.Id });

        }
        public IActionResult Delete(int id)
        {
            var i = db.Instructors.SingleOrDefault(c => c.Id == id);
            if (i != null)
            {
                
                i.IsDelete = "true";
                db.SaveChanges();
            }
            return RedirectToAction("AdminViw", "admin");
        }

        public IActionResult Profile(int id , string viewna)
        {
            ViewBag.view = viewna;
            var instructor = db.Instructors
                .Include(i => i.Courses)
                .FirstOrDefault(i => i.Id == id);
            var allcourses = db.Courses.Where(i => i.InstructorId == id && i.IsDelete == "false").ToList();

           

            var viewModel = new InstructorProfileViewModel
            {
                InstructorId = instructor.Id,
                FullName = instructor.FullName,
                Email = instructor.Email,
                JoinDate = instructor.JoinDate,
                Courses = allcourses,
            };

            return View(viewModel);
        }

        public IActionResult ProfileForStudent(int id , int stud_id)
        {
            ViewBag.stud_id = stud_id;   
            var instructor = db.Instructors
                .Include(i => i.Courses)
                .FirstOrDefault(i => i.Id == id);
            var allcourses = db.Courses.Where(i => i.InstructorId == id && i.IsDelete == "false").ToList();

           

            var viewModel = new InstructorProfileViewModel
            {
                InstructorId = instructor.Id,
                FullName = instructor.FullName,
                Email = instructor.Email,
                JoinDate = instructor.JoinDate,
                Courses = allcourses,
            };

            return View(viewModel);
        }

        public IActionResult Home(int id)
        {
            ViewBag.id = id;
            ViewBag.AllCategories = db.Categories.Where(x => x.IsDelete == "false").ToList();
            ViewBag.AllInstructors = db.Instructors.Where(x => x.IsDelete == "false").ToList();
            return View();
        }
        public IActionResult MyProfile(int id)
        {
            ViewBag.id = id;
            var instructor = db.Instructors
                .Include(i => i.Courses)
                .FirstOrDefault(i => i.Id == id);
            var allcourses = db.Courses.Where(i => i.InstructorId == id && i.IsDelete == "false").ToList();



            var viewModel = new InstructorProfileViewModel
            {
                InstructorId = instructor.Id,
                Image = instructor.Image,
                FullName = instructor.FullName,
                Email = instructor.Email,
                JoinDate = instructor.JoinDate,
                Courses = allcourses,
            };

            return View(viewModel);
        }

    }
}


