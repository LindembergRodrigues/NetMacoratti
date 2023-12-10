using Microsoft.AspNetCore.Mvc;
using NetMacoratti.Repository.Interface;
using NetMacoratti.ViewModels;

namespace NetMacoratti.Controllers
{
    public class LancheController : Controller
    {

       public readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel { 
                lanchesPreferidos = _lancheRepository.LanchePreferido
            };
            return View(homeViewModel);
        }

        
        public IActionResult List()
        {
            //var lanches = lancheRepository.Lanches;
            //return View(lanches);

            var lanchesListViewModel = new LancheListViewModel();
            lanchesListViewModel.lanches = _lancheRepository.Lanches;
            lanchesListViewModel.categoriaAtual = "categoria atual";

            return View(lanchesListViewModel);

        }

    }
}
