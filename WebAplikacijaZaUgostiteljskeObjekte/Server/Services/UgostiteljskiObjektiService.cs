using AutoMapper;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities;
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

        public void DodajUgostiteljskiObjekt(CreateUO noviUO)
        {
            _context.UgostiteljskiObjekti.Add(_mapper.Map<UgostiteljskiObjekti>(noviUO));
            _context.SaveChanges();
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

        public async Task<UgostiteljskiObjektiModel> UrediOcjenu(int id, UgostiteljskiObjektiModel urediOcjenu)
        {
            _context.Update(urediOcjenu);
            await _context.SaveChangesAsync();
            return urediOcjenu;
        }

        public async Task<UgostiteljskiObjektiModel> UrediStanje(int id, UgostiteljskiObjektiModel urediStanje)
        {
            _context.Update(urediStanje);
            await _context.SaveChangesAsync();
            return urediStanje;
        }
    }
}
