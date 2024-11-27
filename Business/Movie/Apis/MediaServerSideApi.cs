using Business.Movie.Interfaces;
using Core.Movie.Interfaces;

namespace Business.Movie.Apis
{
    public class MediaServerSideApi : IMediaApi
    {
        private readonly IMediaService mediaService;
        public MediaServerSideApi(IMediaService mediaService)
        {
            this.mediaService = mediaService;
        }

        public Task<Dto.Media> AddMedia()
        {
            return mediaService.AddMedia();
        }
    }
}
