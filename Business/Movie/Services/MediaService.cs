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

        //public async Task AddMedia(Dto.Media media)
        //{
        //    using var context = dbFactory.CreateDbContext();
        //    try
        //    {
        //        var mediaDto = new Dto.Media { Uid = new Guid() };

        //        var mediaDal = dataTranslationService.ReverseMapData<Dal.Media, Dto.Media>(mediaDto);

        //        context.Media.Add(mediaDal);

        //        await context.SaveChangesAsync();

        //        var returnMediaDal = context.Media.FirstOrDefault(mediaDal => mediaDal.Uid == mediaDto.Uid);

        //        var returnMediaDto = dataTranslationService.MapData<Dto.Media, Dal.Media>(returnMediaDal);

        //        return returnMediaDto;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public async Task AddMedia(Dto.Media media)
        {
            using var context = dbFactory.CreateDbContext();
            try
            {
                var mediaDal = dataTranslationService.MapData<Dal.Media, Dto.Media>(media);

                context.Media.Add(mediaDal);

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Dto.Media> GetMediaByUid(Guid mediaUid)
        {
            using var context = dbFactory.CreateDbContext();
            try
            {
                var mediaDal = context.Media.FirstOrDefault(mediaDal => mediaDal.Uid == mediaUid);

                var mediaDto = dataTranslationService.MapData<Dto.Media, Dal.Media>(mediaDal);

                return mediaDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
