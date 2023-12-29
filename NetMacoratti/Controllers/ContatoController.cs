using Microsoft.AspNetCore.Mvc;

namespace NetMacoratti.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
