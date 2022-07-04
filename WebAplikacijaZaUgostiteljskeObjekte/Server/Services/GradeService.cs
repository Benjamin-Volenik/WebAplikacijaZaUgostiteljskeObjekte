using AutoMapper;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Services
{
    public class GradeService : IGradeService
    {
        private readonly Data _context;
        private readonly IMapper _mapper;

        public GradeService(Data context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void DodajOcjenu(AddGrade ocjena)
        {
            _context.Ocjene.Add(_mapper.Map<Ocjene>(ocjena));
            _context.SaveChanges();
        }

        public List<OcjeneModel> sveOcjene()
        {
            List<OcjeneModel> list = new();
            foreach (var ocjena in _context.Ocjene)
            {
                list.Add(_mapper.Map<OcjeneModel>(ocjena));
            }
            return list;
        }

        public void UkloniOcjenu(int id)
        {
            _context.Ocjene.Remove(_context.Ocjene.Find(id));
            _context.SaveChanges();
        }
    }
}
