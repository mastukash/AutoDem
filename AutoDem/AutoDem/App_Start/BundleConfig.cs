using System.Web;
using System.Web.Optimization;

namespace AutoDem
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/covervideo").Include(
                        "~/Scripts/customjs/js_for_covervideo.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/index").Include(
                "~/Content/animate.css",
                 "~/Content/icomoon.css",
                 "~/Content/themify-icons.css",
                 "~/Content/magnific-popup.css",
                 "~/Content/owl.carousel.min.css",
                 "~/Content/owl.theme.default.min.css",
                 "~/Content/style.css"
                ));
            



            bundles.Add(new ScriptBundle("~/bundles/index").Include(
                        //"~/Scripts/jquery.min.js",/*   "~/Scripts/bootstrap.min.js"*/,
                        "~/Scripts/jquery.easing.1.3.js",
                         "~/Scripts/jquery.waypoints.min.js",
                         "~/Scripts/sticky.js",
                         "~/Scripts/owl.carousel.min.js",
                         "~/Scripts/jquery.countTo.js",
                         "~/Scripts/jquery.stellar.min.js",
                         "~/Scripts/jquery.magnific-popup.min.js",
                         "~/Scripts/magnific-popup-options.js",
                         "~/Scripts/main.js"
                        ));

        }
    }
}
