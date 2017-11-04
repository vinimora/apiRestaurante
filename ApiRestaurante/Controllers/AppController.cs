using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApiRestaurante.Models;
using RestauranteApi.Models;
using Newtonsoft.Json;

namespace ApiRestaurante.Controllers
{
    public class AppController : Controller
    {
        public ActionResult Index()
        {
            PageAtributes Attr = new PageAtributes();
            Attr.BundleCSS = "app-index";
            Attr.BundleScript = "app-index";

            Cardapio cardapio = new Cardapio();

            //List<Cardapio> listCardapio = cardapio.listar();
            List<Cardapio> listCardapio = new List<Cardapio>();
            //cardapio teste
            listCardapio.Add(new Cardapio()
            {
                id = 3,
                ativo = 1,
                nome = "testando",
                preco = 20.50,
                tipo = new TipoProdutos()
                {
                    id = 1
                }
                
            });
            listCardapio.Add(new Cardapio()
            {
                id = 4,
                ativo = 1,
                nome = "testando",
                preco = 22.50,
                tipo = new TipoProdutos()
                {
                    id = 1
                }

            });
            ViewBag.Cardapio = listCardapio;

            return View(Attr);
        }

        public bool InserirPedido(List<ItemPedido> itens,int idmesa)
        {

            Pedido pedido = new Pedido();
            if (itens==null || !itens.Any() || idmesa <= 0)
            {
                return false;
            }
            else
            {
                pedido.itens = itens;
                pedido.mesa = new Mesa()
                {
                    id = idmesa
                };
                pedido.status = EStatus.Andamento;

                pedido.Incluir();
            }
            return true;
        }
    }
}
