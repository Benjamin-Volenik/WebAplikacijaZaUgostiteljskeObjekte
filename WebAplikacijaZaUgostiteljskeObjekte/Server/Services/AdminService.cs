using AutoMapper;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Services
{
    public class AdminService : IAdminService
    {
        private readonly Data _context;
        private readonly IMapper _mapper;

        public AdminService(Data context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AdminModel> Admin()
        {
            List<AdminModel> list = new();
            foreach (var admin in _context.Admin)
            {
                list.Add(_mapper.Map<AdminModel>(admin));
            }

            return list;
        }
    }
}
