using System.ComponentModel.DataAnnotations;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities.DTO
{
    public class UserForRegistrationDto
    {
        [Required(ErrorMessage = "Ovo polje ne smije biti prazno.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ovo polje ne smije biti prazno.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Niste unesli Email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Niste unesli lozniku.")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Lozink se ne poklapaju.")]
        public string ConfirmPassword { get; set; }
    }
}
