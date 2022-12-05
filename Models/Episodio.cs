namespace csharp_boolflix.Models
{
    public class Episodio
    {
        public int Id { get; set; }
        public string Titolo { get; set; }
        public int Durata { get; set; }
        public string Trama { get; set; }
        public int StagioneId { get; set; }
        public Stagione? Stagione { get; set; }
    }
}
