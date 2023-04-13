using Microsoft.AspNetCore.Mvc;

namespace BaicalNews.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
