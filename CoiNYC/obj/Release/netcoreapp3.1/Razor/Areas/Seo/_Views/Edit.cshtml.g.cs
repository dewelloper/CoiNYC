#pragma checksum "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Seo\_Views\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c1fe170a59851172e47c0c268a4f09ff986d0126"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CoiNYC.Areas.Seo._Views.Areas_Seo__Views_Edit), @"mvc.1.0.view", @"/Areas/Seo/_Views/Edit.cshtml")]
namespace CoiNYC.Areas.Seo._Views
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
#line 1 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Seo\_Views\Edit.cshtml"
using CoiNYC.Infrastructure;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1fe170a59851172e47c0c268a4f09ff986d0126", @"/Areas/Seo/_Views/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bc1bd475c85969c567e374034c6567b763c4ad0", @"/Areas/_ViewImports.cshtml")]
    public class Areas_Seo__Views_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CoiNYC.Areas.Seo.SeoEditModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Seo\_Views\Edit.cshtml"
  
    ViewBag.Breadcrumbs = new BreadcrumbBuilder()
            .Add(R.Homepage, Url.Action("Index", "Home"))
            .Add(R.Cms)
            .AddCurrentAction(R.EditSeo, Url, ViewContext, true)
            .Build();
    ViewBag.Title = R.EditSeo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Seo\_Views\Edit.cshtml"
Write(await Html.PartialAsync("_Form", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public BootstrapMvc.Mvc6.BootstrapHelper<CoiNYC.Areas.Seo.SeoEditModel> Bootstrap { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CoiNYC.Areas.Seo.SeoEditModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
