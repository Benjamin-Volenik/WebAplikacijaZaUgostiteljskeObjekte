using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAplikacijaZaUgostiteljskeObjekte.Shared
{
    public class UgostiteljskiObjektiModel
    {
        public int UgostiteljskiObjektiId { get; set; }
        public string UgostiteljskiObjektiNaziv { get; set; }
        public string UgostiteljskiObjektiKontakt { get; set; }
        public string UgostiteljskiObjektiEmali { get; set; }
        public string UgostiteljskiObjektiLozinka { get; set; }
        public float UgostiteljskiObjektiProsjecnaOcjena { get; set; }
        public string UgostiteljskiObjektiSlika { get; set; }
    }
}
