using Business.Movie.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Business.Movie.Controllers
{
    [ApiController]
    [Route("Data/[controller]/[Action]")]
    public class MediaController : ControllerBase
    {
        private readonly IMediaService mediaService;
        private readonly ILogger<MovieController> logger;

        public MediaController(IMediaService mediaService)
        {
            this.mediaService = mediaService;
        }

        [HttpGet]
        public async Task AddMedia(Dto.Media media)
        {
            logger.LogTrace(string.Format("Data/Media/AddMedia"));
            await mediaService.AddMedia(media);
        }
    }
}

