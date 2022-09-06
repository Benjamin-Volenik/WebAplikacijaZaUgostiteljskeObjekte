using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAplikacijaZaUgostiteljskeObjekte.Shared
{
    public class AddComment
    {
        public string CommentText { get; set; }
        public int UserId { get; set; }
        public int UgostiteljskiObjektId { get; set; }
        public DateTime CommentTime { get; set; }
    }
}
