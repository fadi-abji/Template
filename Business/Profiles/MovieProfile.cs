using AutoMapper;
using DalMedia = Dal.Media;
using DalObje = Dal.Movie;
using DtoMedia = Dto.Media;
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
            // Map Media DTO to DAL and reverse
            CreateMap<DtoMedia, DalMedia>()
                .ReverseMap();
        }
    }
}
