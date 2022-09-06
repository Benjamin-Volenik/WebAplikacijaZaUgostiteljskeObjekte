using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Services
{
    public interface IUgostiteljskiObjektiService
    {
        public List<UgostiteljskiObjektiModel> UgostiteljskiObjekti();

       Task<UgostiteljskiObjektiModel> UrediKontakt(int id,UgostiteljskiObjektiModel urediKontakt);

       Task<UgostiteljskiObjektiModel> UrediOcjenu(int id, UgostiteljskiObjektiModel urediOcjenu);

       Task<UgostiteljskiObjektiModel> UrediStanje(int id, UgostiteljskiObjektiModel urediStanje);

        public void DodajUgostiteljskiObjekt(CreateUO noviUO);
    }
}
