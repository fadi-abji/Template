using Microsoft.Extensions.Logging;

namespace Middleware
{
    public class ImageMiddlewareBase<T>
    {
        protected readonly ILogger<T> logger;

        protected ImageMiddlewareOptions Options { get; }

        public ImageMiddlewareBase(ILogger<T> logger, ImageMiddlewareOptions Options)
        {
            this.logger = logger;
            this.Options = Options;
        }

    }
}
