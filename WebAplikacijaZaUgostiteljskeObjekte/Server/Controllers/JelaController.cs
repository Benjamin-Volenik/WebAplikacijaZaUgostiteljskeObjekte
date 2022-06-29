using Microsoft.AspNetCore.Mvc;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Services;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JelaController : ControllerBase
    {
        private readonly IDishService dishService;
        private readonly Data _context;

        public JelaController(Data context, IDishService dishService)
        {
            _context = context;
            this.dishService = dishService;
        }
        [HttpGet]
        public List<DishModel> GetDishes()
        {
            return dishService.Jela();
        }

        [HttpPost]
        public void AddDish([FromBody] CreateDish newDish)
        {
            dishService.DodajJelo(newDish);
        }

    }
}
