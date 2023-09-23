using NetMacoratti.Models;

namespace NetMacoratti.Repository.Interface
{
    public interface ICategoria
    {
        public IEnumerable<Categoria> Categorias { get; }
    }
}
