using EcommerRazor_Template.Data;
using EcommerRazor_Template.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcommerRazor_Template.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id !=null && id != 0)
            {
                Category = _db.Categories.Find(id);
            }
        }
        public IActionResult OnPost() { 
            Category? obj = _db.Categories.Find(Category.Id);
            if (obj == null) 
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);    
            _db.SaveChanges();
            TempData["success"] = "Category is deleted successfully";
            return RedirectToPage("Index");
        }
    }
}
