using Microsoft.AspNetCore.Mvc;
using System;
using IronPdfWatermark.Logic.Services;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using IronPdfWatermark.Logic.Constants;

namespace IronPdfWatermark.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPdfService _pdfService;
        private readonly IWebHostEnvironment _env;

        public HomeController( IPdfService pdfService, IWebHostEnvironment env)
        {
            _pdfService = pdfService;

            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return Error();
        }

        [HttpGet]
        public IActionResult DownloadPdf()
        {
            try
            {
                var bundlePath = Path.Combine(_env.WebRootPath, "css", "views", "pdf.css");
                var html = GetTestHtml();
                var pngBinaryData = System.IO.File.ReadAllBytes(_env.WebRootFileProvider.GetFileInfo("assets/images/ais-logo.png")?.PhysicalPath);
                var imgDataURI = @"data:image/png;base64," + Convert.ToBase64String(pngBinaryData);
                html = html.Replace("/assets/images/ais-logo.png", imgDataURI);

                var title = $"10006-Test-Estimate";
                var filename = $"{title}.pdf";

                var doc = _pdfService.HtmlToPdf(html, true, StandardPrintOptions.Build(bundlePath, true, title));

                return File(doc.Stream, "application/pdf", filename);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        private string GetTestHtml()
        {
            var result = @"<style>
                                *,::after,::before{box-sizing:border-box;}
                                strong{font-weight:bolder;}
                                img{vertical-align:middle;border-style:none;}
                                table{border-collapse:collapse;}
                                th{text-align:inherit;}
                                label{display:inline-block;margin-bottom:.5rem;}
                                .row{display:-ms-flexbox;display:flex;-ms-flex-wrap:wrap;flex-wrap:wrap;margin-right:-15px;margin-left:-15px;}
                                .col,.col-12,.col-4,.col-5,.col-7,.col-8{position:relative;width:100%;padding-right:15px;padding-left:15px;}
                                .col{-ms-flex-preferred-size:0;flex-basis:0;-ms-flex-positive:1;flex-grow:1;max-width:100%;}
                                .col-4{-ms-flex:0 0 33.333333%;flex:0 0 33.333333%;max-width:33.333333%;}
                                .col-5{-ms-flex:0 0 41.666667%;flex:0 0 41.666667%;max-width:41.666667%;}
                                .col-7{-ms-flex:0 0 58.333333%;flex:0 0 58.333333%;max-width:58.333333%;}
                                .col-8{-ms-flex:0 0 66.666667%;flex:0 0 66.666667%;max-width:66.666667%;}
                                .col-12{-ms-flex:0 0 100%;flex:0 0 100%;max-width:100%;}
                                .table{width:100%;margin-bottom:1rem;color:#212529;}
                                .table td,.table th{padding:.75rem;vertical-align:top;border-top:1px solid #dee2e6;}
                                .table thead th{vertical-align:bottom;border-bottom:2px solid #dee2e6;}
                                .table-sm td,.table-sm th{padding:.3rem;}
                                .table-borderless td,.table-borderless th,.table-borderless thead th{border:0;}
                                .bg-dark{background-color:#343a40!important;}
                                .float-right{float:right!important;}
                                .position-absolute{position:absolute!important;}
                                .w-100{width:100%!important;}
                                .mt-1{margin-top:.25rem!important;}
                                .mt-4{margin-top:1.5rem!important;}
                                .py-1{padding-top:.25rem!important;}
                                .pr-1{padding-right:.25rem!important;}
                                .py-1{padding-bottom:.25rem!important;}
                                .pb-2{padding-bottom:.5rem!important;}
                                .pb-4{padding-bottom:1.5rem!important;}
                                .px-5{padding-right:3rem!important;}
                                .px-5{padding-left:3rem!important;}
                                .mx-auto{margin-right:auto!important;}
                                .mx-auto{margin-left:auto!important;}
                                .text-nowrap{white-space:nowrap!important;}
                                .text-right{text-align:right!important;}
                                .text-center{text-align:center!important;}
                                .text-uppercase{text-transform:uppercase!important;}
                                .text-white{color:#fff!important;}
                                @media print{
                                *,::after,::before{text-shadow:none!important;box-shadow:none!important;}
                                thead{display:table-header-group;}
                                img,tr{page-break-inside:avoid;}
                                .table{border-collapse:collapse!important;}
                                .table td,.table th{background-color:#fff!important;}
                                }
                                .bottom-0{bottom:0!important;}
                                *:focus{outline:none;}
                                table{table-layout:auto;}
                                ::placeholder{color:#929292!important;opacity:1;}
                                :-ms-input-placeholder{color:#929292!important;}
                                ::-ms-input-placeholder{color:#929292!important;}
                                .inspection-types span:not(:last-child):after{content:"", "";}
                                .font-georgia{font-family:Georgia,'Times New Roman'!important;}
                                .text-11{font-size:11px!important;}
                                .text-13{font-size:13px!important;}
                                .text-14{font-size:14px!important;}
                                .text-16{font-size:16px!important;}
                                .w-10{width:10%!important;}
                            </style>


                            <div id=""pdfPreview"" class=""pdf-preview w-100"">
                                <div class=""font-georgia text-13 mx-auto"">
                                    <div class=""row"">
                                        <div class=""col-8"">
                                            <div><img id=""logo"" src=""/assets/images/ais-logo.png"" width=""200""></div>
                                            <div><label class=""bg-dark text-center text-white text-uppercase mt-4 px-5 py-1 text-16"">Estimate</label></div>
                                        </div>
                                        <div class=""col-4"">
                                            <div class=""row"">
                                                <div class=""col-12 float-right text-right text-11"">
                                                    <div>1418 Airlane Drive</div>
                                                    <div>Benton, AR 72015</div>
                                                    <div>Phone: (501) 776-8454</div>
                                                    <div>Fax: (501) 315-9042</div>
                                                    <div>www.appliedinspection.com</div>
                                                </div>
                                            </div>
                                            <div class=""row col position-absolute bottom-0 text-14"">
                                                <div class=""w-100 text-right"">
                                                    <br>
                                                    <label><strong>Expires 9/14/2020</strong></label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-12"">
                                            <table class=""table table-sm table-borderless mt-1"">
                                                <thead>
                                                    <tr>
                                                        <th colspan=""5"">
                                                            <label class=""bg-dark text-center text-white text-uppercase mt-4 px-5 py-1 text-16 w-100"">General Information</label>
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td class=""pb-2"">
                                                            <strong>Company:</strong>
                                                        </td>
                                                        <td class=""pb-2"">
                                                            Test Company
                                                        </td>
                                                        <td class=""w-10 pb-2""></td>
                                                        <td class=""pb-2"">
                                                            <strong>Quote #:</strong>
                                                        </td>
                                                        <td class=""pb-2"">
                                                            10006
                                                        </td>
                                                    </tr>
    
                                                    <tr>
                                                        <td class=""pb-2"">
                                                            <strong>Requested By:</strong>
                                                        </td>
                                                        <td class=""pb-2"">
                                                            John Deere
                                                        </td>
                                                        <td class=""w-10 pb-2""></td>
                                                        <td class=""pb-2"">
                                                            <strong>Date:</strong>
                                                        </td>
                                                        <td class=""pb-2"">
                                                            8/4/2020
                                                        </td>
                                                    </tr>
    
                                                    <tr>
                                                        <td class=""pb-2"">
                                                            <strong>Phone:</strong>
                                                        </td>
                                                        <td class=""pb-2"">
                                                            +1 (501) 555-1234
                                                        </td>
                                                        <td class=""w-10 pb-2""></td>
                                                        <td class=""pb-2"">
                                                            <strong>Prepared By:</strong>
                                                        </td>
                                                        <td class=""pb-2"">
                                                            Aaron Dixon
                                                        </td>
                                                    </tr>
    
                                                    <tr>
                                                        <td>
                                                            <strong>Customer Email:</strong>
                                                        </td>
                                                        <td>
                                                            john.deere@gmail.com
                                                        </td>
                                                        <td class=""w-10""></td>
                                                        <td>
                                                            <strong>AIS Email:</strong>
                                                        </td>
                                                        <td>
                                                            aaron.dixon@appliedinspection.com
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-12"">
                                            <table class=""table table-sm table-borderless"">
                                                <thead>
                                                    <tr>
                                                        <th colspan=""2"">
                                                            <label class=""bg-dark text-center text-white text-uppercase mt-4 px-5 py-1 text-16 w-100"">Project Information</label>
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td class=""pb-2 pr-1"" style=""width: 180px;"">
                                                            <strong class=""text-nowrap"">Test Method(s):</strong>
                                                        </td>
                                                        <td class=""pb-2 inspection-types"">
                                                                    <span>AE</span>
                                                                    <span>AUT</span>
                                                        </td>
                                                    </tr>
    
                                                    <tr>
                                                        <td class=""pr-1"" style=""width: 180px;"">
                                                            <strong class=""text-nowrap"">Work Scope:</strong>
                                                        </td>
                                                        <td>
                                                            Test
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-12"">
                                            <table class=""table table-sm table-borderless"">
                                                <thead>
                                                    <tr>
                                                        <th colspan=""2"">
                                                            <label class=""bg-dark text-center text-white text-uppercase mt-4 px-5 py-1 text-16 w-100"">Terms &amp; Conditions</label>
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td class=""text-11"">
                                                            This is an estimate only and is based solely on information available at the time the estimate was prepared. Any changes to the work scope
                                                            and/or delays not the responsibility of Applied Inspection Systems, Inc. (AIS) will affect the actual job cost. Additional work will be billed at
                                                            standard AIS rates with overtime as applicable. Unless previously arranged, all call-out work will be billed an eight-hour minimum charge. Any
                                                            work cancelled by the customer with notice to AIS prior to mobilization will result in a mobilization charge. Terms for payment are net 30 days
                                                            from the invoice date. Estimate is valid for 90 days from the date listed above.
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
    
                                    <div class=""row pb-4"">
                                        <div class=""col-7"">
                                        </div>
                                        <div class=""col-5"">
                                            <br>
                                            <div class=""float-right text-center text-16"">
                                                <div>
                                                    <label class=""bg-dark text-center text-white text-uppercase mt-4 px-5 py-1 text-16 w-100"">Estimated Total Cost</label>
                                                </div>
                                                <div>
                                                    <label class=""text-center"">$100.00</label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>";
            return result;
        }
    }
}