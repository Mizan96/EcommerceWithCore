using EcommerceSite.Data;
using EcommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceSite.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {   
            List<Category> objectCategoryList = _db.Categories.ToList();
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
                ModelState.AddModelError("", "Name and Display Order can not be the same");
            }
            if(ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("index", "category");
            }
            return View();
            
        }
    }
}
