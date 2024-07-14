using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceSite.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository db)
        {
            _categoryRepo = db;
        }
        public IActionResult Index()
        {   
            List<Category> objectCategoryList = _categoryRepo.GetAll().ToList();
            return View(objectCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and Display Order can not be the same");
            }
            if(ModelState.IsValid)
            {
                _categoryRepo.Add(obj);
                _categoryRepo.Save();
                TempData["success"] = "Category is added successfully"; 
                return RedirectToAction("index", "category");
            }
            return View();
            
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _categoryRepo.Get(u=>u.Id==id);
            //Category? categoryFromDb2 = _db.Categories.FirstOrDefault(u => u.Id == id);
            //Category? categoryFromDb3 = _db.Categories.Where(u=>u.Id == id).FirstOrDefault();
            if (categoryFromDb == null) 
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.Update(obj);
                _categoryRepo.Save();
                TempData["success"] = "Category is edited successfully";
                return RedirectToAction("index", "category");
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _categoryRepo.Get(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {   Category? obj = _categoryRepo.Get(u => u.Id == id);
            if (obj == null) 
            {
                return NotFound();
            }
            _categoryRepo.Remove(obj);
            _categoryRepo.Save();
            TempData["success"] = "Category is deleted successfully";
            return RedirectToAction("index", "category");

        }
    }
}
