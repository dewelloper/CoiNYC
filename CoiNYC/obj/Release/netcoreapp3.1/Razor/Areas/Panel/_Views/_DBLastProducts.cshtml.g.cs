#pragma checksum "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBLastProducts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3bc4c89699b5f76870e7b92a1f5beea5e3bab87e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CoiNYC.Areas.Panel._Views.Areas_Panel__Views__DBLastProducts), @"mvc.1.0.view", @"/Areas/Panel/_Views/_DBLastProducts.cshtml")]
namespace CoiNYC.Areas.Panel._Views
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bc4c89699b5f76870e7b92a1f5beea5e3bab87e", @"/Areas/Panel/_Views/_DBLastProducts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bc1bd475c85969c567e374034c6567b763c4ad0", @"/Areas/_ViewImports.cshtml")]
    public class Areas_Panel__Views__DBLastProducts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CoiNYC.Domain.Dashboard.DashboardDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBLastProducts.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"ibox float-e-margins\">\r\n    <div class=\"ibox-title\">\r\n        <h5>");
#nullable restore
#line 7 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBLastProducts.cshtml"
       Write(string.Format(R.Last_0_Products, Model.LastItemCount));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
        <div class=""ibox-tools"">
            <a class=""collapse-link"">
                <i class=""fa fa-chevron-up""></i>
            </a>
            <a class=""close-link"">
                <i class=""fa fa-times""></i>
            </a>
        </div>
    </div>
    <div class=""ibox-content"">
        <table class=""table table-hover no-margins"">
            <thead>
                <tr>
                    <th>");
#nullable restore
#line 21 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBLastProducts.cshtml"
                   Write(R.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th>");
#nullable restore
#line 22 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBLastProducts.cshtml"
                   Write(R.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th>");
#nullable restore
#line 23 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBLastProducts.cshtml"
                   Write(R.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 27 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBLastProducts.cshtml"
                 foreach (var prod in Model.LastProducts)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td><a");
            BeginWriteAttribute("href", " href=\"", 926, "\"", 993, 1);
#nullable restore
#line 30 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBLastProducts.cshtml"
WriteAttributeValue("", 933, Url.Action("Edit","Product",new { area="admin",id=prod.Id}), 933, 60, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\"><span class=\"label label-info\">");
#nullable restore
#line 30 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBLastProducts.cshtml"
                                                                                                                                             Write(prod.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></a></td>\r\n                        <td>");
#nullable restore
#line 31 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBLastProducts.cshtml"
                       Write(prod.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
            WriteLiteral(" ");
#nullable restore
#line 32 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBLastProducts.cshtml"
                                                         Write(prod.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 34 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBLastProducts.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public BootstrapMvc.Mvc6.BootstrapHelper<CoiNYC.Domain.Dashboard.DashboardDto> Bootstrap { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CoiNYC.Domain.Dashboard.DashboardDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
