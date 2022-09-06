using System.ComponentModel.DataAnnotations.Schema;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        [ForeignKey("UserId")]
        public User UserIdd { get; set; }
        [ForeignKey("UgostiteljskiObjektiId")]
        public UgostiteljskiObjekti UgostiteljskiObjektIdd { get; set; }
        public DateTime CommentTime { get; set; }
    }
}
