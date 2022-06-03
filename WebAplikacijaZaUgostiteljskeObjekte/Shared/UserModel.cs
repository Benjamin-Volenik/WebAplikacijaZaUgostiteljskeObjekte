using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAplikacijaZaUgostiteljskeObjekte.Shared
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Ovo polje ne smije biti prazno.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Ovo polje ne smije biti prazno.")]
        public string Password { get; set; }
        public virtual List<CommentModel> Comments { get; set; }
    }
}
