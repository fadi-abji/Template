using Business.Movie.Interfaces;
using Core.Movie.Interfaces;
using Dto;

namespace Business.Movie.Apis
{
    public class MediaServerSideApi : IMediaApi
    {
        private readonly IMediaService mediaService;
        public MediaServerSideApi(IMediaService mediaService)
        {
            this.mediaService = mediaService;
        }

        public async Task AddMedia(Media media)
        {
            await mediaService.AddMedia(media);
        }
    }
}
