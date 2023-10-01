using NetMacoratti.DBContent;
using NetMacoratti.Migrations;

namespace NetMacoratti.Models
{
    public class CarrinhoCompra
    {
        public readonly AppDBContext _dbContext;
        public CarrinhoCompra(AppDBContext contexto) {
            _dbContext = contexto;

        }

        public string CarrinhoCompraID { get; set; }
        public List<carrinhoCompraItem>  CarrinhoCompraItens { get; set; }


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

        public  void  AdicionaAoCarrinho() { 


        }

    }
}
