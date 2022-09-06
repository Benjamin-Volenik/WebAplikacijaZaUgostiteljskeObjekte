using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities
{
    public class Ocjene
    {
        public int OcjeneId { get;set; }
        [ForeignKey("UserId")]
        public User UserIdd { get;set; }
        [ForeignKey("UgostiteljskiObjektiId")]
        public UgostiteljskiObjekti UgostiteljskiObjektiIdd { get;set; }
        public int Ocjena { get;set; }
        public DateTime OcjenaVrijeme { get; set; }
    }
}
