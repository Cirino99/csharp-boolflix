using csharp_boolflix.Data.Repository;
using csharp_boolflix.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace csharp_boolflix.Controllers.Api
{
    [Route("api/[controller]/[action]", Order = 1)]
    [ApiController]
    public class ContenutoController : ControllerBase
    {
        IFilmRepository filmRepository;
        ISerieRepository serieRepository;

        public ContenutoController(IFilmRepository _filmRepository, ISerieRepository _serieRepository)
        {
            filmRepository = _filmRepository;
            serieRepository = _serieRepository;
        }
        public ActionResult GetFilm(string genere)
        {
            List<Film> films = filmRepository.GetGenereFilm(genere);
            return Ok(films);
        }
    }
}
