namespace csharp_boolflix.Models
{
    public class Stagione
    {
        public int Id { get; set; }
        public string Titolo { get; set; }
        public int SerieId { get; set; }
        public Serie? Serie { get; set; }
        public List<Episodio>? Episodi { get; set; }
    }
}
