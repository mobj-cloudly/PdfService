namespace PdfService.Model
{
    public class Footer
    {
        public bool UseFooter { get; set; } = false;
        public bool DrawDividerLine { get; set; } = true;
        public string FontFamily { get; set; } = "Helvetica,Arial";
        public int FontSizePixels { get; set; } = 10;
        public string CenterText { get; set; } = string.Empty;
        public string LeftText { get; set; } = string.Empty;
        public string RightText { get; set; } = string.Empty;
    }
}