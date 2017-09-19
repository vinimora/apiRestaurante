using System.Collections.Generic;
using System.Web.Mvc;
using Newtonsoft.Json;
using RestauranteApi.Models;

namespace RestauranteApi.Controllers
{
    public class PedidoController : Controller
    {
        public string Index(int mesa = 0)
        {
            //valida idmesa
            if (mesa <= 0)
            {
                return JsonConvert.SerializeObject(new Retorno()
                {
                    retorno = "Mesa invalida.",
                    sucesso = false
                });
            }

            Pedido pedido = new Pedido();
            pedido.Incluir(mesa);
            string json = JsonConvert.SerializeObject(new Retorno() {
                retorno = "Pedido incluso com sucesso.",
                sucesso = true
            });
            return json;
        }
        public string listar(int mesa = 0)
        {
            if(mesa<=0)
            {
                return JsonConvert.SerializeObject(new Retorno()
                {
                    retorno = "Mesa invalida.",
                    sucesso = false
                });
            }
            List<Pedido> pedidos = new List<Pedido>();
            Pedido pedido = new Pedido();
            pedidos = pedido.listar();
            // pedido = pedi;
            //string json = JsonConvert.SerializeObject(pedidos);
            return JsonConvert.SerializeObject(new Retorno()
            {
                retorno = pedidos,
                sucesso = true
            });
        }

        public string AddItem(ItemPedido item)
        {
            

            Pedido pedido = new Pedido();
            //pedido.Incluir(mesa);
            string json = JsonConvert.SerializeObject(new Retorno()
            {
                retorno = "Pedido incluso com sucesso.",
                sucesso = true
            });
            return json;
        }
    }
}
