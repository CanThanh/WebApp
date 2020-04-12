using System.Web.Optimization;

namespace WebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Plugins/AdminLte/js/adminlte.js",
                        "~/Scripts/bootstrap.js",
                        "~/Plugins/toastr/toastr.js",
                        "~/Scripts/Common.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Plugins/AdminLte/css/adminlte.css",
                        "~/Content/bootstrap.css",
                        "~/Plugins/font-awesome-4.7.0/css/font-awesome.css",
                        "~/Plugins/toastr/toastr.css",
                        "~/Content/Site.css"
                ));

            bundles.Add(new StyleBundle("~/Account/css").Include(
                //"~/Content/bootstrap.css",
                //"~/Plugins/font-awesome-4.7.0/css/font-awesome.css",
                //"~/Content/Login/material-design-iconic-font.css",
                //"~/Content/Login/animate.css",
                //"~/Content/Login/hamburgers.css",
                //"~/Content/Login/animsition.css",
                //"~/Content/Login/util.css",
                //"~/Content/Login/main.css"

                "~/Plugins/font-awesome-4.7.0/css/font-awesome.css",
                "~/Plugins/AdminLte/css/adminlte.css",
                "~/Plugins/iCheck/square/blue.css",
                "~/Content/Site.css"
                ));
            bundles.Add(new ScriptBundle("~/Account/js").Include(
                //"~/Scripts/Login/animsition.js",
                //"~/Scripts/Login/popper.js",
                //"~/Scripts/bootstrap.js",
                //"~/Scripts/Login/main.js"

                "~/Scripts/bootstrap.js",
                "~/Plugins/iCheck/icheck.js"
                ));
        }
    }
}
