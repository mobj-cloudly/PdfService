using Microsoft.AspNetCore.Mvc;
using PdfService.Model;
using PdfService.Services;
using System;
using System.Threading.Tasks;

namespace PdfService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private IPdfGenerator _pdfGenerator;
        public PdfController(IPdfGenerator pdfGenerator)
        {
            _pdfGenerator = pdfGenerator;
        }

        [HttpPost]
        public async Task<IActionResult> Generate(PdfConfig pdfConfig)
        {
            try
            {
                var bytes = await _pdfGenerator.GetBytesAsync(pdfConfig);
                return new FileContentResult(bytes, "application/pdf")
                {
                    FileDownloadName = pdfConfig.Title
                };
            }
            catch (Exception)
            {
                //log to application insights
            }
            return new BadRequestObjectResult("Error: Generating the pdf document went wrong...");
        }
    }
}
