﻿using CoiNYC.Infrastructure;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD.Configuration
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///     Use feature folders with custom options
        /// </summary>
        public static IMvcBuilder AddFeatureFolders(this IMvcBuilder services, FeatureFolderOptions options)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (options == null)
                throw new ArgumentException(nameof(options));

            var expander = new FeatureViewLocationExpander(options);

            services.AddMvcOptions(o => o.Conventions.Add(new FeatureControllerModelConvention(options)))
                .AddRazorOptions(o =>
                {
                    o.ViewLocationFormats.Clear();
                    o.ViewLocationFormats.Add(options.FeatureNamePlaceholder + @"\{0}.cshtml");
                    o.ViewLocationFormats.Add(options.FeatureNamePlaceholder + @"\_Views\{0}.cshtml");
                    o.ViewLocationFormats.Add(options.FeatureFolderName + @"\Shared\{0}.cshtml");
                    o.ViewLocationFormats.Add(options.DefaultViewLocation);

                    o.ViewLocationExpanders.Add(expander);
                });

            return services;
        }

        /// <summary>
        ///     Use areas with feature folders and custom options
        /// </summary>
        public static IMvcBuilder AddAreaFeatureFolders(this IMvcBuilder services, AreaFeatureFolderOptions options)
        {
            services.AddRazorOptions(o =>
            {
                o.AreaViewLocationFormats.Clear();

                //o.AreaViewLocationFormats.Add(options.AreaFolderName + @"\{2}\{1}\{0}.cshtml");
                //o.AreaViewLocationFormats.Add(options.AreaFolderName + @"\{2}\_views\{0}.cshtml");
                //o.AreaViewLocationFormats.Add(options.AreaFolderName + @"\{2}\{0}.cshtml");
                //o.AreaViewLocationFormats.Add(options.AreaFolderName + @"\{2}\Shared\{0}.cshtml");

                o.AreaViewLocationFormats.Add(options.AreaFolderName + @"\{1}\_Views\{0}.cshtml");
                o.AreaViewLocationFormats.Add(options.AreaFolderName + @"\Shared\{0}.cshtml");
                o.AreaViewLocationFormats.Add(options.AreaFolderName + @"\{0}.cshtml");
                //o.AreaViewLocationFormats.Add(options.AreaFolderName + @"\Areas\Features\Panel\_Views\{0}.cshtml");

                //o.AreaViewLocationFormats.Add("/Areas/Features/{1}/_Views/{0}" + RazorViewEngine.ViewExtension);
                //o.AreaViewLocationFormats.Add("/Areas/Features/Shared/{0}" + RazorViewEngine.ViewExtension);

            });

            return services;
        }

        /// <summary>
        ///     Use feature folders with the default options. Controllers and view will be located
        ///     under a folder named Features. Shared views are located in Features\Shared.
        /// </summary>
        public static IMvcBuilder AddFeatureFolders(this IMvcBuilder services)
        {
            return AddFeatureFolders(services, new FeatureFolderOptions());
        }

        /// <summary>
        ///     Use areas with feature folders with the default options. Controllers and views will
        ///     be located under a folder named Areas with an area specific folder. Shared views are
        ///     located in Areas\Shared and then in Features\Shared 
        /// </summary>
        public static IMvcBuilder AddAreaFeatureFolders(this IMvcBuilder services)
        {
            return AddAreaFeatureFolders(services, new AreaFeatureFolderOptions());
        }
    }
}
