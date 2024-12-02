using System.Drawing;

namespace Middleware
{
    public class ImageMiddlewareOptions
    {
        public string ProcessedMediaDirectory { get; set; } = "/media/development/unsafe_uploads/processed/";
        public string MediaDirectory { get; set; } = "medias/development/unsafe_uploads/";
        //public string CachedImageResultKey = "ImageMiddleware.CachedImageResults";
        //public string ParameterSplitCharacter { get; set; } = "_";
        public int ImageOutputHeight { get; set; } = 700;
        public int ImageOutputWidth { get; set; } = 1000;
        public Color BackgroundColor { get; set; } = Color.White;
    }
}

