using IronPdf;
using System.Text;

namespace IronPdfWatermark.Logic.Constants
{
    public static class StandardPrintOptions
    {
        public static PdfPrintOptions Build(string cssBundlePath, bool includePageNumber, string pdfTitle)
        {
            var result = new PdfPrintOptions {
                PaperOrientation = PdfPrintOptions.PdfPaperOrientation.Portrait,
                RenderDelay = 50, //ms
                CssMediaType = PdfPrintOptions.PdfCssMediaType.Screen,
                DPI = 300,
                Title = pdfTitle,
                FitToPaperWidth = true,
                JpegQuality = 80,
                GrayScale = false,
                InputEncoding = Encoding.UTF8,
                Zoom = 100,
                ViewPortWidth = 1280,
                CreatePdfFormsFromHtml = true,
                CustomCssUrl = cssBundlePath,
                MarginTop = 15,  //millimeters
                MarginLeft = 15,  //millimeters
                MarginRight = 15,  //millimeters
                MarginBottom = 15,  //millimeters
                FirstPageNumber = 1
            };

            if (includePageNumber)
            {
                result.Footer = new HtmlHeaderFooter()
                {
                    Height = 15,
                    HtmlFragment = "<center><i>{page} of {total-pages}<i></center>"
                };
            }

            result.SetCustomPaperSizeInInches(8.5, 11);

            return result;
        }
    }
}
