using Microsoft.AspNetCore.Mvc;

namespace ELibrary.MVC.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}