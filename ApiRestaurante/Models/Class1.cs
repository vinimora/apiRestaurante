using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRestaurante.Models
{
    public class PageAtributes
    {
        public string Title { get; set; }
        public string BundleCSS { get; set; }
        public string BundleScript { get; set; }
        public bool Landing { get; set; }

        public PageAtributes()
        {
            Title = "index";
            BundleCSS = "false";
            BundleScript = "false";
            Landing = false;
        }
    }
}