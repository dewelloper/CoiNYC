#pragma checksum "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Filter.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8551313b9862425fc5eafc627ff97f36ce57131c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CoiNYC.Areas.Product._Views.Areas_Product__Views__Filter), @"mvc.1.0.view", @"/Areas/Product/_Views/_Filter.cshtml")]
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
#nullable restore
#line 1 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Filter.cshtml"
using CoiNYC.Infrastructure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Filter.cshtml"
using CoiNYC.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8551313b9862425fc5eafc627ff97f36ce57131c", @"/Areas/Product/_Views/_Filter.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bc1bd475c85969c567e374034c6567b763c4ad0", @"/Areas/_ViewImports.cshtml")]
    public class Areas_Product__Views__Filter : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CoiNYC.Areas.Product.ProductFilterModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Filter.cshtml"
  
    Layout = null;
    ViewBag.Title = R.Product;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-xs-12 col-sm-6 col-md-4\">\r\n            ");
#nullable restore
#line 14 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Filter.cshtml"
       Write(Html.TextBoxFor(model => model.Code));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-xs-12 col-sm-6 col-md-4\">\r\n            ");
#nullable restore
#line 17 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Filter.cshtml"
       Write(Html.TextBoxFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-xs-12 col-sm-6 col-md-4\">\r\n            ");
#nullable restore
#line 20 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Filter.cshtml"
       Write(Html.DropDownListFor(m => m.Categories, new SelectList(Model.Categories, "Value", "Text")));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-xs-12 col-sm-6 col-md-4\">\r\n            ");
#nullable restore
#line 23 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Filter.cshtml"
       Write(Html.DropDownListFor(m => m.Brands, new SelectList(Model.Brands, "Value", "Text")));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-xs-12 col-sm-6 col-md-4\">\r\n            ");
#nullable restore
#line 26 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Filter.cshtml"
       Write(Html.DropDownListFor(m => m.IsActive, new SelectList(Helpers.ActivePassiveList, "Value", "Text")));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-xs-12 col-sm-6 col-md-4\">\r\n            ");
#nullable restore
#line 29 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Product\_Views\_Filter.cshtml"
       Write(Html.DropDownListFor(m => m.IsNew, new SelectList(Helpers.YesNoList, "Value", "Text")));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public BootstrapMvc.Mvc6.BootstrapHelper<CoiNYC.Areas.Product.ProductFilterModel> Bootstrap { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CoiNYC.Areas.Product.ProductFilterModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
