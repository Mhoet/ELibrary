using Microsoft.AspNetCore.Mvc;

namespace ELibrary.MVC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}