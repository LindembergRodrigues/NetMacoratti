using Microsoft.AspNetCore.Mvc;
using NetMacoratti.Repository.Interface;

namespace NetMacoratti.Controllers
{
    public class LancheController : Controller
    {

       public readonly ILancheRepository lancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            this.lancheRepository = lancheRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            var lanches = lancheRepository.Lanches;
            return View(lanches);
        }

    }
}
