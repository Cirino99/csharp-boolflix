using csharp_boolflix.Models;

namespace csharp_boolflix.Data.Repository
{
    public interface IFilmRepository
    {
        List<Film> All();
        Film GetById(int id);
        void Create (Film film, List<Caratteristica> caratteristiche, List<Genere> generi, List<Attore> attori, Regia regista);
    }
}
