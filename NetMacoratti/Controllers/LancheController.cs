using Microsoft.AspNetCore.Mvc;

namespace NetMacoratti.Controllers
{
    public class LancheController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
