#pragma checksum "D:\dev\StatsOutcast\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "96c8f6dbd1fe15adb0655137b9d46e7f16b651dd"
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
#line 1 "D:\dev\StatsOutcast\Views\_ViewImports.cshtml"
using StatsOutcast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\dev\StatsOutcast\Views\_ViewImports.cshtml"
using StatsOutcast.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96c8f6dbd1fe15adb0655137b9d46e7f16b651dd", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d59d7e449f8be95277046abbe6f3528d356ceb2c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ListasModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Grafico", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "loot", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<link rel=""stylesheet"" type=""text/css"" href=""https://cdn.datatables.net/1.11.5/css/jquery.dataTables.css"">

<div class=""text-center"">

    <!-- Begin Page Content -->
    <div class=""container-fluid"">

        <!-- Page Heading -->
        <div class=""d-sm-flex align-items-center justify-content-between mb-4"">
            <h1 class=""h3 mb-0 text-gray-800"">Outcast Server Stats</h1>

        </div>

        <!-- Content Row -->
        <div class=""row"">

            <!-- Earnings (Monthly) Card Example -->
            <div class=""col-xl-3 col-md-6 mb-4"">
                <div class=""card border-left-primary shadow h-100 py-2"">
                    <div class=""card-body"">
                        <div class=""row no-gutters align-items-center"">
                            <div class=""col mr-2"">
                                <div class=""text-xs font-weight-bold text-primary text-uppercase mb-1"">
                                    Last droped item
                                </div>
    ");
            WriteLiteral("                            <div class=\"h5 mb-0 font-weight-bold text-gray-800\">");
#nullable restore
#line 30 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                                                               Write(Model.Loots.First().Item);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-xl-3 col-md-6 mb-4"">
                <div class=""card border-left-primary shadow h-100 py-2"">
                    <div class=""card-body"">
                        <div class=""row no-gutters align-items-center"">
                            <div class=""col mr-2"">
                                <div class=""text-xs font-weight-bold text-primary text-uppercase mb-1"">
                                    First droped item
                                </div>
                                <div class=""h5 mb-0 font-weight-bold text-gray-800"">");
#nullable restore
#line 45 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                                                               Write(Model.Loots.Last().Item);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

            <!-- Earnings (Monthly) Card Example -->
            <div class=""col-xl-3 col-md-6 mb-4"">
                <div class=""card border-left-success shadow h-100 py-2"">
                    <div class=""card-body"">
                        <div class=""row no-gutters align-items-center"">
                            <div class=""col mr-2"">
                                <div class=""text-xs font-weight-bold text-success text-uppercase mb-1"">
                                    Rarest Loot - Quantity
                                </div>
                                <div class=""h5 mb-0 font-weight-bold text-gray-800"">");
#nullable restore
#line 62 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                                                               Write(Model.LootsMaisRaros.First().Item);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 62 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                                                                                                    Write(Model.LootsMaisRaros.First().Quantidade);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

            <!-- Earnings (Monthly) Card Example -->
            <div class=""col-xl-3 col-md-6 mb-4"">
                <div class=""card border-left-info shadow h-100 py-2"">
                    <div class=""card-body"">
                        <div class=""row no-gutters align-items-center"">
                            <div class=""col mr-2"">
                                <div class=""text-xs font-weight-bold text-info text-uppercase mb-1"">
                                    Commonest loot - Quantity
                                </div>
                                <div class=""row no-gutters align-items-center"">
                                    <div class=""col-auto"">
                                        <div class=""h5 mb-0 mr-3 font-weight-bold text-gray-800"">");
#nullable restore
#line 81 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                                                                            Write(Model.LootsMaisRaros.Last().Item);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 81 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                                                                                                                Write(Model.LootsMaisRaros.Last().Quantidade);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </div>
                                    </div>

                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>


        </div>
        <div class=""row"">

            <!-- Pending Requests Card Example -->
            <div class=""col-xl-3 col-md-6 mb-4"">
                <div class=""card border-left-warning shadow h-100 py-2"">
                    <div class=""card-body"">
                        <div class=""row no-gutters align-items-center"">
                            <div class=""col mr-2"">
                                <div class=""text-xs font-weight-bold text-warning text-uppercase mb-1"">
                                    Boss with more drops
                                </div>
                                <div class=""h5 mb-0 font-weight-bold text-gray-800"">");
#nullable restore
#line 105 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                                                               Write(Model.BossesAndTheirLoots.Last().NomeBoss);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 105 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                                                                                                            Write(Model.BossesAndTheirLoots.Last().QuantidadeLoots);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-xl-3 col-md-6 mb-4"">
                <div class=""card border-left-primary shadow h-100 py-2"">
                    <div class=""card-body"">
                        <div class=""row no-gutters align-items-center"">
                            <div class=""col mr-2"">
                                <div class=""text-xs font-weight-bold text-primary text-uppercase mb-1"">
                                    Loots per day (Average)
                                </div>
                                <div class=""h5 mb-0 font-weight-bold text-gray-800"">");
#nullable restore
#line 120 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                                                               Write(Model.QuantidadePorDia);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

            <!-- Earnings (Monthly) Card Example -->
            <div class=""col-xl-3 col-md-6 mb-4"">
                <div class=""card border-left-success shadow h-100 py-2"">
                    <div class=""card-body"">
                        <div class=""row no-gutters align-items-center"">
                            <div class=""col mr-2"">
                                <div class=""text-xs font-weight-bold text-success text-uppercase mb-1"">
                                    Loots per month (Average)
                                </div>
                                <div class=""h5 mb-0 font-weight-bold text-gray-800"">");
#nullable restore
#line 137 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                                                               Write(Model.QuantidadePorMes);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

            <!-- Earnings (Monthly) Card Example -->
            <div class=""col-xl-3 col-md-6 mb-4"">
                <div class=""card border-left-info shadow h-100 py-2"">
                    <div class=""card-body"">
                        <div class=""row no-gutters align-items-center"">
                            <div class=""col mr-2"">
                                <div class=""text-xs font-weight-bold text-info text-uppercase mb-1"">
                                    Loots per year (Average)
                                </div>

                                <div class=""h5 mb-0 mr-3 font-weight-bold text-gray-800"">");
#nullable restore
#line 155 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                                                                    Write(Model.QuantidadePorAno);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </div>

                            </div>

                        </div>
                    </div>
                </div>
            </div>


        </div>




        <div class=""row"">
            <div class=""col-xl-12 col-lg-12"">
                <div class=""card shadow mb-4"">
                    <!-- Card Header - Dropdown -->
                    <div class=""card-header py-3 d-flex flex-row align-items-center justify-content-between"">
                        <h6 class=""m-0 font-weight-bold text-primary"">Last 1000 loots</h6>

                    </div>
                    <!-- Card Body -->
                    <div class=""card-body"">
                        <div class=""col-sm"">
                            <table id=""tabelaLoot"" class=""table table-bordered table-hover display compact"">
                                <thead>
                                    <tr>
                                        <th>Id</th>
                                        <th class=""nosort""");
            WriteLiteral(">Date</th>\r\n                                        <th>Item</th>\r\n                                        <th>Boss</th>\r\n                                    </tr>\r\n                                </thead>\r\n                                <tbody>\r\n\r\n");
#nullable restore
#line 192 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                      
                                        int contador = 1000;
                                        foreach (var item in Model.Loots.Take(1000))
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td>");
#nullable restore
#line 197 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                               Write(contador);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 198 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                               Write(item.Data);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
            WriteLiteral("                                                <td>");
#nullable restore
#line 200 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                               Write(item.Item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "96c8f6dbd1fe15adb0655137b9d46e7f16b651dd16623", async() => {
#nullable restore
#line 201 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                                                                                                             Write(item.Boss);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-bossName", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 201 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                                                                                          WriteLiteral(item.Boss);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["bossName"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-bossName", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["bossName"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n\r\n                                            </tr>\r\n");
#nullable restore
#line 204 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                            contador--;
                                        }
                                    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </tbody>
                                <tfoot>

                                </tfoot>
                            </table>



                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=""row"">

            <!-- Area Chart -->
            <div class=""col-xl-6 col-lg-6"">
                <div class=""card shadow mb-4"">
                    <!-- Card Header - Dropdown -->
                    <div class=""card-header py-3 d-flex flex-row align-items-center justify-content-between"">
                        <h6 class=""m-0 font-weight-bold text-primary"">Rarest items by quantity</h6>

                    </div>
                    <!-- Card Body -->
                    <div class=""card-body"">


                        <table id=""tabelaLootQuantidade"" class=""table table-bordered table-hover display compact"">
                            <thead>
                                <tr>

");
            WriteLiteral("\n                                    <th>Item</th>\r\n                                    <th>Qty</th>\r\n                                </tr>\r\n                            </thead>\r\n                            <tbody>\r\n\r\n\r\n");
#nullable restore
#line 246 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                  

                                    foreach (var item in Model.LootsMaisRaros)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n\r\n\r\n");
            WriteLiteral("                                            <td>");
#nullable restore
#line 254 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                           Write(item.Item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                                            <td>");
#nullable restore
#line 256 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                           Write(item.Quantidade);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        </tr>\r\n");
#nullable restore
#line 258 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"

                                    }
                                

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </tbody>
                            <tfoot>

                            </tfoot>
                        </table>

                    </div>
                </div>
            </div>
            <div class=""col-lg-6 mb-4"">

                <!-- Project Card Example -->
                <div class=""card shadow mb-4"">
                    <div class=""card-header py-3"">
                        <h6 class=""m-0 font-weight-bold text-primary"">Top 14 rarest items by quantity</h6>
                    </div>
                    <div class=""card-body"">
");
#nullable restore
#line 279 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                          
                            List<string> cores = new List<string>();
                            cores.Add("darkred");
                            cores.Add("darkred");
                            cores.Add("darkred");
                            cores.Add("red");
                            cores.Add("red");
                            cores.Add("darkorange");
                            cores.Add("darkorange");
                            cores.Add("orange");
                            cores.Add("orange");
                            cores.Add("yellow");
                            cores.Add("yellow");
                            cores.Add("yellow");
                            cores.Add("#ccff66");
                            cores.Add("#ccff66");
                            cores.Add("#ccff66");
                            cores.Add("#ccff66");
                            cores.Add("#ccff66");
                            cores.Add("#ccff66");
                            cores.Add("#ccff66");
                            cores.Add("lawngreen");
                            cores.Add("lawngreen");
                            cores.Add("lawngreen");
                            cores.Add("lawngreen");
                            cores.Add("lawngreen");
                            cores.Add("lawngreen");


                            foreach (var item in Model.LootsMaisRaros.Take(14).ToList())
                            {
                                Int32 porcentagem = Convert.ToInt32((item.Quantidade * 100) / @Model.LootsMaisRaros.Take(14).Last().Quantidade);
                                string cor = item.Quantidade > cores.Count ? cores.Last() : cores[item.Quantidade];

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <h4 class=\"small font-weight-bold\" style=\"margin: 1px 2px 1px 2px !important; padding: 0 0 0 0\">\r\n                                    ");
#nullable restore
#line 313 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                               Write(item.Item);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span class=\"float-right\">");
#nullable restore
#line 313 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                                                    Write(item.Quantidade);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </span>
                                </h4>
                                <div class=""progress mb-4"" style=""height: 10px; margin: 1px 2px 1px 2px !important; padding: 0 0 0 0"">
                                    <div class=""progress-bar"" role=""progressbar""");
            BeginWriteAttribute("style", " style=\"", 14139, "\"", 14246, 18);
            WriteAttributeValue("", 14147, "background-color:", 14147, 17, true);
#nullable restore
#line 316 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
WriteAttributeValue("", 14164, cor, 14164, 4, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 14168, ";", 14168, 1, true);
            WriteAttributeValue(" ", 14169, "padding:", 14170, 9, true);
            WriteAttributeValue(" ", 14178, "0", 14179, 2, true);
            WriteAttributeValue(" ", 14180, "0", 14181, 2, true);
            WriteAttributeValue(" ", 14182, "0", 14183, 2, true);
            WriteAttributeValue(" ", 14184, "0;", 14185, 3, true);
            WriteAttributeValue(" ", 14187, "margin:", 14188, 8, true);
            WriteAttributeValue(" ", 14195, "1px", 14196, 4, true);
            WriteAttributeValue(" ", 14199, "2px", 14200, 4, true);
            WriteAttributeValue(" ", 14203, "1px", 14204, 4, true);
            WriteAttributeValue(" ", 14207, "2px", 14208, 4, true);
            WriteAttributeValue(" ", 14211, "!important;", 14212, 12, true);
            WriteAttributeValue(" ", 14223, "width:", 14224, 7, true);
#nullable restore
#line 316 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
WriteAttributeValue(" ", 14230, porcentagem, 14231, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 14243, "%;", 14243, 2, true);
            WriteAttributeValue(" ", 14245, "", 14246, 1, true);
            EndWriteAttribute();
            BeginWriteAttribute("aria-valuenow", "\r\n                                         aria-valuenow=\"", 14247, "\"", 14321, 1);
#nullable restore
#line 317 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
WriteAttributeValue("", 14305, item.Quantidade, 14305, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-valuemin=\"0\"");
            BeginWriteAttribute("aria-valuemax", " aria-valuemax=\"", 14340, "\"", 14404, 1);
#nullable restore
#line 317 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
WriteAttributeValue("", 14356, Model.LootsMaisRaros.Take(14).Last().Quantidade, 14356, 48, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></div>\r\n                                </div>\r\n");
#nullable restore
#line 319 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"

                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                    </div>
                </div>

                <!-- Color System -->


            </div>


        </div>





        <!-- Content Row -->
        <div class=""row"">

            <!-- Content Column -->
            <div class=""col-xl-6 col-lg-6"">
                <div class=""card shadow mb-4"">
                    <!-- Card Header - Dropdown -->
                    <div class=""card-header py-3 d-flex flex-row align-items-center justify-content-between"">
                        <h6 class=""m-0 font-weight-bold text-primary"">Boss Rank by quantity</h6>

                    </div>
                    <!-- Card Body -->
                    <div class=""card-body"">


                        <table id=""tabelaBossQuantidade"" class=""table table-bordered table-hover display compact"">
                            <thead>
                                <tr>


                                    <th>Boss</th>
                                    <th>Qty</th>
       ");
            WriteLiteral("                         </tr>\r\n                            </thead>\r\n                            <tbody>\r\n\r\n\r\n");
#nullable restore
#line 366 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                  

                                    foreach (var item in Model.BossesAndTheirLoots)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n\r\n\r\n");
            WriteLiteral("\r\n                                            <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "96c8f6dbd1fe15adb0655137b9d46e7f16b651dd29970", async() => {
#nullable restore
#line 375 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                                                                                                             Write(item.NomeBoss);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-bossName", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 375 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                                                                                      WriteLiteral(item.NomeBoss);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["bossName"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-bossName", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["bossName"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 376 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                           Write(item.QuantidadeLoots);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        </tr>\r\n");
#nullable restore
#line 378 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"

                                    }
                                

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </tbody>
                            <tfoot>

                            </tfoot>
                        </table>

                    </div>
                </div>
            </div>

         
        </div>
        <div class=""row"">
            <div class=""col-xl-12 col-lg-12"">
                <div class=""card shadow mb-4"">
                    <!-- Card Header - Dropdown -->
                    <div class=""card-header py-3 d-flex flex-row align-items-center justify-content-between"">
                        <h6 class=""m-0 font-weight-bold text-primary"">Players Top level</h6>

                    </div>
                    <!-- Card Body -->
                    <div class=""card-body"">


                        <table id=""tabelaPlayerTop"" class=""table table-bordered table-hover display compact"">
                            <thead>
                                <tr>
                                    <th>Rank</th>
                                  ");
            WriteLiteral(@"  <th>Name</th>
                                    <th>Level</th>
                                    <th>Magic Level</th>
                                    <th>Vocation</th>                                    
                                    <th>Guild</th>
                                    <th>Gender</th>
                                    <th>Age</th>
                                    <th>Lvls/day</th>
                                </tr>
                            </thead>
                            <tbody>


");
#nullable restore
#line 423 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                  

                                    foreach (var item in Model.Players)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n\r\n\r\n");
            WriteLiteral("                                            <td>");
#nullable restore
#line 431 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                           Write(item.Rank);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 432 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                           Write(item.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 433 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                           Write(item.Level);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 434 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                           Write(item.MagicLevel);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 435 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                           Write(item.Vocation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 436 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                           Write(item.Guild);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 437 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                           Write(item.Gender);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 438 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                           Write(item.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 439 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"
                                           Write(item.LevelPerDayAvg.ToString("0.0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                          \r\n                                        </tr>\r\n");
#nullable restore
#line 442 "D:\dev\StatsOutcast\Views\Home\Index.cshtml"

                                    }
                                

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </tbody>
                            <tfoot>

                            </tfoot>
                        </table>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /.container-fluid -->
</div>




");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <!-- JS -->\r\n\r\n    <script type=\"text/javascript\" charset=\"utf8\" src=\"https://cdn.datatables.net/1.11.5/js/jquery.dataTables.js\"></script>\r\n    <script>\r\n\r\n     \r\n\r\n    </script>\r\n");
            }
            );
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ListasModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
