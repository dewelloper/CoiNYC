#pragma checksum "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBLastUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aedbb032e9952d90b737e630f57e2c3d2c89d0fd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CoiNYC.Areas.Panel._Views.Areas_Panel__Views__DBLastUsers), @"mvc.1.0.view", @"/Areas/Panel/_Views/_DBLastUsers.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aedbb032e9952d90b737e630f57e2c3d2c89d0fd", @"/Areas/Panel/_Views/_DBLastUsers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bc1bd475c85969c567e374034c6567b763c4ad0", @"/Areas/_ViewImports.cshtml")]
    public class Areas_Panel__Views__DBLastUsers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CoiNYC.Domain.Dashboard.DashboardDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBLastUsers.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"ibox float-e-margins\">\r\n    <div class=\"ibox-title\">\r\n        <h5>");
#nullable restore
#line 7 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBLastUsers.cshtml"
       Write(string.Format(R.Last_0_Users, Model.LastItemCount));

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
        <div class=""feed-activity-list"">
");
#nullable restore
#line 19 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBLastUsers.cshtml"
             foreach (var user in Model.LastUsers)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"feed-element\">\r\n                    <div>\r\n                        <small class=\"pull-right text-navy\">");
#nullable restore
#line 23 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBLastUsers.cshtml"
                                                       Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 795, "\"", 870, 1);
#nullable restore
#line 24 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBLastUsers.cshtml"
WriteAttributeValue("", 802, Url.Action("Edit", "Profile", new { area = "Admin", id = user.Id }), 802, 68, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\"><strong>");
#nullable restore
#line 24 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBLastUsers.cshtml"
                                                                                                                          Write(user.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 24 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBLastUsers.cshtml"
                                                                                                                                          Write(user.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></a>\r\n                        <div></div>\r\n                        <small class=\"text-muted\">");
#nullable restore
#line 26 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBLastUsers.cshtml"
                                             Write(user.RegisterDateTime.ToString("dd.MM.yyyy HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 29 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBLastUsers.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>");
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
