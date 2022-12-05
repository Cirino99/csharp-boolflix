using csharp_boolflix.Models;

namespace csharp_boolflix.Data
{
    public class FormFilm
    {
        public Film Film { get; set; }
        public List<Caratteristica>? Caratteristiche { get; set; }
        public List<int>? AreCheckedCaratteristiche { get; set; }
        public List<Genere>? Generi { get; set; }
        public List<int>? AreCheckedGeneri { get; set; }
        public List<Attore>? Attori { get; set; }
        public List<int>? AreCheckedAttori { get; set; }
        public List<Regia>? Registi { get; set; }
    }
}
