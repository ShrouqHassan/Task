using Microsoft.AspNetCore.Mvc;
using Task.Models;
using Task.Repository;

namespace Task.Controllers
{
    public class CatalogController : Controller
    {
        Catalog_CRUD_operations catalogs;
        public CatalogController(Catalog_CRUD_operations catalog)
        {
            this.catalogs=catalog;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            
            return View(catalogs.GetAll());
        }
        public IActionResult AddCatalog()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(Catalog catalog,IFormFile file)
        {
            if (file!= null && file.Length > 0)
            {
                
                var fileName = Path.GetFileName(file.FileName);
                var fileExtention= Path.GetExtension(file.FileName);
                var fullpath = fileName +Guid.NewGuid()+ fileExtention;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Uploads", fullpath );

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                catalog.Filepath = "wwwroot\\Uploads" + fullpath;
                catalogs.AddCatalog(catalog);
                catalogs.save();
                return RedirectToAction("AddCatalog");
            }

            return View("AddCatalog");
        }
        public IActionResult Edit(int id)
        {   
            return View(catalogs.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(Catalog catalog)
        {
            catalogs.Update(catalog);
            catalogs.save();
            return RedirectToAction("GetAll");
        }
        public IActionResult Delete(int id)
        {
            catalogs.Delete(catalogs.GetById(id));
          
            return RedirectToAction("GetAll");
        }
    }
}
