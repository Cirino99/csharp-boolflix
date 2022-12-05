namespace csharp_boolflix.Models
{
    public abstract class Contenuto
    {
        public int Id { get; set; }
        public string Titolo { get; set; }
        public DateTime Anno { get; set; }
        public int Pegi { get; set; }
        public string Trama { get; set; }
        public string Copertina { get; set; }
        public string Risoluzione { get; set; }
        public List<Caratteristica>? Caratteristiche { get; set; }
        public List<Genere>? Generi { get; set; }
        public List<Attore>? Attori { get; set; }
        public int RegiaId { get; set; }
        public Regia? Regia { get; set; }
    }
}
