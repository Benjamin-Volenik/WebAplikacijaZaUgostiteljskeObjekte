using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Services
{
    public interface IBugService
    {
        public void PrijaviBug(BugModel noviBug);

        Task<BugModel> UrediStanje(int id, BugModel urediStanje);

        public List<BugModel> Bugovi();
    }
}
