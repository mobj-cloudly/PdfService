using IronPdf;
using PdfService.Model;
using System.Threading.Tasks;

namespace PdfService.Services
{
    public class IronPdfGenerator : IPdfGenerator
    {
        private readonly HtmlToPdf _htmlToPdf;

        public IronPdfGenerator()
        {
            _htmlToPdf = new HtmlToPdf();
        }

        public async Task<byte[]> GetBytesAsync(PdfConfig pdfConfig)
        {
            _htmlToPdf.ApplyConfig(pdfConfig);
            return await _htmlToPdf.GetBytesAsync(pdfConfig);
        }
    }
}
