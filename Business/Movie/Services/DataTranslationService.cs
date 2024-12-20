﻿using AutoMapper;
using Business.Profiles;

namespace Business.Movie.Services
{
    public class DataTranslationService
    {
        private readonly IMapper mapper;

        public DataTranslationService()
        {
            mapper = new MapperConfiguration(cfg =>
                     {
                         cfg.AddProfile(new MovieProfile());
                         cfg.AddProfile(new MediaProfile());
                     }).CreateMapper();
        }
        public List<TDto> MapData<TDto, TDal>(List<TDal> source)
        {
            return mapper.Map<List<TDto>>(source);
        }
        public TDto MapData<TDto, TDal>(TDal source)
        {
            return mapper.Map<TDto>(source);
        }
        public TDal ReverseMapData<TDal, TDto>(TDto source)
        {
            return mapper.Map<TDal>(source);
        }
    }
}
