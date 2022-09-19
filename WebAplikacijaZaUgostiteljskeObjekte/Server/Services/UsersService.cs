using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Services
{
    public class UsersService : IUsersService
    {
        private readonly Data _context;
        private readonly IMapper _mapper;

        public UsersService(Data context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void DodajKorisnika(CreateUser noviKorisnik)
        {
            _context.Korisnici.Add(_mapper.Map<User>(noviKorisnik));
            _context.SaveChanges();
        }

        public List<UserModel> Korisnici()
        {
            List<UserModel> list = new();
            foreach(var user in _context.Korisnici.Include(k => k.Comments))
            {
                list.Add(_mapper.Map<UserModel>(user));
            }
            return list;
        }

        public void UkloniKorisnika(int id)
        {
            _context.Korisnici.Remove(_context.Korisnici.Find(id));
            _context.SaveChanges();
        }
    }
}
