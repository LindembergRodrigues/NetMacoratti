using NetMacoratti.Models;

namespace NetMacoratti.ViewModels
{
    public class LancheListViewModel
    {

        public IEnumerable<Lanche> lanches { get; set; }

        public string  categoriaAtual { get; set; }
    }
}
