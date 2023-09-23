using NetMacoratti.DBContent;
using NetMacoratti.Models;
using NetMacoratti.Repository.Interface;

namespace NetMacoratti.Repository
{
    public class CategoriaRepository : ICategoria
    {
        private AppDBContext _dbContext;

        public CategoriaRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Categoria> Categorias => _dbContext.Categorias;
    }
}
