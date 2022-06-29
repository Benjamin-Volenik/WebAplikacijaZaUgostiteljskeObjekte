using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Services
{
    public interface ICommentService
    {
        public void DodajKomentar(AddComment noviKomentar);

        public List<CommentModel> Komentari();
    }
}
