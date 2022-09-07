using System.ComponentModel.DataAnnotations.Schema;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities
{
    public class Jela
    {
        public int JelaId { get; set; }
        public int UgostiteljskiObjektiId { get; set; }
        [ForeignKey("UgostiteljskiObjektiId")]
        public virtual UgostiteljskiObjekti UgostiteljskiObjekti { get; set; }
        public string NazivJela { get; set; }
        public string Opis { get; set; }

        [Column(TypeName = "money")]
        public decimal Cjena { get; set; }

    }
}
