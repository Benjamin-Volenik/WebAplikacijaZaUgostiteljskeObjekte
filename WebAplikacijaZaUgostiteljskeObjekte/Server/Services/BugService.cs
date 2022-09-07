using AutoMapper;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Services
{
    public class BugService : IBugService
    {
        private readonly Data _context;
        private readonly IMapper _mapper;

        public BugService(Data context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void PrijaviBug(BugModel noviBug)
        {
            _context.PrijavljeniBugovi.Add(_mapper.Map<PrijavljeniBugovi>(noviBug));
            _context.SaveChanges();
        }

        public List<BugModel> Bugovi()
        {
            List<BugModel> list = new();
            foreach (var bug in _context.PrijavljeniBugovi)
            {
                list.Add(_mapper.Map<BugModel>(bug));
            }
            return list;
        }

        public async Task<BugModel> UrediStanje(int id, BugModel urediStanje)
        {
            _context.Update(urediStanje);
            await _context.SaveChangesAsync();
            return urediStanje;
        }
    }
}
