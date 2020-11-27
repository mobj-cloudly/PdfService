namespace PdfService.Model
{
    public class Header
    {
        public bool UseHeader { get; set; } = false;
        public bool DrawDividerLine { get; set; } = true;
        public string CenterText { get; set; } = string.Empty;
        public string FontFamily { get; set; } = "Helvetica,Arial";
        public int FontSizePixels { get; set; } = 12;
    }
}