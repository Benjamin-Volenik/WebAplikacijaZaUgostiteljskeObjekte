using Microsoft.AspNetCore.Mvc;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Services;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        private readonly IDrinkService drinkService;
        private readonly Data _context;

        public DrinksController(Data context, IDrinkService drinkService)
        {
            _context = context;
            this.drinkService = drinkService;
        }
        [HttpGet]
        public List<DrinksModel> GetDrinks()
        {
            return drinkService.Pica();
        }

        [HttpPost]
        public void AddDrink([FromBody] DrinksModel newDrink)
        {
            drinkService.DodajPice(newDrink);
        }

        [HttpDelete("{id}")]
        public void DeleteDrink([FromRoute] int id)
        {
            drinkService.UkloniPice(id);
        }
    }
}
