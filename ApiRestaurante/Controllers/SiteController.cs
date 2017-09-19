using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApiRestaurante.Models;

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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}