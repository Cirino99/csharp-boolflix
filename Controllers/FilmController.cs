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
            List<Film> films = filmRepository.All();
            return View(films);
        }
        public IActionResult Detail(int id)
        {
            Film film = filmRepository.GetById(id);
            return View(film);
        }
        public IActionResult Create()
        {
            FormFilm formFilm = new FormFilm();
            formFilm.Film = new Film();
            formFilm.Attori = db.Attori.ToList();
            formFilm.Registi = db.Registi.ToList();
            formFilm.Caratteristiche = db.Caratteristiche.ToList();
            formFilm.Generi = db.Generi.ToList();
            formFilm.AreCheckedGeneri = new List<int>();
            formFilm.AreCheckedAttori = new List<int>();
            formFilm.AreCheckedCaratteristiche = new List<int>();
            return View(formFilm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FormFilm formFilm)
        {
            if (!ModelState.IsValid)
            {
                return View(formFilm);
            }
            List<Attore> attori = db.Attori.ToList();
            List<Caratteristica> caratteristiche = db.Caratteristiche.ToList();
            List<Genere> generi = db.Generi.ToList();
            Regia regista = db.Registi.Where(r => r.Id == formFilm.Film.RegiaId).FirstOrDefault();
            filmRepository.Create(formFilm.Film, caratteristiche, generi, attori, regista);

            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Film film = filmRepository.GetById(id);

            if (film == null)
                return View("NotFound", "La pizza cercata non è stata trovata");

            filmRepository.Delete(film);

            return RedirectToAction("Index");
        }
    }
}
