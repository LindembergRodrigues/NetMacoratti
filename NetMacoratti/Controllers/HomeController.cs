using Microsoft.AspNetCore.Mvc;
using NetMacoratti.Models;
using NetMacoratti.Repository.Interface;
using NetMacoratti.ViewModels;
using System.Diagnostics;

namespace NetMacoratti.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        public HomeController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }



        public IActionResult Index()
        {
            var HomeViewModel = new HomeViewModel()
            {
                lanchesPreferidos = _lancheRepository.LanchePreferido
            };


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}