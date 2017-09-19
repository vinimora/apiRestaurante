using System.Collections.Generic;
using System.Web.Mvc;
using Newtonsoft.Json;
using RestauranteApi.Models;

namespace RestauranteApi.Controllers
{
    public class PedidoController : Controller
    {
        public string Index()
        {
            Pedido pedido = new Pedido();
            pedido.Incluir();
            string json = JsonConvert.SerializeObject(new List<int>() { 1, 2, 3 });
            return json;
        }
        public string listar(int mesa)
        {
            List<Pedido> pedidos = new List<Pedido>();
            Pedido pedido = new Pedido();
            pedidos = pedido.listar();
            // pedido = pedi;
            string json = JsonConvert.SerializeObject(pedidos);
            return json;
        }
    }
}
