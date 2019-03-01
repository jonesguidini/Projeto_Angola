using System.Web;
using System.Web.Optimization;

namespace WebApp
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/popper.min.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/datatables/jquery.dataTables.js",
                        "~/Scripts/datatables/dataTables.editor.min.js",
                        "~/Scripts/datatables/dataTables.buttons.min.js",
                        "~/Scripts/datatables/dataTables.bootstrap4.js",
                        "~/Scripts/bootstrap-datepicker.js",
                        "~/Scripts/locales/bootstrap-datepicker.pt-BR.min.js",
                        "~/Scripts/jquery.mask.js",
                        "~/Scripts/toastr.js",
                        "~/Scripts/loadingoverlay.js",

                        "~/Scripts/Sistema/configsGeral.js",
                        "~/Scripts/Sistema/configsDatatableGeral.js",
                        "~/Scripts/Sistema/formGeral.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/datatables/css/dataTables.bootstrap4.css",
                      "~/Content/toastr.css",
                      "~/Content/bootstrap-datepicker.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap-toggle.css"
                      ).Include("~/Content/all.css", new CssRewriteUrlTransform()));

            StyleBundle sharedStyleBundle = new StyleBundle("~/Content/font-awesome/css/bundle");
            sharedStyleBundle.Include("~/Content/font-awesome.css");

            bundles.Add(sharedStyleBundle);
        }
    }
}
