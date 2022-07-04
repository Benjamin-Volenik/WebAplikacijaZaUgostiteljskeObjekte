using AutoMapper;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Services
{
    public class CommentService : ICommentService
    {
        private readonly Data _context;
        private readonly IMapper _mapper;

        public CommentService(Data context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void DodajKomentar(AddComment noviKomentar)
        {
            _context.Komentari.Add(_mapper.Map<Comment>(noviKomentar));
            _context.SaveChanges();
        }

        public void UkloniKomentar(int id)
        {
            _context.Komentari.Remove(_context.Komentari.Find(id));
            _context.SaveChanges();
        }

        public List<CommentModel> Komentari()
        {
            List<CommentModel> list = new();
            foreach ( var comment in _context.Komentari)
            {
                list.Add(_mapper.Map<CommentModel>(comment));
            }
            return list;
        }
    }
}
