using AutoMapper;

namespace Business.Movie.Services
{
    public class DataTranslationService
    {
        private readonly IMapper _mapper;

        public DataTranslationService(IMapper mapper)
        {
            _mapper = mapper;
        }

        //public Core.Movie.Dtos.Movie MapData(Dal.Models.Movie source)
        //{
        //    return _mapper.Map<Core.Movie.Dtos.Movie>(source);
        //}

        public IEnumerable<TDto> MapData<TDto, TDal>(IEnumerable<TDal> source)
        {
            return _mapper.Map<IEnumerable<TDto>>(source);
        }
        public TDto MapData<TDto, TDal>(TDal source)
        {
            return _mapper.Map<TDto>(source);
        }

        public TDal ReverseMapData<TDal, TDto>(TDto source)
        {
            return _mapper.Map<TDal>(source);
        }
    }
}
