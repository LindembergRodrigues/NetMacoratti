using Microsoft.AspNetCore.Mvc;
using NetMacoratti.Repository.Interface;

namespace NetMacoratti.Component
{
    public class CategoriaMenu: ViewComponent
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaMenu(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            var categoria = _repository.Categorias.OrderBy(c => c.CategoriaNome);
            return View(categoria);
        }
    }
}
