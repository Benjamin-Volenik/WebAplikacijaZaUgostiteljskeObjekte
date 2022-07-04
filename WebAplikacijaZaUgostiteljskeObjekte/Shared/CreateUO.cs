using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAplikacijaZaUgostiteljskeObjekte.Shared
{
    public class CreateUO
    {
        [Required(ErrorMessage = "Ovo polje ne smije biti prazno.")]
        public string UgostiteljskiObjektiNaziv { get; set; }
        [Required(ErrorMessage = "Ovo polje ne smije biti prazno.")]
        public string UgostiteljskiObjektiKontakt { get; set; }
        [Required(ErrorMessage = "Niste unesli Email.")]
        public string UgostiteljskiObjektiEmali { get; set; }
        [Required(ErrorMessage = "Niste unesli lozniku.")]
        public string UgostiteljskiObjektiLozinka { get; set; }
        [Compare("UgostiteljskiObjektiLozinka", ErrorMessage = "Lozinke se ne poklapaju.")]
        public string UgostiteljskiObjektiConfirmPassword { get; set; }
        public float UgostiteljskiObjektiProsjecnaOcjena { get; set; }
        public string UgostiteljskiObjektiSlika { get; set; }
        public string UgostiteljskiObjektiStanje { get; set; }
    }
}
