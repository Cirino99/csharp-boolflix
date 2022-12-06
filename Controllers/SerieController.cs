using csharp_boolflix.Data.Repository;
using csharp_boolflix.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using csharp_boolflix.Models;

namespace csharp_boolflix.Controllers
{
    [Authorize]
    [Route("[controller]/[action]/{id?}", Order = 0)]
    public class SerieController : Controller
    {
        ISerieRepository serieRepository;
        BoolflixDbContext db; // da toglire quando ci saranno tutti i repository
        public SerieController(ISerieRepository _serieRepository, BoolflixDbContext _db) : base()
        {
            serieRepository = _serieRepository;
            db = _db;
        }
        public IActionResult Index()
        {
            List<Serie> serie = serieRepository.All();
            return View(serie);
        }
        public IActionResult Detail(int id)
        {
            Serie serie = serieRepository.GetById(id);
            return View(serie);
        }
        public IActionResult Create()
        {
            FormSerie formSerie = new FormSerie();
            formSerie.Serie = new Serie();
            formSerie.Attori = db.Attori.ToList();
            formSerie.Registi = db.Registi.ToList();
            formSerie.Caratteristiche = db.Caratteristiche.ToList();
            formSerie.Generi = db.Generi.ToList();
            formSerie.AreCheckedGeneri = new List<int>();
            formSerie.AreCheckedAttori = new List<int>();
            formSerie.AreCheckedCaratteristiche = new List<int>();
            return View(formSerie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FormSerie formSerie)
        {
            if (!ModelState.IsValid)
            {
                formSerie.Attori = db.Attori.ToList();
                formSerie.Registi = db.Registi.ToList();
                formSerie.Caratteristiche = db.Caratteristiche.ToList();
                formSerie.Generi = db.Generi.ToList();
                return View(formSerie);
            }
            List<Attore> attori = db.Attori.ToList();
            List<Caratteristica> caratteristiche = db.Caratteristiche.ToList();
            List<Genere> generi = db.Generi.ToList();
            Regia regista = db.Registi.Where(r => r.Id == formSerie.Serie.RegiaId).FirstOrDefault();
            Serie serie = serieRepository.Create(formSerie.Serie, caratteristiche, generi, attori, regista);

            return RedirectToAction("Detail", new { id = serie.Id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Serie serie = serieRepository.GetById(id);

            if (serie == null)
                return View("NotFound", "La pizza cercata non è stata trovata");

            serieRepository.Delete(serie);

            return RedirectToAction("Index");
        }
        public IActionResult AddStagione(int id)
        {
            Stagione stagione = new Stagione();
            stagione.SerieId = id;
            return View(stagione);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddStagione(Stagione stagione, int id)
        {
            stagione.Id = 0;
            stagione.SerieId = id;
            if (!ModelState.IsValid)
            {
                return View(stagione);
            }
            serieRepository.AddStagione(stagione);
            return RedirectToAction("Detail", new { id = stagione.SerieId });
        }
        public IActionResult AddEpisodio(int id)
        {
            Episodio episodio = new Episodio();
            episodio.StagioneId = id;
            return View(episodio);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEpisodio(Episodio episodio, int id)
        {
            episodio.Id = 0;
            episodio.StagioneId = id;
            if (!ModelState.IsValid)
            {
                return View(episodio);
            }
            serieRepository.AddEpisodio(episodio);
            return RedirectToAction("Index");
        }
    }
}
