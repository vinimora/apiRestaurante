using System.Web;
using System.Web.Optimization;

namespace ApiRestaurante
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/home").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/popper.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"
            ));
            //fale-conosco
            bundles.Add(new ScriptBundle("~/bundles/fale-conosco").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/fale-conosco.js"
            ));

            //sobre-nos
            bundles.Add(new ScriptBundle("~/bundles/sobre-nos").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/sobre-nos.js"
            ));

            //app-index
            bundles.Add(new ScriptBundle("~/bundles/app-index").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/app.js"
            ));



            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            bundles.Add(new StyleBundle("~/Content/home").Include(
                      "~/Content/Site.css",
                      "~/Content/bootstrap4.css",
                      "~/Content/home.css"));

            //fale-conosco
            bundles.Add(new StyleBundle("~/Content/fale-conosco").Include(
                     "~/Content/Site.css",
                     "~/Content/bootstrap4.css",
                     "~/Content/home.css"));
            //sobre-nos
            bundles.Add(new StyleBundle("~/Content/sobre-nos").Include(
                     "~/Content/Site.css",
                     "~/Content/bootstrap4.css",
                     "~/Content/sobre-nos.css"));

            //app-index
            bundles.Add(new StyleBundle("~/Content/app-index").Include(
                     "~/Content/Site.css",
                     "~/Content/bootstrap.css",
                     "~/Content/app.css"));
        }
    }
}
