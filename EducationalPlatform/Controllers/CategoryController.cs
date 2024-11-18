using EducationalPlatform.Models;
using EducationalPlatform.ViewModel;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace EducationalPlatform.Controllers
{
    public class CategoryController : Controller
    {
        EducationalPlatformContext db = new EducationalPlatformContext();

        public CategoryController(IHostingEnvironment host)
        {
            _host = host;
        }
        private readonly IHostingEnvironment _host;

        public IActionResult Create()
        {
            return View(new Category());
        }
        public IActionResult SaveCreate(Category category)
        {
            if (ModelState.IsValid)
            {

                string fileName = string.Empty;
                if (category.clientFile != null)
                {
                    try
                    {
                        string muupload = Path.Combine(_host.WebRootPath, "Images");
                        fileName = category.clientFile.FileName;
                        string fullpath = Path.Combine(muupload, fileName);
                        category.clientFile.CopyTo(new FileStream(fullpath, FileMode.Create));
                        category.Image = fileName;
                    }
                    catch
                    {
                        category.Image = category.clientFile.FileName;
                    }
                }

                db.Categories.Add(category);
                db.SaveChanges();
            }
            return RedirectToAction("Create");
        }



        public IActionResult EditView(int id)
        {
            
            var item = db.Categories.SingleOrDefault(c => c.Id == id);
            return View(item);
        }

        public IActionResult saveEdit(int id, Category category)
        {
            var item = db.Categories.FirstOrDefault(c => c.Id == id);
            if (ModelState.IsValid && item != null)
            {
                string fileName = string.Empty;
                if (category.clientFile != null)
                {
                    try
                    {
                        string muupload = Path.Combine(_host.WebRootPath, "Images");
                        fileName = category.clientFile.FileName;
                        string fullpath = Path.Combine(muupload, fileName);
                        category.clientFile.CopyTo(new FileStream(fullpath, FileMode.Create));
                        category.Image = fileName;
                    }
                    catch
                    {
                        category.Image = category.clientFile.FileName;
                    }
                }
                item.CatName = category.CatName;
                if (category.Image != null)
                 item.Image = category.Image;
                db.SaveChanges();
            }
            return RedirectToAction("AdminViw", "admin");

        }






        public IActionResult Delete(int id)
        {
            var i = db.Categories.SingleOrDefault(c => c.Id == id);
            if (i != null)
            {
                
                i.IsDelete = "true";
                db.SaveChanges();
            }
            return RedirectToAction("AdminViw", "admin");
        }



        public IActionResult CoursesByCategory(int id , string name)
        {
            ViewBag.name = name;
            var category = db.Categories
                .Where(c => c.Id == id && c.IsDelete == "false")
                .Select(c => new
                {
                    c.CatName,
                    Courses = c.Courses.Where(x => x.IsDelete == "false").Select(course => new
                    {
                        course.Id,
                        course.CourseName,
                        course.Description,
                        course.Image,
                        course.Price,
                        course.Level
                    }).ToList()
                }).FirstOrDefault();

           

            var viewModel = new CategoryCoursesViewModel
            {
                CategoryName = category.CatName,
                Courses = category.Courses.Select(c => new CourseModel
                {
                    Id = c.Id,
                    CourseName = c.CourseName,
                    Description = c.Description,
                    Image = c.Image,
                    Price = c.Price,
                    Level = c.Level
                }).ToList()
            };

            return View(viewModel);
        }



        public IActionResult CoursesByCategoryStudent(int id , int st_id)
        {
            ViewBag.id = st_id;
            var category = db.Categories
                .Where(c => c.Id == id && c.IsDelete == "false")
                .Select(c => new
                {
                    c.CatName,
                    Courses = c.Courses.Where(x => x.IsDelete == "false").Select(course => new
                    {
                        course.Id,
                        course.CourseName,
                        course.Description,
                        course.Image,
                        course.Price,
                        course.Level
                    }).ToList()
                }).FirstOrDefault();

            

            var viewModel = new CategoryCoursesViewModel
            {
                CategoryName = category.CatName,
                Courses = category.Courses.Select(c => new CourseModel
                {
                    Id = c.Id,
                    CourseName = c.CourseName,
                    Description = c.Description,
                    Image = c.Image,
                    Price = c.Price,
                    Level = c.Level
                }).ToList()
            };

            return View(viewModel);
        }
    }
}
