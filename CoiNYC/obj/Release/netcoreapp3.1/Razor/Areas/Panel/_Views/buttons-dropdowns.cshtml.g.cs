#pragma checksum "D:\H_New_Projects\CoiNYC\CoiNYC\CoiNYC\Areas\Panel\_Views\buttons-dropdowns.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "53657dd43ec75928fc47469a0e88b101443ca22e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CoiNYC.Areas.Panel._Views.Areas_Panel__Views_buttons_dropdowns), @"mvc.1.0.view", @"/Areas/Panel/_Views/buttons-dropdowns.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53657dd43ec75928fc47469a0e88b101443ca22e", @"/Areas/Panel/_Views/buttons-dropdowns.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bc1bd475c85969c567e374034c6567b763c4ad0", @"/Areas/_ViewImports.cshtml")]
    public class Areas_Panel__Views_buttons_dropdowns : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("px-4 py-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""row"">
  <div class=""col"">
    <div class=""card"">
      <div class=""card-header"">
        <i class=""fa fa-align-justify""></i> Dropdowns
        <div class=""card-header-actions"">
          <a href=""http://Panel.io/docs/components/bootstrap-dropdowns/"" class=""card-header-action"" target=""_blank"">
            <small class=""text-muted"">docs</small>
          </a>
        </div>
      </div>
      <div class=""card-body"">
        <div class=""row"">
          <div class=""col"">
            <div class=""btn-group"">
              <div class=""dropdown"">
                <button class=""btn btn-secondary dropdown-toggle"" type=""button"" id=""dropdownMenuButton"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                  Dropdown button
                </button>
                <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton"">
                  <a class=""dropdown-item"" href=""#"">Action</a>
                  <a class=""dropdown-item"" href=""#"">Another action</a>");
            WriteLiteral(@"
                  <a class=""dropdown-item"" href=""#"">Something else here</a>
                </div>
              </div>
            </div>
            <div class=""btn-group"">
              <div class=""dropdown show"">
                <a class=""btn btn-secondary dropdown-toggle"" href=""#"" role=""button"" id=""dropdownMenuLink"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                  Dropdown link
                </a>
                <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuLink"">
                  <a class=""dropdown-item"" href=""#"">Action</a>
                  <a class=""dropdown-item"" href=""#"">Another action</a>
                  <a class=""dropdown-item"" href=""#"">Something else here</a>
                </div>
              </div>
            </div>
          </div>
        </div>
        <hr />
        <div class=""btn-group"">
          <button type=""button"" class=""btn btn-primary dropdown-toggle"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded");
            WriteLiteral(@"=""false"">
            Primary
          </button>
          <div class=""dropdown-menu"" x-placement=""bottom-start"" style=""position: absolute; transform: translate3d(0px, 34px, 0px); top: 0px; left: 0px; will-change: transform;"">
            <a class=""dropdown-item"" href=""#"">Action</a>
            <a class=""dropdown-item"" href=""#"">Another action</a>
            <a class=""dropdown-item"" href=""#"">Something else here</a>
            <div class=""dropdown-divider""></div>
            <a class=""dropdown-item"" href=""#"">Separated link</a>
          </div>
        </div>
        <!-- /btn-group -->
        <div class=""btn-group"">
          <button type=""button"" class=""btn btn-secondary dropdown-toggle"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
            Secondary
          </button>
          <div class=""dropdown-menu"" x-placement=""bottom-start"" style=""position: absolute; transform: translate3d(0px, 34px, 0px); top: 0px; left: 0px; will-change: transform;"">
            <a class");
            WriteLiteral(@"=""dropdown-item"" href=""#"">Action</a>
            <a class=""dropdown-item"" href=""#"">Another action</a>
            <a class=""dropdown-item"" href=""#"">Something else here</a>
            <div class=""dropdown-divider""></div>
            <a class=""dropdown-item"" href=""#"">Separated link</a>
          </div>
        </div>
        <!-- /btn-group -->
        <div class=""btn-group"">
          <button type=""button"" class=""btn btn-success dropdown-toggle"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
            Success
          </button>
          <div class=""dropdown-menu"" x-placement=""bottom-start"" style=""position: absolute; transform: translate3d(0px, 34px, 0px); top: 0px; left: 0px; will-change: transform;"">
            <a class=""dropdown-item"" href=""#"">Action</a>
            <a class=""dropdown-item"" href=""#"">Another action</a>
            <a class=""dropdown-item"" href=""#"">Something else here</a>
            <div class=""dropdown-divider""></div>
            <a class=""dropdown-");
            WriteLiteral(@"item"" href=""#"">Separated link</a>
          </div>
        </div>
        <!-- /btn-group -->
        <div class=""btn-group"">
          <button type=""button"" class=""btn btn-info dropdown-toggle"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
            Info
          </button>
          <div class=""dropdown-menu"" x-placement=""bottom-start"" style=""position: absolute; transform: translate3d(0px, 34px, 0px); top: 0px; left: 0px; will-change: transform;"">
            <a class=""dropdown-item"" href=""#"">Action</a>
            <a class=""dropdown-item"" href=""#"">Another action</a>
            <a class=""dropdown-item"" href=""#"">Something else here</a>
            <div class=""dropdown-divider""></div>
            <a class=""dropdown-item"" href=""#"">Separated link</a>
          </div>
        </div>
        <!-- /btn-group -->
        <div class=""btn-group"">
          <button type=""button"" class=""btn btn-warning dropdown-toggle"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""");
            WriteLiteral(@"false"">
            Warning
          </button>
          <div class=""dropdown-menu"" x-placement=""bottom-start"" style=""position: absolute; transform: translate3d(0px, 34px, 0px); top: 0px; left: 0px; will-change: transform;"">
            <a class=""dropdown-item"" href=""#"">Action</a>
            <a class=""dropdown-item"" href=""#"">Another action</a>
            <a class=""dropdown-item"" href=""#"">Something else here</a>
            <div class=""dropdown-divider""></div>
            <a class=""dropdown-item"" href=""#"">Separated link</a>
          </div>
        </div>
        <!-- /btn-group -->
        <div class=""btn-group"">
          <button type=""button"" class=""btn btn-danger dropdown-toggle"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
            Danger
          </button>
          <div class=""dropdown-menu"" x-placement=""bottom-start"" style=""position: absolute; transform: translate3d(0px, 34px, 0px); top: 0px; left: 0px; will-change: transform;"">
            <a class=""dropdo");
            WriteLiteral(@"wn-item"" href=""#"">Action</a>
            <a class=""dropdown-item"" href=""#"">Another action</a>
            <a class=""dropdown-item"" href=""#"">Something else here</a>
            <div class=""dropdown-divider""></div>
            <a class=""dropdown-item"" href=""#"">Separated link</a>
          </div>
        </div>
        <!-- /btn-group -->
        <hr />
        <div class=""btn-group"">
          <button type=""button"" class=""btn btn-primary"">Primary</button>
          <button type=""button"" class=""btn btn-primary dropdown-toggle dropdown-toggle-split"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
            <span class=""sr-only"">Toggle Dropdown</span>
          </button>
          <div class=""dropdown-menu"" x-placement=""bottom-start"" style=""position: absolute; transform: translate3d(71px, 34px, 0px); top: 0px; left: 0px; will-change: transform;"">
            <a class=""dropdown-item"" href=""#"">Action</a>
            <a class=""dropdown-item"" href=""#"">Another action</a>
          ");
            WriteLiteral(@"  <a class=""dropdown-item"" href=""#"">Something else here</a>
            <div class=""dropdown-divider""></div>
            <a class=""dropdown-item"" href=""#"">Separated link</a>
          </div>
        </div>
        <!-- /btn-group -->
        <div class=""btn-group"">
          <button type=""button"" class=""btn btn-secondary"">Secondary</button>
          <button type=""button"" class=""btn btn-secondary dropdown-toggle dropdown-toggle-split"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
            <span class=""sr-only"">Toggle Dropdown</span>
          </button>
          <div class=""dropdown-menu"" x-placement=""bottom-start"" style=""position: absolute; transform: translate3d(89px, 34px, 0px); top: 0px; left: 0px; will-change: transform;"">
            <a class=""dropdown-item"" href=""#"">Action</a>
            <a class=""dropdown-item"" href=""#"">Another action</a>
            <a class=""dropdown-item"" href=""#"">Something else here</a>
            <div class=""dropdown-divider""></div>
     ");
            WriteLiteral(@"       <a class=""dropdown-item"" href=""#"">Separated link</a>
          </div>
        </div>
        <!-- /btn-group -->
        <div class=""btn-group"">
          <button type=""button"" class=""btn btn-success"">Success</button>
          <button type=""button"" class=""btn btn-success dropdown-toggle dropdown-toggle-split"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
            <span class=""sr-only"">Toggle Dropdown</span>
          </button>
          <div class=""dropdown-menu"">
            <a class=""dropdown-item"" href=""#"">Action</a>
            <a class=""dropdown-item"" href=""#"">Another action</a>
            <a class=""dropdown-item"" href=""#"">Something else here</a>
            <div class=""dropdown-divider""></div>
            <a class=""dropdown-item"" href=""#"">Separated link</a>
          </div>
        </div>
        <!-- /btn-group -->
        <div class=""btn-group"">
          <button type=""button"" class=""btn btn-info"">Info</button>
          <button type=""button"" class=");
            WriteLiteral(@"""btn btn-info dropdown-toggle dropdown-toggle-split"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
            <span class=""sr-only"">Toggle Dropdown</span>
          </button>
          <div class=""dropdown-menu"">
            <a class=""dropdown-item"" href=""#"">Action</a>
            <a class=""dropdown-item"" href=""#"">Another action</a>
            <a class=""dropdown-item"" href=""#"">Something else here</a>
            <div class=""dropdown-divider""></div>
            <a class=""dropdown-item"" href=""#"">Separated link</a>
          </div>
        </div>
        <!-- /btn-group -->
        <div class=""btn-group"">
          <button type=""button"" class=""btn btn-warning"">Warning</button>
          <button type=""button"" class=""btn btn-warning dropdown-toggle dropdown-toggle-split"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
            <span class=""sr-only"">Toggle Dropdown</span>
          </button>
          <div class=""dropdown-menu"">
            <a class=""dr");
            WriteLiteral(@"opdown-item"" href=""#"">Action</a>
            <a class=""dropdown-item"" href=""#"">Another action</a>
            <a class=""dropdown-item"" href=""#"">Something else here</a>
            <div class=""dropdown-divider""></div>
            <a class=""dropdown-item"" href=""#"">Separated link</a>
          </div>
        </div>
        <!-- /btn-group -->
        <div class=""btn-group"">
          <button type=""button"" class=""btn btn-danger"">Danger</button>
          <button type=""button"" class=""btn btn-danger dropdown-toggle dropdown-toggle-split"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
            <span class=""sr-only"">Toggle Dropdown</span>
          </button>
          <div class=""dropdown-menu"">
            <a class=""dropdown-item"" href=""#"">Action</a>
            <a class=""dropdown-item"" href=""#"">Another action</a>
            <a class=""dropdown-item"" href=""#"">Something else here</a>
            <div class=""dropdown-divider""></div>
            <a class=""dropdown-item"" href=""#""");
            WriteLiteral(@">Separated link</a>
          </div>
        </div>
        <!-- /btn-group -->
        <hr />
        <div class=""btn-toolbar"" role=""toolbar"">
          <div class=""btn-group"">
            <button class=""btn btn-secondary btn-lg dropdown-toggle"" type=""button"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
              Large button
            </button>
            <div class=""dropdown-menu"">
              <a class=""dropdown-item"" href=""#"">Action</a>
              <a class=""dropdown-item"" href=""#"">Another action</a>
              <a class=""dropdown-item"" href=""#"">Something else here</a>
              <div class=""dropdown-divider""></div>
              <a class=""dropdown-item"" href=""#"">Separated link</a>
            </div>
          </div>
          <!-- /btn-group -->
          <div class=""btn-group ml-2"">
            <button type=""button"" class=""btn btn-lg btn-secondary"">Large split button</button>
            <button type=""button"" class=""btn btn-lg btn-secondary drop");
            WriteLiteral(@"down-toggle dropdown-toggle-split"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
              <span class=""sr-only"">Toggle Dropdown</span>
            </button>
            <div class=""dropdown-menu"">
              <a class=""dropdown-item"" href=""#"">Action</a>
              <a class=""dropdown-item"" href=""#"">Another action</a>
              <a class=""dropdown-item"" href=""#"">Something else here</a>
              <div class=""dropdown-divider""></div>
              <a class=""dropdown-item"" href=""#"">Separated link</a>
            </div>
          </div>
          <!-- /btn-group -->
        </div>
        <!-- /btn-toolbar -->
        <hr />
        <div class=""btn-toolbar"" role=""toolbar"">
          <div class=""btn-group"">
            <button class=""btn btn-secondary btn-sm dropdown-toggle"" type=""button"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
              Small button
            </button>
            <div class=""dropdown-menu"">
              <a");
            WriteLiteral(@" class=""dropdown-item"" href=""#"">Action</a>
              <a class=""dropdown-item"" href=""#"">Another action</a>
              <a class=""dropdown-item"" href=""#"">Something else here</a>
              <div class=""dropdown-divider""></div>
              <a class=""dropdown-item"" href=""#"">Separated link</a>
            </div>
          </div>
          <!-- /btn-group -->
          <div class=""btn-group ml-2"">
            <button type=""button"" class=""btn btn-sm btn-secondary"">Small split button</button>
            <button type=""button"" class=""btn btn-sm btn-secondary dropdown-toggle dropdown-toggle-split"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
              <span class=""sr-only"">Toggle Dropdown</span>
            </button>
            <div class=""dropdown-menu"">
              <a class=""dropdown-item"" href=""#"">Action</a>
              <a class=""dropdown-item"" href=""#"">Another action</a>
              <a class=""dropdown-item"" href=""#"">Something else here</a>
              <d");
            WriteLiteral(@"iv class=""dropdown-divider""></div>
              <a class=""dropdown-item"" href=""#"">Separated link</a>
            </div>
          </div>
          <!-- /btn-group -->
        </div>
        <!-- /btn-toolbar -->
        <hr />
        <div class=""bd-example"">
          <div class=""btn-group dropup"">
            <button type=""button"" class=""btn btn-secondary dropdown-toggle"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
              Dropup
            </button>
            <div class=""dropdown-menu"" x-placement=""top-start"" style=""position: absolute; transform: translate3d(0px, -2px, 0px); top: 0px; left: 0px; will-change: transform;"">
              <a class=""dropdown-item"" href=""#"">Action</a>
              <a class=""dropdown-item"" href=""#"">Another action</a>
              <a class=""dropdown-item"" href=""#"">Something else here</a>
              <div class=""dropdown-divider""></div>
              <a class=""dropdown-item"" href=""#"">Separated link</a>
            </div>
    ");
            WriteLiteral(@"      </div>

          <div class=""btn-group dropup"">
            <button type=""button"" class=""btn btn-secondary"">
              Split dropup
            </button>
            <button type=""button"" class=""btn btn-secondary dropdown-toggle dropdown-toggle-split"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
              <span class=""sr-only"">Toggle Dropdown</span>
            </button>
            <div class=""dropdown-menu"" x-placement=""top-start"" style=""position: absolute; transform: translate3d(101px, -188px, 0px); top: 0px; left: 0px; will-change: transform;"">
              <a class=""dropdown-item"" href=""#"">Action</a>
              <a class=""dropdown-item"" href=""#"">Another action</a>
              <a class=""dropdown-item"" href=""#"">Something else here</a>
              <div class=""dropdown-divider""></div>
              <a class=""dropdown-item"" href=""#"">Separated link</a>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</div>
<di");
            WriteLiteral(@"v class=""row"">
  <div class=""col"">
    <div class=""card"">
      <div class=""card-header"">
        <i class=""fa fa-align-justify""></i> Menus
      </div>
      <div class=""card-body"">
        <div class=""dropdown"">
          <button class=""btn btn-secondary dropdown-toggle"" type=""button"" id=""dropdownMenu2"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
            Dropdown
          </button>
          <div class=""dropdown-menu"" aria-labelledby=""dropdownMenu2"" x-placement=""bottom-start"" style=""position: absolute; transform: translate3d(0px, 34px, 0px); top: 0px; left: 0px; will-change: transform;"">
            <button class=""dropdown-item"" type=""button"">Action</button>
            <button class=""dropdown-item"" type=""button"">Another action</button>
            <button class=""dropdown-item"" type=""button"">Something else here</button>
          </div>
        </div>
        <hr />
        <div class=""btn-group"">
          <button type=""button"" class=""btn btn-secondary dropdow");
            WriteLiteral(@"n-toggle"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
            This dropdown's menu is right-aligned
          </button>
          <div class=""dropdown-menu dropdown-menu-right"">
            <button class=""dropdown-item"" type=""button"">Action</button>
            <button class=""dropdown-item"" type=""button"">Another action</button>
            <button class=""dropdown-item"" type=""button"">Something else here</button>
          </div>
        </div>
        <hr />
        <div class=""dropdown"">
          <button class=""btn btn-secondary dropdown-toggle"" type=""button"" id=""dropdownMenu3"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
            Menu header
          </button>
          <div class=""dropdown-menu"">
            <h6 class=""dropdown-header"">Dropdown header</h6>
            <a class=""dropdown-item"" href=""#"">Action</a>
            <a class=""dropdown-item"" href=""#"">Another action</a>
          </div>
        </div>
        <hr />
        <di");
            WriteLiteral(@"v class=""dropdown"">
          <button class=""btn btn-secondary dropdown-toggle"" type=""button"" id=""dropdownMenu4"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
            Menu divider
          </button>
          <div class=""dropdown-menu"">
            <a class=""dropdown-item"" href=""#"">Action</a>
            <a class=""dropdown-item"" href=""#"">Another action</a>
            <a class=""dropdown-item"" href=""#"">Something else here</a>
            <div class=""dropdown-divider""></div>
            <a class=""dropdown-item"" href=""#"">Separated link</a>
          </div>
        </div>
        <hr />
        <div class=""dropdown"">
          <button class=""btn btn-secondary dropdown-toggle"" type=""button"" id=""dropdownMenu5"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
            Menu forms
          </button>
          <div class=""dropdown-menu"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "53657dd43ec75928fc47469a0e88b101443ca22e25174", async() => {
                WriteLiteral(@"
              <div class=""form-group"">
                <label for=""exampleDropdownFormEmail1"">Email address</label>
                <input type=""email"" class=""form-control"" id=""exampleDropdownFormEmail1"" placeholder=""email@example.com"">
              </div>
              <div class=""form-group"">
                <label for=""exampleDropdownFormPassword1"">Password</label>
                <input type=""password"" class=""form-control"" id=""exampleDropdownFormPassword1"" placeholder=""Password"">
              </div>
              <div class=""form-check"">
                <label class=""form-check-label"">
                  <input type=""checkbox"" class=""form-check-input""> Remember me
                </label>
              </div>
              <button type=""submit"" class=""btn btn-primary"">Sign in</button>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            <div class=""dropdown-divider""></div>
            <a class=""dropdown-item"" href=""#"">New around here? Sign up</a>
            <a class=""dropdown-item"" href=""#"">Forgot password?</a>
          </div>
        </div>
        <hr />
        <div class=""dropdown"">
          <button class=""btn btn-secondary dropdown-toggle"" type=""button"" id=""dropdownMenu5"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
            Disabled item
          </button>
          <div class=""dropdown-menu"">
            <a class=""dropdown-item"" href=""#"">Regular link</a>
            <a class=""dropdown-item disabled"" href=""#"">Disabled link</a>
            <a class=""dropdown-item"" href=""#"">Another link</a>
          </div>
        </div>
      </div>
    </div>
  </div>
</div>
");
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
