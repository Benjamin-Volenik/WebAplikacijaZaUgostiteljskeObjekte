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
        [Required(ErrorMessage = "Ovo polje ne smije biti prazno.")]
        public string UgostiteljskiObjektiOIB { get; set; }
        [Required(ErrorMessage = "Ovo polje ne smije biti prazno.")]
        public string UgostiteljskiObjektiVlasnik { get; set; }
        [Required(ErrorMessage = "Niste unesli Email.")]
        public string UgostiteljskiObjektiEmali { get; set; }
        [Required(ErrorMessage = "Niste unesli lozniku.")]
        public string UgostiteljskiObjektiLozinka { get; set; }
        [Compare("UgostiteljskiObjektiLozinka", ErrorMessage = "Lozinke se ne poklapaju.")]
        public string UgostiteljskiObjektiConfirmPassword { get; set; }
        public float UgostiteljskiObjektiProsjecnaOcjena { get; set; }
        public string UgostiteljskiObjektiSlika { get; set; }
        public string UgostiteljskiObjektiStanje { get; set; }
        [Required(ErrorMessage = "Morate odabrati tip.")]
        public string UgostiteljskiObjektiTip { get; set; }
        [Required(ErrorMessage = "Morate unesti naziv grada.")]
        public string UgostiteljskiObjektiGrad { get; set; }
        [Required(ErrorMessage = "Niste unesti naziv ulice.")]
        public string UgostiteljskiObjektiUlica { get; set; }
        [Required(ErrorMessage = "Niste unesti kućni broj.")]
        public int UgostiteljskiObjektiKucniBroj { get; set; }
        [Required(ErrorMessage = "Morate unesti latitudu.")]
        public float UgostiteljskiObjektiLatituda { get; set; }
        [Required(ErrorMessage = "Morate unesti longitutdu.")]
        public float UgostiteljskiObjektiLongituda { get; set; }
        [Required(ErrorMessage = "Morate unesti radno vrijeme.")]
        public string UgostiteljskiObjektiRadnoVrijeme { get; set; }
        [Required(ErrorMessage = "Morate unesti radno vrijeme.")]
        public string UgostiteljskiObjektiRadnoVrijemePraznici { get; set; }
        [Required(ErrorMessage = "Morate unesti radno vrijeme.")]
        public string UgostiteljskiObjektiRadnoVrijemeSub { get; set; }
        [Required(ErrorMessage = "Morate unesti radno vrijeme.")]
        public string UgostiteljskiObjektiRadnoVrijemeNed { get; set; }
        public string UgostiteljskiObjektiPdfPutanja { get; set; }
    }
}
