using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApiRestaurante.Models;
using RestauranteApi.Models;

namespace ApiRestaurante.Controllers
{
    public class SiteController : Controller
    {
        public ActionResult Index()
        {
            PageAtributes Attr = new PageAtributes();
            Attr.BundleCSS = "home";
            Attr.BundleScript = "home";

            return View(Attr);
        }

        public ActionResult FaleConosco()
        {
            PageAtributes Attr = new PageAtributes();
            Attr.BundleCSS = "fale-conosco";
            Attr.BundleScript = "fale-conosco";

            return View(Attr);
        }

        public ActionResult Cardapio()
        {
            PageAtributes Attr = new PageAtributes();
            Attr.BundleCSS = "sobre-nos";
            Attr.BundleScript = "sobre-nos";

            Cardapio cardapio = new Cardapio();
            //pega lista de tipos de cardapios
            TipoProdutos TipoCardapio = new TipoProdutos();
            ViewBag.TipoCardapio = TipoCardapio.listar();

            ViewBag.listCardapio = cardapio.listar();

            return View(Attr);
        }

        public ActionResult SobreNos()
        {
            PageAtributes Attr = new PageAtributes();
            Attr.BundleCSS = "sobre-nos";
            Attr.BundleScript = "sobre-nos";

            return View(Attr);
        }
    }
}