using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int UgostiteljskiObjektId { get; set; }
        [ForeignKey("UgostiteljskiObjektId")]
        public virtual UgostiteljskiObjekti UgostiteljskiObjekti { get; set; }
        public DateTime CommentTime { get; set; }
    }
}
