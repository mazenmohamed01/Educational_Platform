using EducationalPlatform.Models;
using EducationalPlatform.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace EducationalPlatform.Controllers
{
    public class StudentController : Controller
    {
        EducationalPlatformContext db = new EducationalPlatformContext();


        
        public IActionResult Home( int id)
        {
            ViewBag.id = id;
            ViewBag.AllCategories = db.Categories.Where(x => x.IsDelete == "false").ToList();
            ViewBag.AllInstructors = db.Instructors.Where(x => x.IsDelete == "false").ToList();
            return View();
        }


        [Route("/CreateViewStudent/")]
        public IActionResult createView()
        {
            return View();
        }

        [Route("/CreateStudent/")]
        public IActionResult createAction(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Home" , new { id =student.Id });
            }
            else
            {
                return RedirectToAction("createView");
            }
        }

        //[Authorize]
        public IActionResult Edit(int id)
        {
            //ViewBag.name = User.Identity.Name;
            Student student = db.Students.FirstOrDefault(i => i.Id == id);
            return View(student);
        }
        public IActionResult SaveEdit(int id, Student newStudent)
        {
            if (ModelState.IsValid)
            {
                Student oldstudent = db.Students.FirstOrDefault(i => i.Id == id);
                if (oldstudent != null)
                {
                    oldstudent.FullName = newStudent.FullName;
                    oldstudent.Email = newStudent.Email;
                    oldstudent.Password = newStudent.Password;
                    oldstudent.Phone = newStudent.Phone;
                    oldstudent.Gender = newStudent.Gender;
                    oldstudent.BirthDay = newStudent.BirthDay;

                    db.SaveChanges();
                    return RedirectToAction("Profile", newStudent);
                }
            }
            return View("Edit", newStudent);
        }

        public IActionResult Profile(int id)
        {
            // Fetch the student data along with their registered courses
            var student = db.Students
                .Include(s => s.Regestrations)
                    .ThenInclude(r => r.Course).ThenInclude(i=> i.Instructor) // Assuming you have navigation properties set up
                .FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            // Prepare the courses for the view model
            
            var registeredCourses = student.Regestrations.Select(r => new CourseViewModel
            {
                student_id = student.Id,
                courseId = r.CourseId,
                Image = r.Course.Image, // Assuming Course has an Image property
                CourseName = r.Course.CourseName,
                Description = r.Course.Description,
                Price = r.Course.Price,
                Level = r.Course.Level,
                InstructorName = r.Course.Instructor.FullName,
            }).ToList();

            var model = new StudentProfileViewModel
            {
                StudentId = student.Id,
                FullName = student.FullName,
                Email = student.Email,
                JoinDate = student.JoinDate,
                Gender = student.Gender,
                RegisteredCourses = registeredCourses
            };

            return View(model);
        }

        public IActionResult StudentById(int id)
        {
            var student = db.Regestrations.Include(i=>i.Student)
                .Where(i=>i.CourseId == id).Select(i => i.Student).ToList();
              
            if (student == null) { 
                return NotFound();
            }
            return Json( student);
        }

        public IActionResult RegisterCourse(int id , int stud_id)
        {
            var cours = db.Courses.SingleOrDefault(c => c.Id == id);
            if (cours == null)
            {
                return NotFound();

            }
            var student = db.Students.SingleOrDefault(c => c.Id == stud_id);
            if (student != null && cours != null)
            {
                var rgist = db.Regestrations.SingleOrDefault(i => i.StudentId == stud_id && i.CourseId == id);
                if (rgist == null)
                {
                    Regestration newregist = new Regestration() { CourseId = id , StudentId= stud_id};
                    db.Regestrations.Add(newregist);
                    db.SaveChanges();
                }
                return RedirectToAction("Profile", "Student", new { id = stud_id });
            }
            return RedirectToAction("Index", "home");
        }



        public IActionResult DeleteCourse(int id, int stud_id)
        {
            var cours = db.Courses.SingleOrDefault(c => c.Id == id);
            if (cours == null)
            {
                return NotFound();

            }
            var student = db.Students.SingleOrDefault(c => c.Id == stud_id);
            if (student != null && cours != null)
            {
                var rgist = db.Regestrations.SingleOrDefault(i => i.StudentId == stud_id && i.CourseId == id);
                if (rgist != null)
                {
                    //Regestration newregist = new Regestration() { CourseId = id, StudentId = stud_id };
                    db.Regestrations.Remove(rgist);
                    db.SaveChanges();
                }
                return RedirectToAction("Profile", "Student", new { id = stud_id });
            }
            return RedirectToAction("Index", "home");
        }


        //public IActionResult coursDateials(int id, int student_id)
        //{

        //    ViewBag.student_id = student_id;
        //    var result = db.Courses.SingleOrDefault(i => i.Id == id);
        //    ViewBag.catg = db.Categories.Where(i => i.Id == result.CateId).Select(i => i.CatName).FirstOrDefault();
        //    ViewBag.inst = db.Instructors.Where(i => i.Id == result.InstructorId).Select(i => i.FullName).FirstOrDefault();
        //    ViewBag.material = db.Materials.Where(i => i.CoursId == id).ToList();
        //    if (result == null)
        //        return NotFound();
        //    return View(result);
        //}
    }
}
