namespace PdfService.Model
{
    public class Html
    {
        public string GetContentFromUrl { get; set; } = string.Empty;
        public string Content { get; set; } = "<h1>No HTML content included!</h1>";
        public bool PrintHtmlBackgrounds { get; set; } = true;
        public bool EnableJavaScript { get; set; } = true;
        public int RenderDelay { get; set; } = 100;
        public string CssMediaType { get; set; } = "print";
    }
}

