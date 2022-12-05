using Microsoft.AspNetCore.Mvc;

namespace csharp_boolflix.Controllers
{
    public class FilmController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
