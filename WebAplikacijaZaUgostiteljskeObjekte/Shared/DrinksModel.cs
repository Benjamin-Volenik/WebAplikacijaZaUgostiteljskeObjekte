using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAplikacijaZaUgostiteljskeObjekte.Shared
{
    public class DrinksModel
    {
        public int DrinksId { get; set; }
        public int UgostiteljskiObjektiId { get; set; }
        [ForeignKey("UgostiteljskiObjektiId")]
        public virtual UgostiteljskiObjektiModel UgostiteljskiObjekti { get; set; }
        public string NazivPica { get; set; }
        public string Opis { get; set; }

        [Column(TypeName = "money")]
        public decimal Cjena { get; set; }

        public float PiceNormativ { get; set; }
    }
}
