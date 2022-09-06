using System.ComponentModel.DataAnnotations.Schema;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities
{
    public class Drinks
    {
        public int DrinksId { get; set; }
        [ForeignKey("UgostiteljskiObjektiId")]
        public UgostiteljskiObjekti UgostiteljskiObjektiIdd { get; set; }
        public string NazivPica { get; set; }
        public string Opis { get; set; }

        [Column(TypeName = "money")]
        public decimal Cjena { get; set; }
        
        public float PiceNormativ { get; set; }

    }
}
