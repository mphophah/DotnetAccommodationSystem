#pragma checksum "C:\My Stuff\Projects\Vesion2-master\ams\Views\InvoicePdf\Demo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5c05804b4c4084fe42f68ad0b9c4d36bc0b8ed1a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_InvoicePdf_Demo), @"mvc.1.0.view", @"/Views/InvoicePdf/Demo.cshtml")]
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
#line 1 "C:\My Stuff\Projects\Vesion2-master\ams\Views\_ViewImports.cshtml"
using AMS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\My Stuff\Projects\Vesion2-master\ams\Views\_ViewImports.cshtml"
using AMS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c05804b4c4084fe42f68ad0b9c4d36bc0b8ed1a", @"/Views/InvoicePdf/Demo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a6073a0a48752a8ae8ae1e3cae9d0dae4f64f62", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_InvoicePdf_Demo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\My Stuff\Projects\Vesion2-master\ams\Views\InvoicePdf\Demo.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<!DOCTYPE html>\n\n<html>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5c05804b4c4084fe42f68ad0b9c4d36bc0b8ed1a3420", async() => {
                WriteLiteral(@"
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"">
    <style>
        .grey-header {
            color: #888;
            font-weight: bold;
        }
        .bigger-bolder {
            font-size: 18px;
            font-weight: bold;
        }
        .double-border {
            border-top: 6px double #555;
        }
        .left-border {
            padding-left: 10px;
            border-left: 1px solid #ddd;
        }
        .address {
            line-height: .9;
        }
    </style>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5c05804b4c4084fe42f68ad0b9c4d36bc0b8ed1a4940", async() => {
                WriteLiteral(@"

<div style=""margin-top: 50px;"">
    <div class=""row"">
        <div class=""col-xs-9"">
            <h1>INVOICE</h1>
        </div>
        <div class=""col-xs-3"">
            <div class=""row"">
                <div class=""col-xs-4"" style=""margin-right: -20px;"">
                    <div class=""text-right"">
                        <div class=""grey-header"">
                            From
                        </div>
                    </div>
                </div>
                <div class=""col-xs-8"">
                    <div class=""left-border address"">
                        <p>
                            <strong>Company Name</strong>
                        </p>
                        <p>123 Fake Street</p>
                        <p>Kingston, ON K0G 1J0</p>
                        <p>Canada</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""row"" style=""padding-top: 50px;"">
        <div class=""col-xs-9"">
            <div class=""row"">
     ");
                WriteLiteral(@"           <div class=""col-xs-2"" style=""margin-right: -70px;"">
                    <div class=""grey-header"">
                        <p>Invoice #</p>
                        <p>Issue Date</p>
                        <p>Due Date</p>
                    </div>
                </div>
                <div class=""col-xs-10"">
                    <div class=""left-border"">
                        <p>005</p>
                        <p>May 15, 2020</p>
                        <p>June 15, 2020</p>
                    </div>
                </div>
            </div>
        </div>
        <div class=""col-xs-3"">
            <div class=""row"">
                <div class=""col-xs-4"" style=""margin-right: -20px;"">
                    <div class=""text-right"">
                        <div class=""grey-header"">
                            To
                        </div>
                    </div>
                </div>
                <div class=""col-xs-8"">
                    <div class=""left-border address"">
                   ");
                WriteLiteral(@"     <p>
                            <strong>Customer Name</strong>
                        </p>
                        <p>456 Fake Street</p>
                        <p>Ottawa, ON K0G 1J0</p>
                        <p>Canada</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""row"" style=""padding-top: 50px;"">
        <div class=""col-xs-12"">
            <table class=""table table-striped"">
                <thead>
                <tr>
                    <th>Description</th>
                    <th>Units/Hours</th>
                    <th>Price Per Unit/Hour</th>
                    <th>Item Total</th>
                </tr>
                </thead>
                <tbody>
                <tr>
                    <td>Web Development</td>
                    <td>3.5</td>
                    <td>2</td>
                    <td>$105</td>
                </tr>
                </tbody>
                <tfoot>
                <tr class=""double-border info""");
                WriteLiteral(@">
                    <td></td>
                    <td></td>
                    <td class=""text-right bigger-bolder"">
                        Total Due
                    </td>
                    <td class=""bigger-bolder"">
                        $200
                    </td>
                </tr>
                </tfoot>
            </table>
        </div>
    </div>
</div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
