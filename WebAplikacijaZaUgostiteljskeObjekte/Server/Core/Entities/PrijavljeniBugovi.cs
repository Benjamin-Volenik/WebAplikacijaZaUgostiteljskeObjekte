using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities
{
    public class PrijavljeniBugovi
    {
        [Key]
        public int BugId { get; set; }
        [ForeignKey("UserId")]  
        public User UserIdBug { get; set; }
        public string Email { get; set; }
        public string BugText { get; set; }
        public int BugStaus { get; set; }
        public DateTime BugVrijeme { get; set; }
    }
}
