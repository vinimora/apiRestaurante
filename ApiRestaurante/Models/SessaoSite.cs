using RestauranteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRestaurante.Models
{
    public class SessaoSite
    {
        public static Funcionario Funcionario
        {
            get { return System.Web.HttpContext.Current.Session["Funcionario"] == null ? null : (Funcionario)System.Web.HttpContext.Current.Session["Funcionario"]; }
            set { System.Web.HttpContext.Current.Session["Funcionario"] = value; }
        }

        public static List<string> Areas
        {
            get { return System.Web.HttpContext.Current.Session["Areas"] == null ? null : (List<string>)System.Web.HttpContext.Current.Session["Areas"]; }
            set { System.Web.HttpContext.Current.Session["Areas"] = value; }
        }

        public static List<string> AreasHubs
        {
            get { return System.Web.HttpContext.Current.Session["hubsAreas"] == null ? null : (List<string>)System.Web.HttpContext.Current.Session["hubsAreas"]; }
            set { System.Web.HttpContext.Current.Session["hubsAreas"] = value; }
        }

        public static List<string> Hubs
        {
            get { return System.Web.HttpContext.Current.Session["hubs"] == null ? null : (List<string>)System.Web.HttpContext.Current.Session["hubs"]; }
            set { System.Web.HttpContext.Current.Session["hubs"] = value; }
        }

        public static string FacebookUser
        {
            get { return System.Web.HttpContext.Current.Session["facebook-user"] == null ? null : (string)System.Web.HttpContext.Current.Session["facebook-user"]; }
            set { System.Web.HttpContext.Current.Session["facebook-user"] = value; }
        }

        public static string FbUserToken
        {
            get { return System.Web.HttpContext.Current.Session["FbUserToken"] == null ? null : (string)System.Web.HttpContext.Current.Session["FbUserToken"]; }
            set { System.Web.HttpContext.Current.Session["FbUserToken"] = value; }
        }
        //FbUserToken

    }
}