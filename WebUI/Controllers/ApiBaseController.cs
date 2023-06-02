using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class ApiBaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
