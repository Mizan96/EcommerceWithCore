using Microsoft.AspNetCore.Mvc;

namespace EcommerceSite.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
