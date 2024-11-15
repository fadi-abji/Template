using AutoMapper;
namespace Business.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Dal.Models.Movie, Core.Movie.Dtos.Movie>();
            //.ForMember(dest => dest.Rating, src => src.MapFrom(o => o.Rating + " " + "rate"))
            //.ForMember(dest => dest.ReleaseDate, src => src.MapFrom(o => o.ReleaseDate.ToString("yyyy/MM/dd")))
            //.ForMember(dest => dest.Price, src => src.MapFrom(o => o.Price.ToString("C")));

            CreateMap<Core.Movie.Dtos.Movie, Dal.Models.Movie>();
            //.ForMember(dest => dest.Rating, src => src.MapFrom(o => o.Rating.Replace(" rate", "")))
            //.ForMember(dest => dest.ReleaseDate, src => src.MapFrom(o => DateOnly.Parse(o.ReleaseDate.ToString())))
            //.ForMember(dest => dest.Price, src => src.MapFrom(o => o.Price))
            //.ForMember(dest => dest.Uid, src => src.MapFrom(o => Guid.NewGuid()));
        }
    }
}
