using Microsoft.EntityFrameworkCore;
using NetMacoratti.DBContent;
using NetMacoratti.Models;
using NetMacoratti.Repository.Interface;

namespace NetMacoratti.Repository
{
    public class LancheRepository : ILancheRepository
    {
        private AppDBContext _dbContext;

        public LancheRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Lanche> Lanches => _dbContext.Lanches.Include(c => c.Categoria);

        public IEnumerable<Lanche> LanchePreferido => _dbContext.Lanches.Where(l => l.IsLanchePreferido).Include(l1 => l1.Categoria);

        public Lanche GetLanche(int id)
        {
            return _dbContext.Lanches.FirstOrDefault(l => l.LancheId == id);
        }
    }
}
