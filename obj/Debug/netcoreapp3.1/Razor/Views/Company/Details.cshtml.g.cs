#pragma checksum "/Users/ogbaragodwin/Desktop/code360/EmployeeManagement/EmployeeManagement/Views/Company/Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5809358a3ad9dda07e179a0c6e057d66b7727402"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(EmployeeManagement.Views.Company.Views_Company_Details), @"mvc.1.0.view", @"/Views/Company/Details.cshtml")]
namespace EmployeeManagement.Views.Company
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
#line 3 "/Users/ogbaragodwin/Desktop/code360/EmployeeManagement/EmployeeManagement/Views/_ViewImports.cshtml"
using EmployeeManagement.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/ogbaragodwin/Desktop/code360/EmployeeManagement/EmployeeManagement/Views/_ViewImports.cshtml"
using EmployeeManagement.Model;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5809358a3ad9dda07e179a0c6e057d66b7727402", @"/Views/Company/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"45f928a36a3a6805fbc3dcc6fe69db23c2feb9c2", @"/Views/_ViewImports.cshtml")]
    public class Views_Company_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Company>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-default border"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: auto"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary mx-4"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "company", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "remove", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n\n    <div class=\"container\">\r\n        <div class=\"card\">\r\n            <div class=\"card-header bg-primary\">\r\n                <h4>");
#nullable restore
#line 7 "/Users/ogbaragodwin/Desktop/code360/EmployeeManagement/EmployeeManagement/Views/Company/Details.cshtml"
               Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n            </div>\r\n            <div class=\"card-body mt-4\">\r\n                <p>Address:   ");
#nullable restore
#line 10 "/Users/ogbaragodwin/Desktop/code360/EmployeeManagement/EmployeeManagement/Views/Company/Details.cshtml"
                         Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p>Contact Name:   ");
#nullable restore
#line 11 "/Users/ogbaragodwin/Desktop/code360/EmployeeManagement/EmployeeManagement/Views/Company/Details.cshtml"
                              Write(Model.ContactName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p>Contact Email:   ");
#nullable restore
#line 12 "/Users/ogbaragodwin/Desktop/code360/EmployeeManagement/EmployeeManagement/Views/Company/Details.cshtml"
                               Write(Model.ContactEmail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n        </div>\r\n\r\n");
#nullable restore
#line 16 "/Users/ogbaragodwin/Desktop/code360/EmployeeManagement/EmployeeManagement/Views/Company/Details.cshtml"
         if (Model.Employments != null && Model.Employments.Count > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""card mt-4"">
                <div class=""card-header"">
                    <h6>Employments</h6>
                </div>
                <div class=""card-body mt-4"">

                    <table class=""table table-striped table-responsive"">
                        <thead>
                            <tr>
                                <th>Student</th>
                                <th>Start Date</th>
                                <th>End Date</th>
                                <th>Salary</th>
                            </tr>
                        </thead>
");
#nullable restore
#line 33 "/Users/ogbaragodwin/Desktop/code360/EmployeeManagement/EmployeeManagement/Views/Company/Details.cshtml"
                         foreach (var employment in Model.Employments)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 36 "/Users/ogbaragodwin/Desktop/code360/EmployeeManagement/EmployeeManagement/Views/Company/Details.cshtml"
                               Write(_empRepository.GetStudent(employment.StudentId).Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 37 "/Users/ogbaragodwin/Desktop/code360/EmployeeManagement/EmployeeManagement/Views/Company/Details.cshtml"
                               Write(employment.StartDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 38 "/Users/ogbaragodwin/Desktop/code360/EmployeeManagement/EmployeeManagement/Views/Company/Details.cshtml"
                               Write(employment.EndDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 39 "/Users/ogbaragodwin/Desktop/code360/EmployeeManagement/EmployeeManagement/Views/Company/Details.cshtml"
                                 if (employment.Salary != null)
                                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td>");
#nullable restore
#line 42 "/Users/ogbaragodwin/Desktop/code360/EmployeeManagement/EmployeeManagement/Views/Company/Details.cshtml"
                                   Write(employment.Salary.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 43 "/Users/ogbaragodwin/Desktop/code360/EmployeeManagement/EmployeeManagement/Views/Company/Details.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td>Not stated yet</td>\r\n");
#nullable restore
#line 47 "/Users/ogbaragodwin/Desktop/code360/EmployeeManagement/EmployeeManagement/Views/Company/Details.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tr>\r\n");
#nullable restore
#line 49 "/Users/ogbaragodwin/Desktop/code360/EmployeeManagement/EmployeeManagement/Views/Company/Details.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </table>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 53 "/Users/ogbaragodwin/Desktop/code360/EmployeeManagement/EmployeeManagement/Views/Company/Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    <div class=\"card-footer mt-4\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5809358a3ad9dda07e179a0c6e057d66b772740211658", async() => {
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5809358a3ad9dda07e179a0c6e057d66b772740211927", async() => {
                    WriteLiteral("Back");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5809358a3ad9dda07e179a0c6e057d66b772740213334", async() => {
                    WriteLiteral("Edit");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 59 "/Users/ogbaragodwin/Desktop/code360/EmployeeManagement/EmployeeManagement/Views/Company/Details.cshtml"
                                   WriteLiteral(Model.CompanyId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n            <span");
                BeginWriteAttribute("id", " id=\"", 2397, "\"", 2436, 2);
                WriteAttributeValue("", 2402, "confirmDeleteSpan_", 2402, 18, true);
#nullable restore
#line 61 "/Users/ogbaragodwin/Desktop/code360/EmployeeManagement/EmployeeManagement/Views/Company/Details.cshtml"
WriteAttributeValue("", 2420, Model.CompanyId, 2420, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"display:none\">\r\n                Are You Sure?\r\n                <a class=\"btn btn-default border ml-4\" style=\"width: auto\"");
                BeginWriteAttribute("onclick", " onclick=\"", 2566, "\"", 2611, 4);
                WriteAttributeValue("", 2576, "deleteData(", 2576, 11, true);
#nullable restore
#line 63 "/Users/ogbaragodwin/Desktop/code360/EmployeeManagement/EmployeeManagement/Views/Company/Details.cshtml"
WriteAttributeValue("", 2587, Model.CompanyId, 2587, 16, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2603, ",", 2603, 1, true);
                WriteAttributeValue(" ", 2604, "false)", 2605, 7, true);
                EndWriteAttribute();
                WriteLiteral(">No</a>\r\n                <button type=\"submit\" class=\"btn btn-danger\" style=\"width: auto\">Yes</button>\r\n            </span>\r\n\r\n            <span");
                BeginWriteAttribute("id", " id=\"", 2756, "\"", 2788, 2);
                WriteAttributeValue("", 2761, "deleteSpan_", 2761, 11, true);
#nullable restore
#line 67 "/Users/ogbaragodwin/Desktop/code360/EmployeeManagement/EmployeeManagement/Views/Company/Details.cshtml"
WriteAttributeValue("", 2772, Model.CompanyId, 2772, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                <a class=\"btn btn-danger\" style=\"width: auto\"");
                BeginWriteAttribute("onclick", " onclick=\"", 2853, "\"", 2897, 4);
                WriteAttributeValue("", 2863, "deleteData(", 2863, 11, true);
#nullable restore
#line 68 "/Users/ogbaragodwin/Desktop/code360/EmployeeManagement/EmployeeManagement/Views/Company/Details.cshtml"
WriteAttributeValue("", 2874, Model.CompanyId, 2874, 16, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2890, ",", 2890, 1, true);
                WriteAttributeValue(" ", 2891, "true)", 2892, 6, true);
                EndWriteAttribute();
                WriteLiteral(">Delete</a>\r\n            </span>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 57 "/Users/ogbaragodwin/Desktop/code360/EmployeeManagement/EmployeeManagement/Views/Company/Details.cshtml"
                                                                           WriteLiteral(Model.CompanyId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n    </div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ISalary _salary { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IPayment _payment { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IEmployment _employment { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ICompany _company { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IEmployeeRepository _empRepository { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IProject _project { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Company> Html { get; private set; }
    }
}
#pragma warning restore 1591
