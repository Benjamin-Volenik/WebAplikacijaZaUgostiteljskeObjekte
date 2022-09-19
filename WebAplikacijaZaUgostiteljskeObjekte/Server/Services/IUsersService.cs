using WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Services
{
    public interface IUsersService
    {
        public List<UserModel> Korisnici();
        public void DodajKorisnika(CreateUser noviKorisnik);
        public void UkloniKorisnika(int id);
    }
}
