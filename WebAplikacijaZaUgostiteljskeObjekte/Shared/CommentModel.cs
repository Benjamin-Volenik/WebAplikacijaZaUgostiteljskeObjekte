﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAplikacijaZaUgostiteljskeObjekte.Shared
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public int UserId { get; set; }
        public int UgostiteljskiObjektId { get; set; }
        public DateTime CommentTime { get; set; }
    }
}
