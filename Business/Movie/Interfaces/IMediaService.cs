namespace Business.Movie.Interfaces
{
    public interface IMediaService
    {
        Task AddMedia(Dto.Media media);
        Task<Dto.Media> GetMediaByUid(Guid mediaUid);
    }
}
