using PdfService.Model;
using System.Threading.Tasks;

namespace PdfService.Services
{
    public interface IPdfGenerator
    {
        Task<byte[]> GetBytesAsync(PdfConfig pdfConfig);
    }
}
