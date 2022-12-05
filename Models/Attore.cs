namespace csharp_boolflix.Models
{
    public class Attore
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public List<Contenuto>? Contenuti { get; set; }
    }
}
