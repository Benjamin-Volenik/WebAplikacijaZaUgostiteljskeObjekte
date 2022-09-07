using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAplikacijaZaUgostiteljskeObjekte.Client.Pages;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Services;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugController : ControllerBase
    {
        private readonly IBugService bugService;
        private readonly Data _context;

        public BugController(Data context,IBugService bugService)
        {
            this.bugService = bugService;
            _context = context;
        }

        [HttpGet]
        public List<BugModel> GetBugs()
        {
            return bugService.Bugovi();
        }

        [HttpPost]
        public void AddBug([FromBody] BugModel newBug)
        {
            bugService.PrijaviBug(newBug);
        }

        [HttpPut]
        public async Task<IActionResult> Put(PrijavljeniBugovi bugovi)
        {
            _context.Entry(bugovi).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
