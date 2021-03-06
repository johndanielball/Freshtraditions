﻿using System.Web;
using System.Web.Optimization;

namespace FT
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/external/jquery-1.10.2.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Styles/hover-min.cs",
                      "~/Content/Styles/Site.css",
                      "~/Content/Styles/about.css",
                      "~/Content/Styles/contact.css",
                      "~/Content/Styles/designer.css",
                      "~/Content/Styles/gallery.css",
                      "~/Content/Styles/home.css"));
        }
    }
}
