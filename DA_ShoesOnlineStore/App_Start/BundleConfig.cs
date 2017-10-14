using System.Web;
using System.Web.Optimization;

namespace DA_ShoesOnlineStore
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
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // my js bundles
            bundles.Add(new ScriptBundle("~/bundles/easing").Include(
                "~/Scripts/ViewTemplate/easing.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-1.11.0.min").Include(
                "~/Scripts/ViewTemplate/jquery-1.11.0.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery.flexslider").Include(
                "~/Scripts/ViewTemplate/jquery.flexslider.js"));

            bundles.Add(new ScriptBundle("~/bundles/memenu").Include(
                "~/Scripts/ViewTemplate/memenu.js"));

            bundles.Add(new ScriptBundle("~/bundles/move-top").Include(
                "~/Scripts/ViewTemplate/move-top.js"));

            bundles.Add(new ScriptBundle("~/bundles/responsiveslides.min").Include(
                "~/Scripts/ViewTemplate/responsiveslides.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/simpleCart.min").Include(
                "~/Scripts/ViewTemplate/simpleCart.min.js"));

            // my css bundles
            bundles.Add(new StyleBundle("~/bundles/bootstrap1").Include(
                "~/Scripts/ViewTemplate/bootstrap.css"));
            bundles.Add(new StyleBundle("~/bundles/flexslider").Include(
                "~/Scripts/ViewTemplate/flexslider.css"));
            bundles.Add(new StyleBundle("~/bundles/memenu").Include(
                "~/Scripts/ViewTemplate/memenu.css"));
            bundles.Add(new StyleBundle("~/bundles/style").Include(
                "~/Scripts/ViewTemplate/style.css"));
        }
    }
}
