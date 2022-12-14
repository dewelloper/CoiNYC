#pragma checksum "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "542b2d59c411e53fc1168987eaafd83542833a3d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CoiNYC.Areas.Picture._Views.Areas_Picture__Views__Create), @"mvc.1.0.view", @"/Areas/Picture/_Views/_Create.cshtml")]
namespace CoiNYC.Areas.Picture._Views
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"542b2d59c411e53fc1168987eaafd83542833a3d", @"/Areas/Picture/_Views/_Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bc1bd475c85969c567e374034c6567b763c4ad0", @"/Areas/_ViewImports.cshtml")]
    public class Areas_Picture__Views__Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CoiNYC.Areas.Picture.PictureEditModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Create.cshtml"
  
    Layout = null;
    var routeObjects = new
    {
        Type = Model.Type,
        ObjectId = Model.ObjectId
    };

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"ibox\">\r\n    <div class=\"ibox-title\">\r\n        <h5>");
#nullable restore
#line 13 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Create.cshtml"
       Write(R.NewPicture);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n    </div>\r\n    <div class=\"ibox-content\">\r\n");
#nullable restore
#line 21 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Create.cshtml"
         using (Html.BeginForm("Create", "Picture", FormMethod.Post, new { @class = "form-horizontal", role = "form" }))
        {
            if (Model.Type == CoiNYC.Domain.Commons.OwnerType.None)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Create.cshtml"
           Write(Bootstrap.FormGroupFor(m => m.Name).Control(Bootstrap.Input()));

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Create.cshtml"
                                                                               
            }
            else
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Create.cshtml"
           Write(Bootstrap.FormGroupFor(m => m.Alt).Control(Bootstrap.Input()));

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Create.cshtml"
                                                                              
            }
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Create.cshtml"
       Write(Bootstrap.FormGroupFor(m => m.Order).Control(Bootstrap.InputInt().Placeholder(R.DisplayOrder)));

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Create.cshtml"
       Write(Bootstrap.FormGroupFor(m=> m.ImageFile).Control(Bootstrap.Input()));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""hr-line-dashed""></div>
            <div class=""row"">
                <div class=""col-sm-12"">
                    <div class=""pull-right"">
                        <a class=""btn btn-primary image-uploader""><i class=""fa fa-save""></i> ");
#nullable restore
#line 41 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Create.cshtml"
                                                                                        Write(R.SaveChanges);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
            WriteLiteral("                        ");
#nullable restore
#line 43 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Create.cshtml"
                   Write(Bootstrap.Button(ButtonType.SuccessGreen, R.SaveChanges));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 47 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Create.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public BootstrapMvc.Mvc6.BootstrapHelper<CoiNYC.Areas.Picture.PictureEditModel> Bootstrap { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CoiNYC.Areas.Picture.PictureEditModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
