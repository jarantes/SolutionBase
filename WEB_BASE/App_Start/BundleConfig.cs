using System.Web.Optimization;

namespace WEB_BASE
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //JavaScripts
            bundles.Add(new ScriptBundle("~/bundles/otf").Include(                       
                         "~/Scripts/application.js"
                        ,"~/Scripts/otf.js"
                        ,"~/Scripts/jquery.jqTreeView.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jquerychosen").Include(                       
                         "~/Scripts/chosen.jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                         "~/Scripts/jquery.unobtrusive*"
                        ,"~/Scripts/jquery.validate*"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                         "~/Scripts/jquery-{version}.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                         "~/Scripts/jquery-ui-{version}.custom.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                         "~/Scripts/modernizr-*"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                         "~/Scripts/bootstrap*"
                        ));

            //**********************************************************************//
            //Css
            bundles.Add(new StyleBundle("~/Content/css").Include(
                         "~/Content/jquery.ambiance.css"
                        ,"~/Content/chosen.css"
                        ,"~/Content/style.css"
                        ));

            bundles.Add(new StyleBundle("~/Content/redmond/css").Include(
                         "~/Content/themes/redmond/jquery-ui.css"
                         ,"~/Content/themes/redmond/jquery.ui.datepicker.css"
                         ));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                         "~/Content/bootstrap.css"
                         ));

            //BundleTable.EnableOptimizations = true;
        }
    }
}
