using csharp_boolflix.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace csharp_boolflix.Data.Repository
{
    public class DbFilmRepository : IFilmRepository
    {
        BoolflixDbContext db;
        public DbFilmRepository(BoolflixDbContext _db)
        {
            db = _db;
        }
        public List<Film> All()
        {
            return db.Films.ToList();
        }
        public Film GetById(int id)
        {
            return db.Films.Where(f => f.Id == id).Include("Caratteristiche").Include("Generi").Include("Attori").Include("Regia").FirstOrDefault();
        }
        public void Create(Film film, List<Caratteristica> caratteristiche, List<Genere> generi, List<Attore> attori, Regia regista)
        {
            film.Caratteristiche = caratteristiche;
            film.Attori = attori;
            film.Generi = generi;
            film.Regia = regista;

            db.Films.Add(film);
            db.SaveChanges();
        }
        public void Delete(Film film)
        {
            db.Films.Remove(film);
            db.SaveChanges();
        }

        public List<Film> GetGenereFilm(string genere)
        {
            Genere item = db.Generi.Where(g => g.Nome == genere).FirstOrDefault();
            return db.Films.Where(f => f.Generi.Contains(item)).ToList();
            //return db.Films.Where(f => f.Generi.Where( g => g.Nome == genere)).ToList();
        }
    }
}
