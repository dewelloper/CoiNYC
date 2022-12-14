#pragma checksum "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Gallery.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec3c1f902f5467940b418293bc01b430c1b2e413"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CoiNYC.Areas.Picture._Views.Areas_Picture__Views__Gallery), @"mvc.1.0.view", @"/Areas/Picture/_Views/_Gallery.cshtml")]
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
#nullable restore
#line 1 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Gallery.cshtml"
using CoiNYC.Core.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec3c1f902f5467940b418293bc01b430c1b2e413", @"/Areas/Picture/_Views/_Gallery.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bc1bd475c85969c567e374034c6567b763c4ad0", @"/Areas/_ViewImports.cshtml")]
    public class Areas_Picture__Views__Gallery : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CoiNYC.Areas.Picture.GalleryModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Gallery.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 8 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Gallery.cshtml"
 if (Model.AddAllowed)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col\" style=\"padding:15px\">\r\n            <a class=\"btn btn-block btn-primary gallery-button\" data-src=\"");
#nullable restore
#line 12 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Gallery.cshtml"
                                                                     Write(Url.Action("Create", "Picture", new { type = Model.Type, objectId = Model.ObjectId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                <i class=\"fa fa-plus\"></i>\r\n                ");
#nullable restore
#line 14 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Gallery.cshtml"
           Write(R.Add);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </a>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 18 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Gallery.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 20 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Gallery.cshtml"
 if (Model.Pictures != null && Model.Pictures.Count > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n");
#nullable restore
#line 23 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Gallery.cshtml"
         foreach (var pic in Model.Pictures)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div");
            BeginWriteAttribute("class", " class=\"", 642, "\"", 668, 1);
#nullable restore
#line 25 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Gallery.cshtml"
WriteAttributeValue("", 650, Model.ColumnClass, 650, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n\r\n                <div class=\"ibox product-box\">\r\n                    <div class=\"ibox-title\">\r\n");
#nullable restore
#line 29 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Gallery.cshtml"
                         if (!String.IsNullOrEmpty(pic.Name))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h5>");
#nullable restore
#line 31 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Gallery.cshtml"
                           Write(pic.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n");
#nullable restore
#line 32 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Gallery.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h5><small>");
#nullable restore
#line 35 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Gallery.cshtml"
                                  Write(pic.Alt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></h5>\r\n");
#nullable restore
#line 36 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Gallery.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <div class=""ibox-tools"">
                            <a class=""dropdown-toggle"" data-toggle=""dropdown"" href=""#"" aria-expanded=""false"">
                                <i class=""fa fa-wrench""></i>
                            </a>
                            <ul class=""dropdown-menu dropdown-user"">
                                <li>
                                    <a data-src=""");
#nullable restore
#line 43 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Gallery.cshtml"
                                            Write(Url.Action("Edit", "Picture", new { id = pic.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"gallery-button\"><i class=\"fa fa-pencil\"></i> ");
#nullable restore
#line 43 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Gallery.cshtml"
                                                                                                                                                     Write(R.EditPictureInfo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                </li>\r\n                                <li>\r\n                                    <a data-copy><i class=\"fa fa-link\"></i> ");
#nullable restore
#line 46 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Gallery.cshtml"
                                                                       Write(R.CopyUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral("<span hidden>");
#nullable restore
#line 46 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Gallery.cshtml"
                                                                                              Write(pic.Url);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></a>\r\n                                </li>\r\n                                <li>\r\n                                    <a data-src=\"");
#nullable restore
#line 49 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Gallery.cshtml"
                                            Write(Url.Action("Delete", "Picture", new { id = pic.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"gallery-button\"><i class=\"fa fa-trash\"></i> ");
#nullable restore
#line 49 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Gallery.cshtml"
                                                                                                                                                      Write(R.Delete);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class=""ibox-content"">
                        <div class=""text-center"" style=""padding:3px;"">
                            <a");
            BeginWriteAttribute("href", " href=\"", 2350, "\"", 2378, 1);
#nullable restore
#line 56 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Gallery.cshtml"
WriteAttributeValue("", 2357, Url.Content(pic.Url), 2357, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-fancybox=\"gallery-items\" data-caption=\"");
#nullable restore
#line 56 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Gallery.cshtml"
                                                                                                   Write(pic.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-animation-effect=\"false\">\r\n");
            WriteLiteral("                            </a>\r\n                        </div>\r\n                        <div class=\"text-center\">\r\n                            ");
#nullable restore
#line 61 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Gallery.cshtml"
                       Write(pic.OriginalSize);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 66 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Gallery.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 69 "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Picture\_Views\_Gallery.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public BootstrapMvc.Mvc6.BootstrapHelper<CoiNYC.Areas.Picture.GalleryModel> Bootstrap { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CoiNYC.Areas.Picture.GalleryModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
