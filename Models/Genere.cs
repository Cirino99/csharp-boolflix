namespace csharp_boolflix.Models
{
    public class Genere
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Contenuto>? Contenuti { get; set; }
    }
}
