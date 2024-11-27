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
        public async Task<Dto.Media> AddMedia()
        {
            logger.LogTrace(string.Format("Data/Media/AddMedia"));
            return await mediaService.AddMedia();
        }
    }
}

