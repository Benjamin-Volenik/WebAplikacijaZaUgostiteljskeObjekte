using AutoMapper;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Services
{
    public class DishService : IDishService
    {
        private readonly Data _context;
        private readonly IMapper _mapper;

        public DishService(Data context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void DodajJelo(CreateDish novoJelo)
        {
            _context.Jela.Add(_mapper.Map<Jela>(novoJelo));
            _context.SaveChanges();
            
        }

        public List<DishModel> Jela()
        {
            List<DishModel> list = new();
            foreach (var dish in _context.Jela)
            {
                list.Add(_mapper.Map<DishModel>(dish));
            }
            return list;
        }
    }
}
