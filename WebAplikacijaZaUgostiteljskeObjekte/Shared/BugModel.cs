using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAplikacijaZaUgostiteljskeObjekte.Shared
{
    public class BugModel
    {
        public int BugId { get; set; }
        public int UserIdBug { get; set; }
        public int UgostiteljskiObjektiIdBug { get; set; }
        public string UserEmail { get; set; }
        public string BugText { get; set; }
        public int BugStaus { get; set; }
        public DateTime BugVrijeme { get; set; }
    }
}
