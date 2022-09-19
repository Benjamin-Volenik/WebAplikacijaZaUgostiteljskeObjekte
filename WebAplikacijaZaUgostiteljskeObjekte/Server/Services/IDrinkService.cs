using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Services
{
    public interface IDrinkService
    {
        public void DodajPice(CreateDrink novoPice);

        public List<DrinksModel> Pica();

        public void UkloniPice(int id);
    }
}
