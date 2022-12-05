using csharp_boolflix.Data;
using csharp_boolflix.Data.Repository;
using csharp_boolflix.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace csharp_boolflix.Controllers
{
    [Authorize]
    [Route("[controller]/[action]/{id?}", Order = 0)]
    public class FilmController : Controller
    {
        IFilmRepository filmRepository;
        BoolflixDbContext db; // da toglire quando ci saranno tutti i repository
        public FilmController(IFilmRepository _filmRepository, BoolflixDbContext _db) : base()
        {
            filmRepository = _filmRepository;
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            FormFilm formFilm = new FormFilm();
            formFilm.Film = new Film();
            formFilm.Attori = db.Attori.ToList();
            formFilm.Registi = db.Registi.ToList();
            formFilm.Caratteristiche = db.Caratteristiche.ToList();
            formFilm.AreCheckedGeneri = new List<int>();
            formFilm.AreCheckedAttori = new List<int>();
            formFilm.AreCheckedCaratteristiche = new List<int>();
            return View(formFilm);
        }
    }
}
