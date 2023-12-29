using Microsoft.AspNetCore.Mvc;
using NetMacoratti.Models;
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

        
        public IActionResult List(String categoria)
        {
            //var lanches = lancheRepository.Lanches;
            //return View(lanches);

            //var lanchesListViewModel = new LancheListViewModel();
            //lanchesListViewModel.lanches = _lancheRepository.Lanches;
            //lanchesListViewModel.categoriaAtual = "categoria atual";
            
            IEnumerable<Lanche> lanches;
            String CategoriaAtual;

            if (String.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
                CategoriaAtual = "Todos os Lanches";
            }
            else
            {
                lanches = _lancheRepository.Lanches;
                lanches = _lancheRepository.Lanches.Where(l => l.Categoria.CategoriaNome.ToUpper().Equals(categoria.ToUpper()));
                CategoriaAtual =  categoria;
            }

            var lanchesListViewModel = new LancheListViewModel
            {
                lanches = lanches,
                categoriaAtual = "categoria atual"
            };
           

            return View(lanchesListViewModel);

        }
        public IActionResult detalhes(int lancheID)
        {
            var lanche = _lancheRepository.GetLanche(lancheID);
            return View(lanche);
        }
    }
}
