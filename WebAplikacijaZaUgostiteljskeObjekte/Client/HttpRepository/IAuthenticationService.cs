using WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities.DTO;

namespace WebAplikacijaZaUgostiteljskeObjekte.Client.HttpRepository
{
    public interface IAuthenticationService
    {
        Task<RegistrationResponseDto> RegisterUser(UserForRegistrationDto userForRegistration);
    }
}
