using static System.Guid;

namespace PdfService.Model
{
    public class PdfConfig
    {
        public string Title { get; set; } = $"pdf_{NewGuid()}.pdf";
        public Html Html { get; set; } = new Html();

        public Header Header { get; set; } = new Header();

        public Footer Footer { get; set; } = new Footer();

        public MarginInMm MarginInMm { get; set; } = new MarginInMm();

        public Quality Quality { get; set; } = new Quality();

        public Paper Paper { get; set; } = new Paper();

        public Fitting Fitting { get; set; } = new Fitting();

        public Pagination Pagination { get; set; } = new Pagination();
    
    }
}
