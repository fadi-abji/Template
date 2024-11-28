using Business.DataBase;
using Business.Movie.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;


namespace Business.Movie.Services
{
    public class MediaService : IMediaService
    {
        private readonly IDbContextFactory<MainDbContext> dbFactory;
        private readonly DataTranslationService dataTranslationService;
        private readonly IWebHostEnvironment _env;

        public MediaService(IDbContextFactory<MainDbContext> DbFactory, DataTranslationService dataTranslationService)
        {

            this.dbFactory = DbFactory;
            this.dataTranslationService = dataTranslationService;
        }

        public async Task<Dto.Media> AddMedia()
        {
            using var context = dbFactory.CreateDbContext();
            try
            {
                var mediaDto = new Dto.Media { Uid = new Guid() };

                var mediaDal = dataTranslationService.ReverseMapData<Dal.Media, Dto.Media>(mediaDto);

                context.Media.Add(mediaDal);

                await context.SaveChangesAsync();

                var returnMediaDal = context.Media.FirstOrDefault(mediaDal => mediaDal.Uid == mediaDto.Uid);

                var returnMediaDto = dataTranslationService.MapData<Dto.Media, Dal.Media>(returnMediaDal);

                return returnMediaDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
