using System.Web.Optimization;

namespace WEB_BASE
{
    public class BundleConfig
    {
        // Para obter mais informações sobre agrupamento, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //JavaScripts
            bundles.Add(new ScriptBundle("~/bundles/otf").Include(
                       "~/Scripts/jquery-{version}.js",
                       "~/Scripts/jquery-ui-{version}.js",
                       "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*",
                       "~/Scripts/application.js",
                        "~/Scripts/otf.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
               "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-dialog.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/bootstrapValidator.js"));

            //**********************************************************************//
            //Css
            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/style.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                    "~/Content/bootstrap.min.css",
                    "~/Content/bootstrap-dialog.css",
                    "~/Content/bootstrapValidator.css"));

            bundles.Add(new StyleBundle("~/Content/redmond/css").Include(
                       "~/Content/themes/redmond/jquery-ui.css",
                       "~/Content/themes/redmond/jquery.ui.datepicker.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
