namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities.DTO
{
    public class RegistrationResponseDto
    {
        public bool IsSuccessfulRegistration { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
