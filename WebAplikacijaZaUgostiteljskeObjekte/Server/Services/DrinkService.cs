using AutoMapper;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Services
{
    public class DrinkService : IDrinkService
    {
        private readonly Data _context;
        private readonly IMapper _mapper;

        public DrinkService(Data context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void DodajPice(CreateDrink novoPice)
        {
            _context.Pica.Add(_mapper.Map<Drinks>(novoPice));
            _context.SaveChanges();
        }

        public List<DrinksModel> Pica()
        {
            List<DrinksModel> list = new();
            foreach (var drink in _context.Pica)
            {
                list.Add(_mapper.Map<DrinksModel>(drink));
            }
            return list;
        }

        public void UkloniPice(int id)
        {
            _context.Pica.Remove(_context.Pica.Find(id));
            _context.SaveChanges();
        }
    }
}
