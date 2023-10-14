using Microsoft.EntityFrameworkCore;
using NetMacoratti.DBContent;

namespace NetMacoratti.Models
{
    public class CarrinhoCompra
    {
        public readonly AppDBContext _dbContext;
        public CarrinhoCompra(AppDBContext contexto) {
            _dbContext = contexto;

        }

        public string CarrinhoCompraID { get; set; }
        public List<CarrinhoCompraItem>  CarrinhoCompraItens { get; set; }


        public static CarrinhoCompra GetCarrinho(IServiceProvider service)
        {
            //define a session
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //serviço de contexto
            var _dbContext = service.GetService<AppDBContext>();

            // obtem/gera o id do carrinho
            string carrinhoID = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //atribui o id do carrinho a session
            session.SetString("CarrinhoId", carrinhoID);
            return new CarrinhoCompra(_dbContext)
            {
                CarrinhoCompraID = carrinhoID
            };
        }

        public  void  AdicionaAoCarrinho(Lanche lanche) {
            var carrinhoCompraItem = _dbContext.Carrinho.SingleOrDefault(c => c.Lanche.LancheId == lanche.LancheId
            && c.CarrinhoCompraId == CarrinhoCompraID);

            if(carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = carrinhoCompraItem.CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };
                _dbContext.Carrinho.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }
            _dbContext.SaveChanges();
        }

        public void removerDocarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _dbContext.Carrinho.SingleOrDefault(c => c.Lanche.LancheId == lanche.LancheId
            && c.CarrinhoCompraId == CarrinhoCompraID);

            if(carrinhoCompraItem == null)
            {
                if(carrinhoCompraItem.Quantidade >1)
                {
                    carrinhoCompraItem.Quantidade--;

                }
                else
                {
                    _dbContext.Carrinho.Remove(carrinhoCompraItem);
                }
            }
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
        {
            return CarrinhoCompraItens ?? (CarrinhoCompraItens = _dbContext.Carrinho
                                                                .Where(c => c.CarrinhoCompraId == CarrinhoCompraID)
                                                                .Include(l =>l.Lanche)
                                                                .ToList());
        }


        public void limparCarrinho()
        {
            var carrinhoItem = _dbContext.Carrinho.Where(c => c.CarrinhoCompraId == CarrinhoCompraID);

            _dbContext.Carrinho.RemoveRange(carrinhoItem);
            _dbContext.SaveChanges();
        }

        public decimal GetCarrinhoCompraTotal()
        {
            return _dbContext.Carrinho.Where(c => c.CarrinhoCompraId == CarrinhoCompraID).Select(t => t.Quantidade * t.Lanche.Preco).Sum();
        }
    }
}
