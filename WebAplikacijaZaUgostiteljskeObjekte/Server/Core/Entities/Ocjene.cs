using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities
{
    public class Ocjene
    {
        public int OcjeneId { get;set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User{ get;set; }
        public int UgostiteljskiObjektiId { get; set; }
        [ForeignKey("UgostiteljskiObjektiId")]
        public virtual UgostiteljskiObjekti UgostiteljskiObjekti { get;set; }
        public int Ocjena { get;set; }
        public DateTime OcjenaVrijeme { get; set; }
    }
}
