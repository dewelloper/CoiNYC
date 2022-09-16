#pragma checksum "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c27babb11470b3344c8514ca1ea2fb465808d12b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CoiNYC.Areas.Product._Views.Areas_Product__Views__Variation), @"mvc.1.0.view", @"/Areas/Product/_Views/_Variation.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c27babb11470b3344c8514ca1ea2fb465808d12b", @"/Areas/Product/_Views/_Variation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bc1bd475c85969c567e374034c6567b763c4ad0", @"/Areas/_ViewImports.cshtml")]
    public class Areas_Product__Views__Variation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CoiNYC.Areas.Product.ProductVariationModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
  
    bool var1 = Model.MainProduct.ProductOption1Id.HasValue;
    bool var2 = Model.MainProduct.ProductOption2Id.HasValue;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"col-lg-12\">\r\n        <div class=\"ibox\">\r\n            <div class=\"btn-group pull-right\">\r\n                <a  data-fancybox data-type=\"ajax\" data-src=\"");
#nullable restore
#line 10 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                                        Write(Url.Action("Variation", "Product", new { pid = Model.ProductId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"btn btn-primary\"><i class=\"fa fa-plus\"></i> <strong>");
#nullable restore
#line 10 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                                                                                                                                                                       Write(R.Add);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</strong></a>
            </div>
        </div>
    </div>
</div>
<div class=""row"">
    <div class=""col-lg-12"">
        <div class=""ibox"">
            <div class=""ibox-content"">
                <table class=""table table-stripped"" data-toggle=""table"" data-page-size=""10"" data-sortable=""true""
                       data-page-list=""[10,20,50]"" data-pagination=""true""  data-side-pagination=""client"">
                    <thead>
                        <tr>
                            <th>");
#nullable restore
#line 23 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                           Write(R.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 24 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                             if (var1)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <th data-sortable=\"true\">");
#nullable restore
#line 26 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                                    Write(Model.MainProduct.ProductOption1Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 27 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                             if (var2)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <th data-sortable=\"true\">");
#nullable restore
#line 30 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                                    Write(Model.MainProduct.ProductOption2Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 31 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <th data-sortable=\"true\">");
#nullable restore
#line 32 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                                Write(R.Stock);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th>");
#nullable restore
#line 33 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                           Write(R.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th>");
#nullable restore
#line 34 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                           Write(R.DiscountPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th class=\"text-right\" data-sort-ignore=\"true\">");
#nullable restore
#line 35 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                                                      Write(R.Action);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 39 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                         foreach (var item in Model.ProductVariations)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 43 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                               Write(item.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n");
#nullable restore
#line 45 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                 if (var1)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td>\r\n                                        ");
#nullable restore
#line 48 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                   Write(item.ProductOptionValue1Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n");
#nullable restore
#line 50 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                 if (var2)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td>\r\n                                        ");
#nullable restore
#line 54 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                   Write(item.ProductOptionValue2Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n");
#nullable restore
#line 56 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>\r\n                                    <span");
            BeginWriteAttribute("class", " class=\"", 2649, "\"", 2710, 4);
            WriteAttributeValue("", 2657, "label", 2657, 5, true);
            WriteAttributeValue(" ", 2662, "label-", 2663, 7, true);
#nullable restore
#line 58 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
WriteAttributeValue("", 2669, item.Stock > 5 ? "primary" : "danger", 2669, 40, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 2709, "", 2710, 1, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 58 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                                                                                   Write(item.Stock);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                </td>\r\n                                <td>\r\n");
#nullable restore
#line 61 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                     for (int i = 0; i < item.Prices.Count; i++)
                                    {
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 63 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                    Write(i > 0 ? " & " : "");

#line default
#line hidden
#nullable disable
#nullable restore
#line 63 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                                         Write(item.Prices[i].Price);

#line default
#line hidden
#nullable disable
#nullable restore
#line 63 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                                                               Write(item.Prices[i].CurrencyCode);

#line default
#line hidden
#nullable disable
#nullable restore
#line 63 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                                                                                                
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </td>\r\n                                <td>\r\n");
#nullable restore
#line 67 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                      int indexer = 0; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                     for (int i = 0; i < item.Prices.Count; i++)
                                    {
                                        if (item.Prices[i].DiscountPrice.HasValue)
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                        Write(indexer > 0 ? " & " : "");

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                                                   Write(item.Prices[i].DiscountPrice);

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                                                                                 Write(item.Prices[i].CurrencyCode);

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                                                                                                                  
                                            indexer++;
                                        }
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </td>\r\n                                <td class=\"text-right\">\r\n                                    <div class=\"btn-group\">\r\n                                        <a data-fancybox data-type=\"ajax\" data-src=\"");
#nullable restore
#line 79 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                                                               Write(Url.Action("Variation", "Product", new { pid = Model.ProductId, id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"btn btn-info btn-xs\"><i class=\"fa fa-paste\"></i> ");
#nullable restore
#line 79 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                                                                                                                                                                                                       Write(R.Edit);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                    </div>\r\n                                    <div class=\"btn-group\">\r\n");
#nullable restore
#line 83 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                         using (Html.BeginForm("DeleteVariation", "Product", FormMethod.Post, new { @class = "form-horizontal", role = "form" }))
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <input type=\"hidden\" id=\"Id\" name=\"Id\"");
            BeginWriteAttribute("value", " value=\"", 4661, "\"", 4677, 1);
#nullable restore
#line 85 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
WriteAttributeValue("", 4669, item.Id, 4669, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                            <input type=\"hidden\" id=\"ProductId\" name=\"ProductId\"");
            BeginWriteAttribute("value", " value=\"", 4779, "\"", 4803, 1);
#nullable restore
#line 86 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
WriteAttributeValue("", 4787, Model.ProductId, 4787, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                            <button class=\"btn-danger btn btn-xs\" type=\"submit\">");
#nullable restore
#line 87 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                                                                           Write(R.Delete);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n");
#nullable restore
#line 88 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </div>\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 92 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 93 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                         if (Model.ProductVariations.Count < 1)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 97 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
                               Write(R.THEREISNOROW);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 100 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Variation.cshtml"
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
        public BootstrapMvc.Mvc6.BootstrapHelper<CoiNYC.Areas.Product.ProductVariationModel> Bootstrap { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CoiNYC.Areas.Product.ProductVariationModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
