#pragma checksum "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Specification.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2a04febdd6446d2f934347f3016b909ad704935e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CoiNYC.Areas.Product._Views.Areas_Product__Views__Specification), @"mvc.1.0.view", @"/Areas/Product/_Views/_Specification.cshtml")]
namespace CoiNYC.Areas.Product._Views
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a04febdd6446d2f934347f3016b909ad704935e", @"/Areas/Product/_Views/_Specification.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bc1bd475c85969c567e374034c6567b763c4ad0", @"/Areas/_ViewImports.cshtml")]
    public class Areas_Product__Views__Specification : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CoiNYC.Areas.Product.ProductSpecificationModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"ibox-content m-b-sm border-bottom\">\r\n    <div class=\"row\">\r\n");
#nullable restore
#line 5 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Specification.cshtml"
         using (Html.BeginForm("AddSpecification", "Product", FormMethod.Post, new { @class = "form-horizontal", role = "form" }))
        {
            if ((Model != null) && (Model.ProductId > 0))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <input type=\"hidden\" id=\"ProductId\" name=\"ProductId\"");
            BeginWriteAttribute("value", " value=\"", 570, "\"", 594, 1);
#nullable restore
#line 9 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Specification.cshtml"
WriteAttributeValue("", 578, Model.ProductId, 578, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 10 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Specification.cshtml"
            }
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Specification.cshtml"
       Write(Bootstrap.FormGroupFor(m => m.ProductAttributes).Control(Bootstrap.Select()));

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Specification.cshtml"
       Write(Bootstrap.FormGroupFor(m => m.Value).Control(Bootstrap.Input()));

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Specification.cshtml"
       Write(Bootstrap.Button(ButtonType.SuccessGreen, R.SaveChanges));

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Specification.cshtml"
                                                                     
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
</div>
<div class=""row"">
    <div class=""col-lg-12"">
        <div class=""ibox"">
            <div class=""ibox-content"">
                <table class=""footable table table-stripped toggle-arrow-tiny"" data-page-size=""15"">
                    <thead>
                        <tr>
                            <th>");
#nullable restore
#line 27 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Specification.cshtml"
                           Write(R.AttributeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th>");
#nullable restore
#line 28 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Specification.cshtml"
                           Write(R.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th class=\"text-right\" data-sort-ignore=\"true\">");
#nullable restore
#line 29 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Specification.cshtml"
                                                                      Write(R.Action);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 33 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Specification.cshtml"
                         foreach (var item in Model.ProductSpecifications)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 37 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Specification.cshtml"
                               Write(item.ProductAttributeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 40 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Specification.cshtml"
                               Write(item.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td class=\"text-right\">\r\n                                    <div class=\"btn-group\">\r\n");
#nullable restore
#line 45 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Specification.cshtml"
                                         using (Html.BeginForm("DeleteSpecification", "Product", FormMethod.Post, new { @class = "form-horizontal", role = "form" }))
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <input type=\"hidden\" id=\"Id\" name=\"Id\"");
            BeginWriteAttribute("value", " value=\"", 2749, "\"", 2765, 1);
#nullable restore
#line 47 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Specification.cshtml"
WriteAttributeValue("", 2757, item.Id, 2757, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                            <input type=\"hidden\" id=\"ProductId\" name=\"ProductId\"");
            BeginWriteAttribute("value", " value=\"", 2867, "\"", 2891, 1);
#nullable restore
#line 48 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Specification.cshtml"
WriteAttributeValue("", 2875, Model.ProductId, 2875, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                            <button class=\"btn-danger btn btn-xs\" type=\"submit\">");
#nullable restore
#line 49 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Specification.cshtml"
                                                                                           Write(R.Delete);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n");
#nullable restore
#line 50 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Specification.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </div>\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 54 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Specification.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Specification.cshtml"
                         if (Model.ProductSpecifications.Count < 1)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 59 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Specification.cshtml"
                               Write(R.THEREISNOROW);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 62 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Specification.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                    <tfoot>
                        <tr>
                            <td colspan=""3"">
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
        public BootstrapMvc.Mvc6.BootstrapHelper<CoiNYC.Areas.Product.ProductSpecificationModel> Bootstrap { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CoiNYC.Areas.Product.ProductSpecificationModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
