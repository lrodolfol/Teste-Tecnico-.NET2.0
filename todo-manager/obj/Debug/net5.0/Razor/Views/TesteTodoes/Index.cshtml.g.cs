#pragma checksum "C:\Users\rodolfo.jesus\Documents\Csharp\todo-manager\todo-manager\Views\TesteTodoes\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f53055e7b7db1faded05a5237c044e61dbb5af29"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TesteTodoes_Index), @"mvc.1.0.view", @"/Views/TesteTodoes/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f53055e7b7db1faded05a5237c044e61dbb5af29", @"/Views/TesteTodoes/Index.cshtml")]
    #nullable restore
    public class Views_TesteTodoes_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<todo_manager.Models.Entitie.Todo>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\rodolfo.jesus\Documents\Csharp\todo-manager\todo-manager\Views\TesteTodoes\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    <a asp-action=\"Create\">Create New</a>\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\rodolfo.jesus\Documents\Csharp\todo-manager\todo-manager\Views\TesteTodoes\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\rodolfo.jesus\Documents\Csharp\todo-manager\todo-manager\Views\TesteTodoes\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.UserStory));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\rodolfo.jesus\Documents\Csharp\todo-manager\todo-manager\Views\TesteTodoes\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DeadLine));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\rodolfo.jesus\Documents\Csharp\todo-manager\todo-manager\Views\TesteTodoes\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Priority));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 31 "C:\Users\rodolfo.jesus\Documents\Csharp\todo-manager\todo-manager\Views\TesteTodoes\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 34 "C:\Users\rodolfo.jesus\Documents\Csharp\todo-manager\todo-manager\Views\TesteTodoes\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "C:\Users\rodolfo.jesus\Documents\Csharp\todo-manager\todo-manager\Views\TesteTodoes\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.UserStory));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 40 "C:\Users\rodolfo.jesus\Documents\Csharp\todo-manager\todo-manager\Views\TesteTodoes\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.DeadLine));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 43 "C:\Users\rodolfo.jesus\Documents\Csharp\todo-manager\todo-manager\Views\TesteTodoes\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Priority.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <a asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1183, "\"", 1206, 1);
#nullable restore
#line 46 "C:\Users\rodolfo.jesus\Documents\Csharp\todo-manager\todo-manager\Views\TesteTodoes\Index.cshtml"
WriteAttributeValue("", 1198, item.Id, 1198, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n                <a asp-action=\"Details\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1259, "\"", 1282, 1);
#nullable restore
#line 47 "C:\Users\rodolfo.jesus\Documents\Csharp\todo-manager\todo-manager\Views\TesteTodoes\Index.cshtml"
WriteAttributeValue("", 1274, item.Id, 1274, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Details</a> |\r\n                <a asp-action=\"Delete\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1337, "\"", 1360, 1);
#nullable restore
#line 48 "C:\Users\rodolfo.jesus\Documents\Csharp\todo-manager\todo-manager\Views\TesteTodoes\Index.cshtml"
WriteAttributeValue("", 1352, item.Id, 1352, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 51 "C:\Users\rodolfo.jesus\Documents\Csharp\todo-manager\todo-manager\Views\TesteTodoes\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<todo_manager.Models.Entitie.Todo>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
