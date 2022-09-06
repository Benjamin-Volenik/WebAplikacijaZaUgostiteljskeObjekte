using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAplikacijaZaUgostiteljskeObjekte.Shared
{
    public class CreateDish
    {
        public int UgostiteljskiObjektiId { get; set; }
        public string NazivJela { get; set; }
        public string Opis { get; set; }

        [Column(TypeName = "money")]
        public decimal Cjena { get; set; }

    }
}
