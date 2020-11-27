using IronPdf;
using PdfService.Model;
using System;
using System.Threading.Tasks;
using static IronPdf.PdfPrintOptions;

namespace PdfService.Services
{
    public static class HtmlToPdfExtensions
    {
        public static HtmlToPdf ApplyConfig(this HtmlToPdf htmlToPdf, PdfConfig pdfConfig)
        {
            htmlToPdf.ApplyHtmlSettings(pdfConfig);
            htmlToPdf.ApplyHeaderSettings(pdfConfig);
            htmlToPdf.ApplyFooterSettings(pdfConfig);
            htmlToPdf.ApplyMarginSettings(pdfConfig);
            htmlToPdf.ApplyQualitySettings(pdfConfig);
            htmlToPdf.ApplyPaperSettings(pdfConfig);
            htmlToPdf.ApplyFittingSettings(pdfConfig);
            htmlToPdf.ApplyPaginationSettings(pdfConfig);
            return htmlToPdf;
        }
        private static HtmlToPdf ApplyHtmlSettings(this HtmlToPdf htmlToPdf, PdfConfig pdfConfig)
        {
            htmlToPdf.PrintOptions.PrintHtmlBackgrounds = pdfConfig.Html.PrintHtmlBackgrounds;
            htmlToPdf.PrintOptions.EnableJavaScript = pdfConfig.Html.EnableJavaScript;
            htmlToPdf.PrintOptions.RenderDelay = pdfConfig.Html.RenderDelay;
            htmlToPdf.PrintOptions.CssMediaType = pdfConfig.Html.CssMediaType.ToLower() switch
            {
                "screen" => PdfCssMediaType.Screen,
                _ => PdfCssMediaType.Print
            };
            return htmlToPdf;
        }
        private static HtmlToPdf ApplyHeaderSettings(this HtmlToPdf htmlToPdf, PdfConfig pdfConfig)
        {
            if (!pdfConfig.Header.UseHeader) return htmlToPdf;
            htmlToPdf.PrintOptions.Header.DrawDividerLine = pdfConfig.Header.DrawDividerLine;
            htmlToPdf.PrintOptions.Header.CenterText = pdfConfig.Header.CenterText;
            htmlToPdf.PrintOptions.Header.FontFamily = pdfConfig.Header.FontFamily;
            htmlToPdf.PrintOptions.Header.FontSize = pdfConfig.Header.FontSizePixels;
            return htmlToPdf;
        }
        private static HtmlToPdf ApplyFooterSettings(this HtmlToPdf htmlToPdf, PdfConfig pdfConfig)
        {
            if (!pdfConfig.Footer.UseFooter) return htmlToPdf;
            htmlToPdf.PrintOptions.Footer.DrawDividerLine = pdfConfig.Footer.DrawDividerLine;
            htmlToPdf.PrintOptions.Footer.FontFamily = pdfConfig.Footer.FontFamily;
            htmlToPdf.PrintOptions.Footer.FontSize = pdfConfig.Footer.FontSizePixels;
            htmlToPdf.PrintOptions.Footer.CenterText = pdfConfig.Footer.CenterText;
            htmlToPdf.PrintOptions.Footer.LeftText = pdfConfig.Footer.LeftText;
            htmlToPdf.PrintOptions.Footer.RightText = pdfConfig.Footer.RightText;
            return htmlToPdf;
        }
        private static HtmlToPdf ApplyMarginSettings(this HtmlToPdf htmlToPdf, PdfConfig pdfConfig)
        {
            htmlToPdf.PrintOptions.MarginTop = pdfConfig.MarginInMm.Top;
            htmlToPdf.PrintOptions.MarginBottom = pdfConfig.MarginInMm.Bottom;
            htmlToPdf.PrintOptions.MarginLeft = pdfConfig.MarginInMm.Left;
            htmlToPdf.PrintOptions.MarginRight = pdfConfig.MarginInMm.Right;
            return htmlToPdf;
        }
        private static HtmlToPdf ApplyPaperSettings(this HtmlToPdf htmlToPdf, PdfConfig pdfConfig)
        {
            htmlToPdf.PrintOptions.PaperSize = (pdfConfig.Paper.Size.ToUpper()) switch
            {
                "A5" => PdfPaperSize.A5,
                "A4" => PdfPaperSize.A4,
                "A3" => PdfPaperSize.A3,
                _ => PdfPaperSize.A4
            };

            htmlToPdf.PrintOptions.PaperOrientation = (pdfConfig.Paper.Orientation.ToLower()) switch
            {
                "landscape" => PdfPaperOrientation.Landscape,
                _ => PdfPaperOrientation.Portrait
            };
            return htmlToPdf;
        }
        private static HtmlToPdf ApplyQualitySettings(this HtmlToPdf htmlToPdf, PdfConfig pdfConfig)
        {
            htmlToPdf.PrintOptions.DPI = pdfConfig.Quality.ResulutionDpi;
            htmlToPdf.PrintOptions.JpegQuality = pdfConfig.Quality.JpegQualityPercent;
            return htmlToPdf;
        }
        private static HtmlToPdf ApplyFittingSettings(this HtmlToPdf htmlToPdf, PdfConfig pdfConfig)
        {
            htmlToPdf.PrintOptions.FitToPaperWidth = pdfConfig.Fitting.FitToPaperWidth;
            htmlToPdf.PrintOptions.Zoom = pdfConfig.Fitting.ZoomPercent;
            htmlToPdf.PrintOptions.ViewPortHeight = pdfConfig.Fitting.ViewPortHightPixel;
            htmlToPdf.PrintOptions.ViewPortWidth = pdfConfig.Fitting.ViewPortWidthPixel;
            return htmlToPdf;
        }
        private static HtmlToPdf ApplyPaginationSettings(this HtmlToPdf htmlToPdf, PdfConfig pdfConfig)
        {
            htmlToPdf.PrintOptions.FirstPageNumber = pdfConfig.Pagination.FirstPageNumber;
            return htmlToPdf;
        }
        public static async Task<byte[]> GetBytesAsync(this HtmlToPdf htmlToPdf, PdfConfig pdfConfig)
        {
            var pdf = (Uri.TryCreate(pdfConfig.Html.GetContentFromUrl, UriKind.Absolute, out Uri uri))
                ? await htmlToPdf.RenderUrlAsPdfAsync(uri)
                : await htmlToPdf.RenderHtmlAsPdfAsync(pdfConfig.Html.Content);
            pdf.Flatten();
            return pdf.BinaryData;
        }
    }
}
