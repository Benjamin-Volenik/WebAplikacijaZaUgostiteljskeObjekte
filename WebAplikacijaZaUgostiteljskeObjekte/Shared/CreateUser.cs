﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAplikacijaZaUgostiteljskeObjekte.Shared
{
    public class CreateUser
    {
        [Required(ErrorMessage = "Ovo polje ne smije biti prazno.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ovo polje ne smije biti prazno.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Niste unesli Email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Niste unesli lozniku.")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Lozinke se ne poklapaju.")]
        public string ConfirmPassword { get; set; }
    }
}
