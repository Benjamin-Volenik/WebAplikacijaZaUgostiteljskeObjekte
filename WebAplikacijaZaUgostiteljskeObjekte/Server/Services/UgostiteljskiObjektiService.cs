using AutoMapper;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Services
{
    public class UgostiteljskiObjektiService : IUgostiteljskiObjektiService
    {
        private readonly Data _context;
        private readonly IMapper _mapper;

        public UgostiteljskiObjektiService(Data context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<UgostiteljskiObjektiModel> UgostiteljskiObjekti()
        {
            List<UgostiteljskiObjektiModel> list = new();
            foreach(var uobjekt in _context.UgostiteljskiObjekti)
            {
                list.Add(_mapper.Map<UgostiteljskiObjektiModel>(uobjekt));
            }

            return list;
        }

        public async Task<UgostiteljskiObjektiModel> UrediKontakt(int id, UgostiteljskiObjektiModel urediKontakt)
        {
            _context.Update(urediKontakt);
            await _context.SaveChangesAsync();
            return urediKontakt;
        }
    }
}
