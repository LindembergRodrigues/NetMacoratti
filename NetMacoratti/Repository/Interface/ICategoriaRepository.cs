using NetMacoratti.Models;

namespace NetMacoratti.Repository.Interface
{
    public interface ICategoriaRepository
    {
        public IEnumerable<Categoria> Categorias { get; }
    }
}
