using EducationalPlatform.Models;
using EducationalPlatform.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace EducationalPlatform.Controllers
{
    public class CourseController : Controller
    {
        EducationalPlatformContext db = new EducationalPlatformContext();


        public CourseController(IHostingEnvironment host)
        {
            _host = host;
        }
        private readonly IHostingEnvironment _host;


        public IActionResult Delete(int id , int? instid)
        {
            var i = db.Courses.SingleOrDefault(c => c.Id == id);
            if (i != null)
            {
                
                i.IsDelete = "true";
                db.SaveChanges();
            }
            if (instid == null) 
                return RedirectToAction("AdminViw", "admin");
            else
                return RedirectToAction("MyProfile", "Instructor", new { id = instid});

        }

        [Route("/createCourse/")]
        public IActionResult Create()
        {
            
            
            ViewBag.catagory = db.Categories.Where(i => i.IsDelete == "false").ToList();
            ViewBag.instr = db.Instructors.Where(i => i.IsDelete == "false").ToList();
            return View(new Course());
        }
        public IActionResult CreateForInstructor(int id)
        {

            ViewBag.id = id;
            ViewBag.catagory = db.Categories.Where(i => i.IsDelete == "false").ToList();
            ViewBag.instr = db.Instructors.Where(i => i.IsDelete == "false").ToList();
            return View(new Course());
        }


        [Route("/AddCourse/")]
        public IActionResult newCouse(Course newcours , int? instid)
        {
            if (ModelState.IsValid)
            {
                string fileName = string.Empty;
                if (newcours.clientFile != null)
                {
                    try
                    {
                        string muupload = Path.Combine(_host.WebRootPath, "Images");
                        fileName = newcours.clientFile.FileName;
                        string fullpath = Path.Combine(muupload, fileName);
                        newcours.clientFile.CopyTo(new FileStream(fullpath, FileMode.Create));
                        newcours.Image = fileName;
                    }
                    catch
                    {
                        newcours.Image = newcours.clientFile.FileName;
                    }
                }
                db.Courses.Add(newcours);
                db.SaveChanges();
                if (instid == null)
                    return RedirectToAction("addview", "Material", new { id = newcours.Id });
                else
                    return RedirectToAction("addviewForistructor", "Material", new { id = newcours.Id , inst_id = instid });

            }
            if (instid == null)
                return RedirectToAction("Create", newcours);
            else
                return RedirectToAction("CreateForInstructor", new { id = instid});

        }



        public IActionResult gitbyId(int id  , string name , int? instid)
        {
            ViewBag.id = instid;
            ViewBag.view = name;
            var sum = db.Regestrations.Where(i => i.CourseId == id).Count();
            ViewBag.student_number = sum;
            //ViewBag.view = view;
            // ViewBag.student_id = student_id;
            var result = db.Courses.SingleOrDefault(i => i.Id == id);
            ViewBag.catg = db.Categories.Where(i => i.Id == result.CateId).Select(i => i.CatName).FirstOrDefault();
            ViewBag.inst = db.Instructors.Where(i => i.Id == result.InstructorId).Select(i => i.FullName).FirstOrDefault();
            ViewBag.material = db.Materials.Where(i => i.CoursId == id).ToList();
            if (result == null)
                return NotFound();
            return View(result);
        }

        public IActionResult coursDetails(int id, int student_id)
        {
            var sum = db.Regestrations.Where(i => i.CourseId == id).Count();
            ViewBag.student_number = sum;
            ViewBag.student_id = student_id;
            var result = db.Courses.SingleOrDefault(i => i.Id == id);
            ViewBag.catg = db.Categories.Where(i => i.Id == result.CateId).Select(i => i.CatName).FirstOrDefault();
            ViewBag.inst = db.Instructors.Where(i => i.Id == result.InstructorId).Select(i => i.FullName).FirstOrDefault();
            ViewBag.material = db.Materials.Where(i => i.CoursId == id).ToList();
            if (result == null)
                return NotFound();
            return View(result);
        }
        public IActionResult coursDetails_(int id, int student_id)
        {
            var sum = db.Regestrations.Where(i => i.CourseId == id).Count();
            ViewBag.student_number = sum;

            ViewBag.student_id = student_id;
            var result = db.Courses.SingleOrDefault(i => i.Id == id);
            ViewBag.catg = db.Categories.Where(i => i.Id == result.CateId).Select(i => i.CatName).FirstOrDefault();
            ViewBag.inst = db.Instructors.Where(i => i.Id == result.InstructorId).Select(i => i.FullName).FirstOrDefault();
            ViewBag.material = db.Materials.Where(i => i.CoursId == id).ToList();
            if (result == null)
                return NotFound();
            return View(result);
        }




        public IActionResult EditView(int id)
        {
            ViewBag.catagory = db.Categories.Where(i=> i.IsDelete == "false").ToList();
            ViewBag.instr = db.Instructors.Where(i => i.IsDelete == "false").ToList();
            var item = db.Courses.SingleOrDefault(c => c.Id == id);
            return View(item);
        }

        public IActionResult EditViewForInstructor(int id, int inst_id)
        {
            ViewBag.id = inst_id;
            ViewBag.catagory = db.Categories.Where(i => i.IsDelete == "false").ToList();
            ViewBag.instr = db.Instructors.Where(i => i.IsDelete == "false").ToList();
            var item = db.Courses.SingleOrDefault(c => c.Id == id);
            return View(item);
        }

        public IActionResult saveEdit(int id, Course newcours , int? instid)
        {
            var item = db.Courses.FirstOrDefault(c => c.Id == id);
            if (ModelState.IsValid && item != null)
            {
                string fileName = string.Empty;
                if (newcours.clientFile != null)
                {
                    try
                    {
                        string muupload = Path.Combine(_host.WebRootPath, "Images");
                        fileName = newcours.clientFile.FileName;
                        string fullpath = Path.Combine(muupload, fileName);
                        newcours.clientFile.CopyTo(new FileStream(fullpath, FileMode.Create));
                        newcours.Image = fileName;
                    }
                    catch
                    {
                        newcours.Image = newcours.clientFile.FileName;
                    }
                }
                item.Price = newcours.Price;
                if (newcours.Image != null) 
                    item.Image = newcours.Image;
                item.Hours = newcours.Hours;
                item.Level = newcours.Level;
                item.Description = newcours.Description;
                item.Requirements = newcours.Requirements;
                item.Content = newcours.Content;
                item.CourseName = newcours.CourseName;
                item.InstructorId = newcours.InstructorId;
                item.CateId = newcours.CateId;
                db.SaveChanges();
            }
            if (instid == null)
                return RedirectToAction("addview", "Material", new { id = newcours.Id });
            else return
                    RedirectToAction("addviewForistructor", "Material", new { id = newcours.Id, inst_id= instid });

        }

        public IActionResult Display(int id , int stud_id)
        {
            ViewBag.id = stud_id;
            var courses = db.Courses.Include(i => i.Regestrations).Include(i => i.Instructor).Where(i => i.CateId == id).ToList();
            if (courses == null)
                return NotFound();
            return View(courses);
        }

    }
}
