using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Services
{
    public interface IBugService
    {
        public void PrijaviBug(BugModel noviBug);

        public List<BugModel> Bugovi();
    }
}
