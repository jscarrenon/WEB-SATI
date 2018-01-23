using System.Web;
using System.Web.Optimization;

namespace WebSATI
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/DataTableJsUtils").Include(
                      "~/Content/lib/DataTable/js/jquery.dataTables.min.js",
                      "~/Content/lib/DataTable/js/dataTables.buttons.min.js",
                      "~/Content/lib/DataTable/js/jszip.min.js",
                      "~/Content/lib/DataTable/js/buttons.html5.min.js",
                      "~/Content/lib/DataTable/js/dataTables.bootstrap4.min.js",
                      "~/Content/lib/DataTable/js/buttons.bootstrap4.min.js"));

            bundles.Add(new StyleBundle("~/Content/DataTableCssUtils").Include(
                           "~/Content/lib/DataTable/css/buttons.bootstrap4.min.css",
                           "~/Content/lib/DataTable/css/buttons.dataTables.min.css",
                           "~/Content/lib/DataTable/css/dataTables.bootstrap4.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/Boostraps").Include(
                        "~/Content/lib/bootstrap-material/js/bootstrap-material-design.js",
                        "~/Content/lib/bootstrap-material/Start/StartBoostrapsMaterials.js"));

            bundles.Add(new StyleBundle("~/Content/Boostraps").Include(
                        "~/Content/lib/bootstrap-material/css/bootstrap-material-design.min.css"));

            bundles.Add(new StyleBundle("~/Content/Normalize").Include(
                        "~/Content/lib/Normalize/normalize.css"));

            bundles.Add(new StyleBundle("~/Content/Style").Include(
                       "~/Content/css/StyleSheet.css"));

            bundles.Add(new StyleBundle("~/Content/DatePicker").Include(
                       "~/Content/lib/Datepicker/jquery-ui.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/Jquery").Include(
                        "~/Content/lib/Jquery/jquery-3.2.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/Popper").Include(
                       "~/Content/lib/bootstrap-material/Popper/popper.js"));

            bundles.Add(new ScriptBundle("~/bundles/JqueryValidate").Include(
                      "~/Content/lib/Jquery/JqueryValidate/jquery.validate.min.js",
                      "~/Content/lib/Jquery/JqueryValidate/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/DatePicker").Include(
                      "~/Content/lib/Datepicker/jquery-ui.min.js",
                      "~/Content/lib/Datepicker/datepicker-es.js"));

        }

    }
}
