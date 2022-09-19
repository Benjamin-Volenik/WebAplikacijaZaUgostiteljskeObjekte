using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities;
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

        [HttpDelete("{id}")]
        public void DeleteDish([FromRoute] int id)
        {
            dishService.UkloniJelo(id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Jela uredijelo)
        {
            _context.Entry(uredijelo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
