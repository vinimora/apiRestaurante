using System.Collections.Generic;
using System.Web.Mvc;
using Newtonsoft.Json;
using RestauranteApi.Models;

namespace RestauranteApi.Controllers
{
    public class CardapioController : Controller
    {
        public string Listar()
        {

            Cardapio cardapio = new Cardapio();

            List<Cardapio> listCardapio = cardapio.listar();
            string json = JsonConvert.SerializeObject(new Retorno() {
                retorno = listCardapio,
                sucesso = true
            });
            return json;
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
