#pragma checksum "C:\Users\ssult\OneDrive\Desktop\Курсач эке\Library\Views\Administrator\Book.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c34292389107e1c0513bc216e272642fbc752835"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administrator_Book), @"mvc.1.0.view", @"/Views/Administrator/Book.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c34292389107e1c0513bc216e272642fbc752835", @"/Views/Administrator/Book.cshtml")]
    public class Views_Administrator_Book : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c34292389107e1c0513bc216e272642fbc7528353929", async() => {
                WriteLiteral("\r\n    <link href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css\" rel=\"stylesheet\" integrity=\"sha384-0evHe/X+R7YkIZDRvuzKMRqM+OrBnVFBL6DOitfPri4tjfHxaWutUpFmBp4vmVor\" crossorigin=\"anonymous\">\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c34292389107e1c0513bc216e272642fbc7528354423", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c34292389107e1c0513bc216e272642fbc7528356393", async() => {
                WriteLiteral(@"
 <div class=""topnav"">
  <a  href=""/Administrator/Employee"">Управление сотрудниками</a>
  <a class=""active"" href=""/Administrator/Book"">Упарвление книгами</a>
  <a href=""/Login"">Выход</a>
</div>

    <div class=""add_book"">
        <h1>Добавление новой книги</h1>
        <form class=""form"" action=""/Administrator/Add_Now_Book"">
                    <input type=""text"" placeholder=""Название книги"" name=""book_name"" />
                    <input type=""text"" placeholder=""Название автора"" name=""author_name"" />
                    <input type=""text"" placeholder=""Название издателя"" name=""publisher"" />
                    <input type=""text"" placeholder=""Жанр"" name=""genre"" />
                    <input type=""number"" placeholder=""Количество экземпляров"" name=""count"" />
                    <input type=""number"" placeholder=""Количество страниц"" name=""pages"" />
                    <input type=""date"" placeholder=""Дата"" name=""year"" />
                    <br /><button class=""button2"" type=""submit"">Добавить новую ");
                WriteLiteral(@"книгу</button>
        </form>
                    
    </div>

    <div class=""add_books"">
        <h1>Добавление экземпляров книг</h1>
        <form class=""form"" action=""/Administrator/Add_Book"">
                    <input type=""text"" placeholder=""Название книги"" name=""book_name""/>
                    <input type=""number"" placeholder=""Количество"" name=""count"" />
                    <br /><button class=""button2"" type=""submit"">Добавить книги</button>
        </form>
         
    </div>

");
#nullable restore
#line 38 "C:\Users\ssult\OneDrive\Desktop\Курсач эке\Library\Views\Administrator\Book.cshtml"
     foreach (var m in @ViewBag.Messages)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\ssult\OneDrive\Desktop\Курсач эке\Library\Views\Administrator\Book.cshtml"
         if (@m.str_message != "")
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "C:\Users\ssult\OneDrive\Desktop\Курсач эке\Library\Views\Administrator\Book.cshtml"
             if (@m.error == true)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <div id=\"Message\" onclick=\"Close_Message()\">\r\n                    <h3>\"Ошибка: \" ");
#nullable restore
#line 45 "C:\Users\ssult\OneDrive\Desktop\Курсач эке\Library\Views\Administrator\Book.cshtml"
                              Write(m.str_message);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n                </div>\r\n");
#nullable restore
#line 47 "C:\Users\ssult\OneDrive\Desktop\Курсач эке\Library\Views\Administrator\Book.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <div id=\"Message\" onclick=\"Close_Message()\">\r\n                    <h3>");
#nullable restore
#line 51 "C:\Users\ssult\OneDrive\Desktop\Курсач эке\Library\Views\Administrator\Book.cshtml"
                   Write(m.str_message);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n                </div>\r\n");
#nullable restore
#line 53 "C:\Users\ssult\OneDrive\Desktop\Курсач эке\Library\Views\Administrator\Book.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "C:\Users\ssult\OneDrive\Desktop\Курсач эке\Library\Views\Administrator\Book.cshtml"
             
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "C:\Users\ssult\OneDrive\Desktop\Курсач эке\Library\Views\Administrator\Book.cshtml"
         
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <div class=\"all_books\">\r\n        <h1>Список книг</h1>\r\n");
#nullable restore
#line 59 "C:\Users\ssult\OneDrive\Desktop\Курсач эке\Library\Views\Administrator\Book.cshtml"
         foreach (var b in @ViewBag.Books)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"book\">\r\n                <h3>");
#nullable restore
#line 62 "C:\Users\ssult\OneDrive\Desktop\Курсач эке\Library\Views\Administrator\Book.cshtml"
               Write(b.name_book);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n               \r\n            </div>\r\n");
#nullable restore
#line 65 "C:\Users\ssult\OneDrive\Desktop\Курсач эке\Library\Views\Administrator\Book.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    </div>\r\n\r\n    <script>\r\n        function Close_Message() {\r\n            document.getElementById(\"Message\").remove();\r\n        }\r\n    </script>\r\n");
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
            WriteLiteral("\r\n</html>");
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