using csharp_boolflix.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_boolflix.Data.Repository
{
    public class DbSerieRepository : ISerieRepository
    {
        BoolflixDbContext db;
        public DbSerieRepository(BoolflixDbContext _db)
        {
            db = _db;
        }
        public List<Serie> All()
        {
            return db.Serie.ToList();
        }
        public Serie GetById(int id)
        {
            return db.Serie.Where(f => f.Id == id).Include("Caratteristiche").Include("Generi").Include("Attori").Include("Regia").Include("Stagioni").FirstOrDefault();
        }
        public Serie Create(Serie serie, List<Caratteristica> caratteristiche, List<Genere> generi, List<Attore> attori, Regia regista)
        {
            serie.Caratteristiche = caratteristiche;
            serie.Attori = attori;
            serie.Generi = generi;
            serie.Regia = regista;

            db.Serie.Add(serie);
            db.SaveChanges();
            return serie;
        }
        public void Delete(Serie serie)
        {
            db.Serie.Remove(serie);
            db.SaveChanges();
        }
        public Stagione GetStagione(int id)
        {
            throw new NotImplementedException();
        }
        public List<Stagione> GetStagioni(int id)
        {
            return db.Stagioni.Where(s => s.SerieId == id).ToList();
        }
        public List<Episodio> GetEpisodi(int id)
        {
            return db.Episodi.Where(e => e.StagioneId == id).ToList();
        }
        public void AddStagione(Stagione stagione)
        {
            db.Stagioni.Add(stagione);
            Serie serie = GetById(stagione.SerieId);
            serie.Stagioni.Add(stagione);
            db.SaveChanges();
        }
        public void AddEpisodio(Episodio episodio)
        {
            throw new NotImplementedException();
        }
    }
}
