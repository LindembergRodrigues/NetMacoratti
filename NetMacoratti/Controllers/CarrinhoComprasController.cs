using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetMacoratti.DBContent;
using NetMacoratti.Models;
using NetMacoratti.Repository.Interface;
using NetMacoratti.ViewModels;

namespace NetMacoratti.Controllers
{
    public class CarrinhoComprasController : Controller
    {
        private readonly AppDBContext _context;
        private readonly ILancheRepository lancheRepository;
        private readonly CarrinhoCompra carrinhoCompra;

        public CarrinhoComprasController(AppDBContext context, ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra)
        {
            _context = context;
            this.lancheRepository = lancheRepository;
            this.carrinhoCompra = carrinhoCompra;
        }

        public IActionResult index()
        {
            carrinhoCompra.CarrinhoCompraItens = carrinhoCompra.GetCarrinhoCompraItens();

            var carrinhoCompraVM = new CarrinhoCompraViewModel()
            {
                carrinhoCompra = carrinhoCompra,
                CarrinhoCompraTotal = carrinhoCompra.GetCarrinhoCompraTotal()
            };
            return View(carrinhoCompraVM);
        }

        public RedirectToActionResult AdicionaItemNoCarrinho(int lancheId)
        {
            var lancheSelecionado = lancheRepository.Lanches.Where(l => l.LancheId == lancheId).FirstOrDefault();

            if(lancheSelecionado != null)
            {
                carrinhoCompra.AdicionaAoCarrinho(lancheSelecionado );
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveItemDoCarrinho(int lancheId)
        {
            var lancheSelecionado = lancheRepository.Lanches.Where(l => l.LancheId == lancheId).FirstOrDefault();

            if (lancheSelecionado != null)
            {
                carrinhoCompra.removerDocarrinho(lancheSelecionado);
            }
            return RedirectToAction("Index");
        }

        public IActionResult AdicionarItemAoCarrinhoCompra() { return View(); }
        public IActionResult RemoverItemAoCarrinhoCompra() { return View(); }
    }
}
