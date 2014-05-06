using BundleTransformer.Core.Bundles;
using BundleTransformer.Core.Orderers;
using BundleTransformer.Core.Transformers;
using System.Web;
using System.Web.Optimization;

namespace AuctionLand.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;

            bundles.UseCdn = true;
            var cssTransformer = new CssMinify();
            var jsTransformer = new JsMinify();
            var nullOrderer = new NullOrderer();

            var cssBundle = new CustomStyleBundle("~/bundles/css");
            cssBundle.Include("~/Content/Site.less", "~/Content/bootstrap/bootstrap.less");
            cssBundle.Transforms.Add(cssTransformer);
            cssBundle.Orderer = nullOrderer;
            
            bundles.Add(cssBundle);

            // CSS for custom slider
            var cssSlider = new CustomStyleBundle("~/bundles/cssSlider");
            cssSlider.Include("~/Content/bootstrap/slider.css");
            cssSlider.Transforms.Add(cssTransformer);
            cssSlider.Orderer = nullOrderer;
            bundles.Add(cssSlider);

            // CSS files for Modal fix on mobile devices
            // var modalCssBundle = new CustomStyleBundle("~/bundles/modalCssBundle");
            // modalCssBundle.Include("~/Content/bootstrap/bootstrap-modal-bs3patch.css", "~/Content/bootstrap/bootstrap-modal.css");
            // modalCssBundle.Transforms.Add(cssTransformer);
            // modalCssBundle.Orderer = nullOrderer;
            // bundles.Add(modalCssBundle);

            var jqueryBundle = new CustomScriptBundle("~/bundles/jquery");
            jqueryBundle.Include("~/Scripts/jquery-{version}.js");
            jqueryBundle.Transforms.Add(jsTransformer);
            jqueryBundle.Orderer = nullOrderer;
            bundles.Add(jqueryBundle);

            var jqueryvalBundle = new CustomScriptBundle("~/bundles/jqueryval");
            jqueryvalBundle.Include("~/Scripts/jquery.validate*");
            jqueryvalBundle.Transforms.Add(jsTransformer);
            jqueryvalBundle.Orderer = nullOrderer;
            bundles.Add(jqueryvalBundle);


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.

            var modernizrBundle = new CustomScriptBundle("~/bundles/modernizr");
            modernizrBundle.Include("~/Scripts/modernizr-*");
            modernizrBundle.Transforms.Add(jsTransformer);
            modernizrBundle.Orderer = nullOrderer;
            bundles.Add(modernizrBundle);


            var bootstrapBundle = new CustomScriptBundle("~/bundles/bootstrap");
            bootstrapBundle.Include("~/Scripts/bootstrap.js", "~/Scripts/respond.js");
            bootstrapBundle.Transforms.Add(jsTransformer);
            bootstrapBundle.Orderer = nullOrderer;
            bundles.Add(bootstrapBundle);

            var bootboxBundle = new CustomScriptBundle("~/bundles/bootbox");
            bootboxBundle.Include("~/Scripts/bootbox.js");
            bootboxBundle.Transforms.Add(jsTransformer);
            bootboxBundle.Orderer = nullOrderer;
            bundles.Add(bootboxBundle);

            // JS file for Modal fix on mobile devices
          //  var bootModalBundle = new CustomScriptBundle("~/bundles/bootModal");
          //  bootModalBundle.Include("~/Scripts/bootstrap-modal.js", "~/Scripts/bootstrap-modalmanager.js");
          //  bootModalBundle.Transforms.Add(jsTransformer);
          //  bootModalBundle.Orderer = nullOrderer;
          //  bundles.Add(bootModalBundle);

            // JS file for custom sliders
            var bootSliderBundle = new CustomScriptBundle("~/bundles/bootSlider");
            bootSliderBundle.Include("~/Scripts/bootstrap-slider.js");
            bootSliderBundle.Transforms.Add(jsTransformer);
            bootSliderBundle.Orderer = nullOrderer;
            bundles.Add(bootSliderBundle);


        }
    }
}
