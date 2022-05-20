using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAplikacijaZaUgostiteljskeObjekte.Shared
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public virtual List<CommentModel> Comments { get; set; }
    }
}
