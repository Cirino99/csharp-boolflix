using csharp_boolflix.Models;

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
            return db.Films.Where(f => f.Id == id).FirstOrDefault();
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
    }
}
