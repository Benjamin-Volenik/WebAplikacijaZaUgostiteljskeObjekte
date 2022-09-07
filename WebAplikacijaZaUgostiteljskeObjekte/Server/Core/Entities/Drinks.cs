using System.ComponentModel.DataAnnotations.Schema;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities
{
    public class Drinks
    {
        public int DrinksId { get; set; }
        public int UgostiteljskiObjektiId { get; set; }
        [ForeignKey("UgostiteljskiObjektiId")]
        public virtual UgostiteljskiObjekti UgostiteljskiObjekti { get; set; }
        public string NazivPica { get; set; }
        public string Opis { get; set; }

        [Column(TypeName = "money")]
        public decimal Cjena { get; set; }
        
        public float PiceNormativ { get; set; }

    }
}
