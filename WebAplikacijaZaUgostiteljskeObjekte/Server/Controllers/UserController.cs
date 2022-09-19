using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Services;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersService usersService;

        public UserController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet]
        public List<UserModel> GetUsers()
        {
            return usersService.Korisnici();
        }

        [HttpPost]
        public void AddUser([FromBody]CreateUser newUser)
        {
            usersService.DodajKorisnika(newUser);
        }

        [HttpDelete("{id}")]
        public void DeleteUser([FromRoute] int id)
        {
            usersService.UkloniKorisnika(id);
        }
    }
}
