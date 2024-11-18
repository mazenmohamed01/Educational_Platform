using EducationalPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace EducationalPlatform.Controllers
{
    public class MaterialController : Controller
    {
        EducationalPlatformContext db = new EducationalPlatformContext();

        public MaterialController(IHostingEnvironment host)
        {
            _host = host;
        }
        private readonly IHostingEnvironment _host;


        public IActionResult addview(int id)
        {

            ViewBag.id = id;
            ViewBag.list_of_materials = db.Materials.Where(c => c.CoursId == id).ToList();
            return View(new Material());
        }
        public IActionResult addviewForistructor(int id , int inst_id)
        {
            ViewBag.insid = inst_id;
            ViewBag.id = id;
            ViewBag.list_of_materials = db.Materials.Where(c => c.CoursId == id).ToList();
            return View(new Material());
        }

        [Route("/AddMaterial/")]
        public IActionResult add(Material material , int? instid)
        {
            if (ModelState.IsValid)
            {

                string fileName = string.Empty;
                if (material.clientFile != null)
                {
                    try
                    {
                        string muupload = Path.Combine(_host.WebRootPath, "material");
                        fileName = material.clientFile.FileName;
                        string fullpath = Path.Combine(muupload, fileName);
                        material.clientFile.CopyTo(new FileStream(fullpath, FileMode.Create));
                        material.FilePath = fileName;
                    }
                    catch
                    {
                        material.FilePath = material.clientFile.FileName;
                    }

                }

                db.Materials.Add(material);
                db.SaveChanges();
            }
            //return View(material.CoursId);
            if(instid == null)
                return RedirectToAction("addview", "Material", new { id = material.CoursId });
            else
                return RedirectToAction("addviewForistructor", "Material", new { id = material.CoursId , inst_id = instid });


        }

        public IActionResult Delete(int id , int? instid)
        {
            var item = db.Materials.FirstOrDefault(i => i.Id == id);
            int? cord_id = item.CoursId;
            db.Materials.Remove(item);
            db.SaveChanges();
            if (instid == null)
                return RedirectToAction("addview", "Material", new { id = cord_id });
            else
                return RedirectToAction("addviewForistructor", "Material", new { id = item.CoursId, inst_id = instid });


        }

        public IActionResult Edit(int id)
        {
            var item = db.Materials.FirstOrDefault(i => i.Id ==id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        public IActionResult EditForInstructor(int id , int inst_id)
        {
            ViewBag.id = inst_id;
            var item = db.Materials.FirstOrDefault(i => i.Id == id);
            if (item == null)
                return NotFound();

            return View(item);
        }
        public IActionResult saveEdit(int id, Material material , int? instid)
        {
            var item = db.Materials.FirstOrDefault(m => m.Id == id);
            if (ModelState.IsValid && item != null)
            {
                string fileName = string.Empty;
                if (material.clientFile != null)
                {
                    try
                    {
                        string muupload = Path.Combine(_host.WebRootPath, "material");
                        fileName = material.clientFile.FileName;
                        string fullpath = Path.Combine(muupload, fileName);
                        material.clientFile.CopyTo(new FileStream(fullpath, FileMode.Create));
                        material.FilePath = fileName;
                    }
                    catch
                    {
                        material.FilePath = material.clientFile.FileName;
                    }

                }
                item.LecuerNumber = material.LecuerNumber;
                if (material.FilePath != null)
                    item.FilePath = material.FilePath;
                db.SaveChanges();
            }
            if (instid == null)
                return RedirectToAction("addview",new { id = material.CoursId });
            else
                return RedirectToAction("addviewForistructor", new { id = material.CoursId , inst_id = instid });

        }

        public IActionResult MaterialById(int id) {
          var item = db.Materials.Where(i=> i.CoursId == id).ToList();
            return View(item);
        }
    }
}
