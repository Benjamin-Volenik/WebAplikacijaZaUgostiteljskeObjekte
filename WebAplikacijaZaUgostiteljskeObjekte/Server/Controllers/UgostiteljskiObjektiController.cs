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
    public class UgostiteljskiObjektiController : ControllerBase
    {
        private readonly IUgostiteljskiObjektiService ugostiteljskiObjektiService;
        private readonly Data _context;

        public UgostiteljskiObjektiController(Data context, IUgostiteljskiObjektiService ugostiteljskiObjektiService)
        {
            this.ugostiteljskiObjektiService = ugostiteljskiObjektiService;
            _context = context;
        }
        [HttpGet]
        public List<UgostiteljskiObjektiModel> DajUgostiteljskeObjekte()
        {
            return ugostiteljskiObjektiService.UgostiteljskiObjekti();
        }

        [HttpGet("{ugostiteljskiObjektiId}")]
        public async Task<IActionResult> Get(int ugostiteljskiObjektiId)
        {
            var dev = await _context.UgostiteljskiObjekti.FirstOrDefaultAsync(a => a.UgostiteljskiObjektiId == ugostiteljskiObjektiId);
            return Ok(dev);
        }


        [HttpPut]
        public async Task<IActionResult> Put(UgostiteljskiObjekti developer)
        {
            _context.Entry(developer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost]
        public void AddUO([FromBody] CreateUO newUO)
        {
            ugostiteljskiObjektiService.DodajUgostiteljskiObjekt(newUO);
        }

        [HttpDelete("{id}")]
        public void DeleteUO([FromRoute] int id)
        {
            ugostiteljskiObjektiService.UkloniUgostiteljskiObjekt(id);
        }
    }
}
