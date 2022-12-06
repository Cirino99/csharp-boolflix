using csharp_boolflix.Models;

namespace csharp_boolflix.Data.Repository
{
    public interface ISerieRepository
    {
        List<Serie> All();
        Serie GetById(int id);
        Serie Create(Serie serie, List<Caratteristica> caratteristiche, List<Genere> generi, List<Attore> attori, Regia regista);
        void Delete(Serie serie);
    }
}
