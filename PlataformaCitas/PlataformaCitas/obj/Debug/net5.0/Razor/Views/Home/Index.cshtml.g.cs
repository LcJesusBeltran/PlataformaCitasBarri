#pragma checksum "D:\PlataformaCitasBarri\PlataformaCitas\PlataformaCitas\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9b28658591db6f926fcb06d3a83b0b8fecdede21"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
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
#line 1 "D:\PlataformaCitasBarri\PlataformaCitas\PlataformaCitas\Views\_ViewImports.cshtml"
using PlataformaCitas;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\PlataformaCitasBarri\PlataformaCitas\PlataformaCitas\Views\_ViewImports.cshtml"
using PlataformaCitas.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b28658591db6f926fcb06d3a83b0b8fecdede21", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b3903b4c17fa0874056a4de7aa9f35cbd2cc914e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<lDoctores>
    #nullable disable
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\PlataformaCitasBarri\PlataformaCitas\PlataformaCitas\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center bg-white mh-100 box-shadow mt-5\">\r\n    <h3 class=\"display-5 mb-3 pt-3\">Selecciona el Medico de su preferencia</h3>\r\n\r\n");
#nullable restore
#line 9 "D:\PlataformaCitasBarri\PlataformaCitas\PlataformaCitas\Views\Home\Index.cshtml"
     if(Model.bError == false)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("   <div class=\"overflow-auto over mh-helper \">\r\n");
#nullable restore
#line 11 "D:\PlataformaCitasBarri\PlataformaCitas\PlataformaCitas\Views\Home\Index.cshtml"
         foreach(var Doctor in Model.Doctores)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"attribute-group border mx-auto mb-1 w-50 h-50 mb-2 p-2 d-flex flex-row\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9b28658591db6f926fcb06d3a83b0b8fecdede214156", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 14 "D:\PlataformaCitasBarri\PlataformaCitas\PlataformaCitas\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 475, Doctor.Nombre, 475, 14, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 496, "~/css/", 496, 6, true);
#nullable restore
#line 14 "D:\PlataformaCitasBarri\PlataformaCitas\PlataformaCitas\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 502, Doctor.img, 502, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                <div class=\"p-2 mx-auto\">\r\n                    <label>");
#nullable restore
#line 16 "D:\PlataformaCitasBarri\PlataformaCitas\PlataformaCitas\Views\Home\Index.cshtml"
                      Write(Doctor.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                    <br/>\r\n                    <label>Medigo General</label>\r\n                    <br/>\r\n                    <a class=\"btn btn-aux-plataforma-green mb-3\"");
            BeginWriteAttribute("href", " href=\"", 782, "\"", 820, 2);
            WriteAttributeValue("", 789, "Citas?Id=", 789, 9, true);
#nullable restore
#line 20 "D:\PlataformaCitasBarri\PlataformaCitas\PlataformaCitas\Views\Home\Index.cshtml"
WriteAttributeValue("", 798, Doctor.IdRollElemento, 798, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Solicitar Cita</a>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 23 "D:\PlataformaCitasBarri\PlataformaCitas\PlataformaCitas\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n");
#nullable restore
#line 25 "D:\PlataformaCitasBarri\PlataformaCitas\PlataformaCitas\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <!--");
#nullable restore
#line 27 "D:\PlataformaCitasBarri\PlataformaCitas\PlataformaCitas\Views\Home\Index.cshtml"
         using (Html.BeginForm("TestApi", "Home"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("       <button type=\"submit\" class=\"btn btn-primary\">\r\n           <p class=\"textRight\">\r\n               Test\r\n           </p>\r\n       </button>\r\n");
#nullable restore
#line 34 "D:\PlataformaCitasBarri\PlataformaCitas\PlataformaCitas\Views\Home\Index.cshtml"
    }  

#line default
#line hidden
#nullable disable
            WriteLiteral(@"       <button type=""button"" class=""btn btn-primary"" onclick=""testApi()"">
           <p class=""textRight"">
               Test2
           </p>
       </button>
       <button type=""button"" class=""btn btn-primary"" onclick=""exampleRequestJQuery()"">
           <p class=""textRight"">
               Test3
           </p>
       </button>-->
</div>
");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<lDoctores> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
