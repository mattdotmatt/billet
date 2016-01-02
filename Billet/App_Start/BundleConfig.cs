using System.Web;
using System.Web.Optimization;

namespace Billet
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/js/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/main.css"));
        }
    }
}
