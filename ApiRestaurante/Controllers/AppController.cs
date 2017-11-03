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

            List<Cardapio> listCardapio = cardapio.listar();

            ViewBag.Cardapio = listCardapio;

            return View(Attr);
        }
    }
}
