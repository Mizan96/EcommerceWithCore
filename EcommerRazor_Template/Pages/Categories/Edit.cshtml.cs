using EcommerRazor_Template.Data;
using EcommerRazor_Template.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcommerRazor_Template.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;   
        }
        public void OnGet(int? id)
        {
            if(id!=null && id != 0) {
                Category = _db.Categories.Find(id);
            }
            
        }
        public IActionResult OnPost() 
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                TempData["success"] = "Category is updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
                                    
        }
    }
}
