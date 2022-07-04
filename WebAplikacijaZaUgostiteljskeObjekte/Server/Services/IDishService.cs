using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Services
{
    public interface IDishService
    {
        public void DodajJelo(CreateDish novoJelo);

        public List<DishModel> Jela();

        public void UkloniJelo(int id);
    }
}
