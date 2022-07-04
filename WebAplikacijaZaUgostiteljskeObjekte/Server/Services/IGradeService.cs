using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Services
{
    public interface IGradeService
    {
        public void DodajOcjenu(AddGrade ocjena);

        public List<OcjeneModel> sveOcjene();

        public void UkloniOcjenu(int id);
    }
}
