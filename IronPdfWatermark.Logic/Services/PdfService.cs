using System;
using System.Threading.Tasks;
using IronPdf;

namespace IronPdfWatermark.Logic.Services
{
    public interface IPdfService
    {
        PdfDocument HtmlToPdf(string html, bool addUnofficialWatermark, PdfPrintOptions printOptions = null);
        bool IsLicensed();
    }

    public class PdfService : IPdfService
    {       
        public PdfService()
        {

        }

        public PdfDocument HtmlToPdf(string html, bool addUnofficialWatermark, PdfPrintOptions printOptions = null)
        {
            if (string.IsNullOrEmpty(html))
                return null;

            try
            {
                var renderer = new HtmlToPdf();

                if (printOptions != null)
                {
                    renderer.PrintOptions = printOptions;
                }

                var pdf = renderer.RenderHtmlAsPdf(html);

                if (addUnofficialWatermark)
                {
                    pdf.WatermarkAllPages(
                        "<h1 style='font-size: 75px;color:indianred;font-family: TimesNewRoman,Times New Roman,Times,Baskerville,Georgia,serif;font-weight: 400; opacity:0.5;'>Unofficial Copy</h1>",
                        PdfDocument.WaterMarkLocation.MiddleCenter,
                        50,
                        -45);
                }

                return pdf;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool IsLicensed()
        {
            return License.IsLicensed;
        }
    }
}
