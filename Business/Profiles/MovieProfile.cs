using AutoMapper;
using DalObje = Dal.Movie;
using DtoObje = Dto.Movie;
using MovieMediaDal = Dal.MovieMedia;
using MovieMediaDto = Dto.MovieMedia;
namespace Business.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            // Map Movie DTO to DAL and reverse
            CreateMap<DtoObje, DalObje>()
                .ForMember(Dal => Dal.MovieMedias, Dto => Dto.MapFrom(o => o.MovieMedias))
                .ReverseMap();

            // Map MovieMedia DTO to DAL and reverse
            CreateMap<MovieMediaDto, MovieMediaDal>().ReverseMap();
        }
    }


    public class MediaProfile : Profile
    {
        public MediaProfile()
        {
            // Map DAL to DTO
            CreateMap<Dal.Media, Dto.Media>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(Dal => Dal.Description))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.AlternateText, opt => opt.MapFrom(src => src.AlternateText))
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                .ForMember(dest => dest.OriginalFilename, opt => opt.MapFrom(src => src.OriginalFilename))
                .ForMember(dest => dest.Width, opt => opt.MapFrom(src => src.Width))
                .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Height))
                .ReverseMap(); // Enables mapping from DTO back to DAL
        }
    }
}
