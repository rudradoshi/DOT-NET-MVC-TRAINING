using System.Web;
using System.Web.Optimization;

namespace SelfLearnSignUp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/Bootstrap").Include(
                        "~/Scripts/Bootstrap/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/CreateNewAccount").Include(
                        "~/Scripts/CreateNewAccount/CreateNewAccount.js"));
            bundles.Add(new ScriptBundle("~/bundles/js/JQuery").Include(
                      "~/Scripts/JQuery/jquery-3.4.1.js"));
            bundles.Add(new ScriptBundle("~/bundles/js/Mordenizer").Include(
                      "~/Scripts/Mordenizer/modernizr-2.8.3.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/js/UserRecords").Include(
                      "~/Scripts/UserRecords/UserRecords.js"));
            bundles.Add(new ScriptBundle("~/bundles/js/ManagePager").Include(
                      "~/Scripts/UserRecords/ManagePager.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/Charts").Include(
                      "~/Scripts/Charts.js"));
            bundles.Add(new ScriptBundle("~/bundles/js/fusionCharts.charts").Include(
                     "~/Scripts/fusioncharts.charts.js"));
            bundles.Add(new ScriptBundle("~/bundles/js/fusionCharts").Include(
                     "~/Scripts/fusioncharts.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap/css").Include(
                      "~/Content/Bootstrap/bootstrap.css",
                      "~/Content/Site/Site.css"));
            bundles.Add(new StyleBundle("~/Content/css/createnewaccount").Include(
                     "~/Content/CreateNewAccount/CreateNewAccount.css"));
        }
    }
}
