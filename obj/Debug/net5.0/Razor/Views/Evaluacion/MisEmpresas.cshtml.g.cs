#pragma checksum "C:\Users\4668974\OneDrive - Universidad Autonoma de Guadalajara\4668974\EvaluacionEmpresa\Views\Evaluacion\MisEmpresas.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7ee7c073c47be2f4097f060e4e51b6d5f45606f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Evaluacion_MisEmpresas), @"mvc.1.0.view", @"/Views/Evaluacion/MisEmpresas.cshtml")]
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
#line 1 "C:\Users\4668974\OneDrive - Universidad Autonoma de Guadalajara\4668974\EvaluacionEmpresa\Views\_ViewImports.cshtml"
using EvaluacionEmpresa;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\4668974\OneDrive - Universidad Autonoma de Guadalajara\4668974\EvaluacionEmpresa\Views\_ViewImports.cshtml"
using EvaluacionEmpresa.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ee7c073c47be2f4097f060e4e51b6d5f45606f9", @"/Views/Evaluacion/MisEmpresas.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20bbb6339f68f183b616c63198b50e402d181e52", @"/Views/_ViewImports.cshtml")]
    public class Views_Evaluacion_MisEmpresas : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"container\">\r\n    <div class=\"row\">\r\n        <h2 class=\"col-8 mb-4\"> ");
#nullable restore
#line 8 "C:\Users\4668974\OneDrive - Universidad Autonoma de Guadalajara\4668974\EvaluacionEmpresa\Views\Evaluacion\MisEmpresas.cshtml"
                           Write(ViewData["id"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n    </div>\r\n  \r\n    <div class=\"row col-12 container p-3 border\">\r\n");
#nullable restore
#line 12 "C:\Users\4668974\OneDrive - Universidad Autonoma de Guadalajara\4668974\EvaluacionEmpresa\Views\Evaluacion\MisEmpresas.cshtml"
         foreach (var empresas in ViewBag.misEmpresas)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\" row col-12 mb-3\">\r\n        <span class=\" col-3 text-center\">");
#nullable restore
#line 15 "C:\Users\4668974\OneDrive - Universidad Autonoma de Guadalajara\4668974\EvaluacionEmpresa\Views\Evaluacion\MisEmpresas.cshtml"
                                    Write(empresas.Empresa);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        <span class=\" col-3 text-center mr-3\">");
#nullable restore
#line 16 "C:\Users\4668974\OneDrive - Universidad Autonoma de Guadalajara\4668974\EvaluacionEmpresa\Views\Evaluacion\MisEmpresas.cshtml"
                                         Write(empresas.RazonSocial);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
        <a href=""#"" class=""btn btn-dark col-1 p-2 disabled ml-3"">Evaluar</a>
        <a href=""#"" class=""btn btn-dark col-2 p-2 disabled ml-3"">Ver evaluaci??n</a>
        <a href=""#"" class=""btn btn-dark col-2 p-2 disabled ml-3"">Descargar evaluaci??n</a>
    </div>
");
#nullable restore
#line 21 "C:\Users\4668974\OneDrive - Universidad Autonoma de Guadalajara\4668974\EvaluacionEmpresa\Views\Evaluacion\MisEmpresas.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
        }
        #pragma warning restore 1998
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
