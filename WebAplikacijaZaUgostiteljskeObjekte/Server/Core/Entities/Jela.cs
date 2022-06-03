using System.ComponentModel.DataAnnotations.Schema;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities
{
    public class Jela
    {
        public int JelaId { get; set; } 
        public int UgostiteljskiObjektiId { get; set; }
        public string NazivJela { get; set; }
        public string Opis { get; set; }

        [Column(TypeName = "money")]
        public decimal Cjena { get; set; }

        public string SlikaUrl { get; set; }
    }
}
