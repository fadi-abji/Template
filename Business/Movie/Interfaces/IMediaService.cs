namespace Business.Movie.Interfaces
{
    public interface IMediaService
    {
        Task<Dto.Media> AddMedia();
    }
}
