using Business.Movie.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;

namespace Middleware
{
    public class ImageMiddleware : ImageMiddlewareBase<ImageMiddleware>
    {
        private readonly RequestDelegate _next;
        public ImageMiddleware(RequestDelegate _next, ILogger<ImageMiddleware> logger, ImageMiddlewareOptions options) : base(logger, options)
        {
            this._next = _next;
        }
        public async Task Invoke(HttpContext context, IMediaService mediaService)
        {
            PathString path = context.Request.Path;
            List<string> listofacceptedparameters = new List<string>() { "/getimage" };
            if (!IsPathInList(path, listofacceptedparameters))
            {
                await _next(context);
                return;
            }

            else
            {
                Image<Rgba32> image = null;
                try
                {
                    string lastsegment = path.Value.Split('/').Last();
                    if (Guid.TryParse(lastsegment, out Guid uid))
                    {
                        Guid mediaUid = Guid.Parse(lastsegment);
                        image = await GetImageAsync(mediaUid, mediaService);
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error getting image");
                }
                await _next(context);
                return;
            }
        }

        private bool IsPathInList(PathString path, List<string> listofacceptedparameters)
        {
            return listofacceptedparameters.Any(o => path.Value.ToLower().StartsWith(o));
        }

        private async Task<Image<Rgba32>> GetImageAsync(Guid mediaUid, IMediaService mediaService)
        {
            try
            {
                Dto.Media media = await mediaService.GetMediaByUid(mediaUid);
                Image<Rgba32> image = null;

                using (var stream = File.Open(Options.MediaDirectory + mediaUid.ToString(), FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    IImageDecoder decoder = media.FileName.EndsWith(".png") ? PngDecoder.Instance : JpegDecoder.Instance;
                    image = decoder.Decode<Rgba32>(new DecoderOptions(), stream);
                }

                if (!Directory.Exists(Options.ProcessedMediaDirectory)) { Directory.CreateDirectory(Options.ProcessedMediaDirectory); }

                return image;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error getting image");
                throw;
            }
        }
    }
}
