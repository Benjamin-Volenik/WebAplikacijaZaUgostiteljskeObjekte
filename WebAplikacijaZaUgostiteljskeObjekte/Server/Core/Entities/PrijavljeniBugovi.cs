using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities
{
    public class PrijavljeniBugovi
    {
        [Key]
        public int BugId { get; set; } 
        public int UserIdBug { get; set; }
        public int UgostiteljskiObjektiIdBug { get; set; }
        /*[ForeignKey("UserIdBug")]
        public virtual User User { get; set; }
        [ForeignKey("UgostiteljskiObjektiIdBug")]
        public virtual UgostiteljskiObjekti UgostiteljskiObjekti { get; set; }*/
        public string UserEmail { get; set; }
        public string BugText { get; set; }
        public int BugStaus { get; set; }
        public DateTime BugVrijeme { get; set; }
    }
}
