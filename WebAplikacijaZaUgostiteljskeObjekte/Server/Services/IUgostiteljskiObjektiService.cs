using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Services
{
    public interface IUgostiteljskiObjektiService
    {
        public List<UgostiteljskiObjektiModel> UgostiteljskiObjekti();

       Task<UgostiteljskiObjektiModel> UrediKontakt(int id,UgostiteljskiObjektiModel urediKontakt);
    }
}
