namespace PdfService.Model
{
    public class Fitting
    {
        public bool FitToPaperWidth { get; set; } = true;

        public int ZoomPercent { get; set; } = 100;

        public int ViewPortHightPixel { get; set; } = 1024;

        public int ViewPortWidthPixel { get; set; } = 1280;
    }
}
