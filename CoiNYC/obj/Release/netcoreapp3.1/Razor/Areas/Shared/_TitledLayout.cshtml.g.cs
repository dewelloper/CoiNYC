#pragma checksum "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Shared\_TitledLayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "58e01656ffcd862c5e44266e0ed7bada268419e8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CoiNYC.Areas.Shared.Areas_Shared__TitledLayout), @"mvc.1.0.view", @"/Areas/Shared/_TitledLayout.cshtml")]
namespace CoiNYC.Areas.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\_ViewImports.cshtml"
using CoiNYC.Areas;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\_ViewImports.cshtml"
using CoiNYC.Areas.Panel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\_ViewImports.cshtml"
using CoiNYC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\_ViewImports.cshtml"
using CoiNYC.Domain.Repositories;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\_ViewImports.cshtml"
using CoiNYC.Domain.Resources;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\_ViewImports.cshtml"
using BootstrapMvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Shared\_TitledLayout.cshtml"
using CoiNYC.Infrastructure;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58e01656ffcd862c5e44266e0ed7bada268419e8", @"/Areas/Shared/_TitledLayout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bc1bd475c85969c567e374034c6567b763c4ad0", @"/Areas/_ViewImports.cshtml")]
    public class Areas_Shared__TitledLayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Shared\_TitledLayout.cshtml"
  
    Layout = "~/Areas/Shared/_Layout.cshtml";
    var breadcrumbs = ViewBag.Breadcrumbs as List<Breadcrumb>;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row wrapper border-bottom white-bg page-heading\">\r\n    <div class=\"col-lg-10\">\r\n        <h2>");
#nullable restore
#line 8 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Shared\_TitledLayout.cshtml"
       Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n");
#nullable restore
#line 10 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Shared\_TitledLayout.cshtml"
         if (breadcrumbs != null && breadcrumbs.Count > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <ol class=\"breadcrumb\">\r\n\r\n");
#nullable restore
#line 14 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Shared\_TitledLayout.cshtml"
                 foreach (var crumb in breadcrumbs)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Shared\_TitledLayout.cshtml"
                               
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </ol>\r\n");
#nullable restore
#line 32 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Shared\_TitledLayout.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"col-lg-2\">\r\n\r\n    </div>\r\n</div>\r\n\r\n<div class=\"wrapper-content animated fadeInRight\" style=\"padding:20px 0px\">\r\n    ");
#nullable restore
#line 42 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Shared\_TitledLayout.cshtml"
Write(RenderBody());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 46 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Shared\_TitledLayout.cshtml"
Write(RenderSection("Styles", false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 50 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Shared\_TitledLayout.cshtml"
Write(RenderSection("scripts", false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public BootstrapMvc.Mvc6.BootstrapHelper<dynamic> Bootstrap { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
