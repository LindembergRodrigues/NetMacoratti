
using Microsoft.AspNetCore.Mvc;
using NetMacoratti.Models;
using NetMacoratti.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetMacoratti.Component
{
    public class CarrinhoCompraResumo : ViewComponent
    {
        private readonly CarrinhoCompra CarrinhoCompra;

        public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
        {
            this.CarrinhoCompra = carrinhoCompra;
        }

        public IViewComponentResult Invoke()
        {
            //CarrinhoCompra.CarrinhoCompraItens = CarrinhoCompra.GetCarrinhoCompraItens();

            CarrinhoCompra.CarrinhoCompraItens = new List<CarrinhoCompraItem>() { new CarrinhoCompraItem(), new CarrinhoCompraItem() };


            var carrinhoCompraVM = new CarrinhoCompraViewModel()
            {
                carrinhoCompra = CarrinhoCompra,
                CarrinhoCompraTotal = CarrinhoCompra.GetCarrinhoCompraTotal()
            };
            return View(carrinhoCompraVM);
        }
    }
}
