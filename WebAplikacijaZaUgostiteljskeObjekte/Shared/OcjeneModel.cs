using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAplikacijaZaUgostiteljskeObjekte.Shared
{
    public class OcjeneModel
    {
        public int OcjeneId { get; set; }
        public int UserId { get; set; }
        public int UgostiteljskiObjektiId { get; set; }
        public int Ocjena { get; set; }
        public DateTime OcjenaVrijeme { get; set; }
    }
}
