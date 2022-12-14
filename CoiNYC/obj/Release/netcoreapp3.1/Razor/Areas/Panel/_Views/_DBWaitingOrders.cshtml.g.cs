#pragma checksum "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBWaitingOrders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "89e4f419f67ae7ee525cca669b1364500012824f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CoiNYC.Areas.Panel._Views.Areas_Panel__Views__DBWaitingOrders), @"mvc.1.0.view", @"/Areas/Panel/_Views/_DBWaitingOrders.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89e4f419f67ae7ee525cca669b1364500012824f", @"/Areas/Panel/_Views/_DBWaitingOrders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bc1bd475c85969c567e374034c6567b763c4ad0", @"/Areas/_ViewImports.cshtml")]
    public class Areas_Panel__Views__DBWaitingOrders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CoiNYC.Domain.Dashboard.DashboardDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBWaitingOrders.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
    <div class=""col-lg-12"">
        <div class=""ibox"">
            <div class=""ibox-title"">
                <h5>R.WaitingOrders</h5>
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
                <table class=""table table-stripped"" data-toggle=""table"" data-page-size=""10"" data-sortable=""true""
                        data-page-list=""[10,20,50]"" data-pagination=""true"" data-side-pagination=""client"">
                    <thead>
                        <tr>
                            <th>");
#nullable restore
#line 24 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBWaitingOrders.cshtml"
                           Write(R.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th data-sortable=\"true\">");
#nullable restore
#line 25 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBWaitingOrders.cshtml"
                                                Write(R.Stock);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th>");
#nullable restore
#line 26 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBWaitingOrders.cshtml"
                           Write(R.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 30 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBWaitingOrders.cshtml"
                         foreach (var item in Model.WaitingOrders)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 1344, "\"", 1415, 1);
#nullable restore
#line 34 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBWaitingOrders.cshtml"
WriteAttributeValue("", 1351, Url.Action("Edit","Order", new { area = "Admin", id = item.Id}), 1351, 64, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">");
#nullable restore
#line 34 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBWaitingOrders.cshtml"
                                                                                                                          Write(item.OrderNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 37 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBWaitingOrders.cshtml"
                               Write(item.OrderStatus.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    <span");
            BeginWriteAttribute("class", " class=\"", 1713, "\"", 1779, 4);
            WriteAttributeValue("", 1721, "label", 1721, 5, true);
            WriteAttributeValue(" ", 1726, "label-", 1727, 7, true);
#nullable restore
#line 40 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBWaitingOrders.cshtml"
WriteAttributeValue("", 1733, item.TotalPrice > 5 ? "primary" : "danger", 1733, 45, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1778, "", 1779, 1, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 40 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBWaitingOrders.cshtml"
                                                                                                        Write(item.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 43 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\_DBWaitingOrders.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                    <tfoot>
                        <tr>
                            <td colspan=""7"">
                                <ul class=""pagination pull-right""></ul>
                            </td>
                        </tr>
                    </tfoot>
                </table>
            </div>
        </div>
    </div>
</div>");
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
