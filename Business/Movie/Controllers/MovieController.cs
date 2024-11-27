using Business.Movie.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Business.Movie.Controllers
{
    [ApiController]
    [Route("Data/[controller]/[Action]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly ILogger<MovieController> logger;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IEnumerable<Dto.Movie>> GetAllMovies()
        {
            logger.LogTrace(string.Format("Data/Movie/GetAllMovies"));
            return await _movieService.GetAllMovies();
        }
    }
}

