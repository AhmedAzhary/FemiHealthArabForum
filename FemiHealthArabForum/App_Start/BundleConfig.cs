﻿using System.Web;
using System.Web.Optimization;

namespace FemiHealthArabForum
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
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //        BundleTable.Bundles
            //.Add(new ScriptBundle("~/bundles/bootstrap")
            //.Include("~/Scripts/bootstrap*"));

            //    // Either add it to the  existing bundle
            //    //BundleTable.Bundles
            //    //    .Add(new StyleBundle("~/Content/bootstrap")
            //    //    .Include("~/Content/bootstrap.css", 
            //    //            "~/Content/bootstrap-responsive.css",
            //    //            "~/Content/font-awesome.css"));

            //    // Or make it it's own bundle
           bundles.Add(new StyleBundle("~/Content/font-awesome")
                .Include("~/Content/font-awesome.css"));
        }
    }
}
