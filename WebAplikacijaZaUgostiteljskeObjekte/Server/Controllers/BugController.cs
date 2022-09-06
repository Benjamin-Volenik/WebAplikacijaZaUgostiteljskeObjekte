using Microsoft.AspNetCore.Mvc;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Services;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugController : ControllerBase
    {
        private readonly IBugService bugService;

        public BugController(IBugService bugService)
        {
            this.bugService = bugService;
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
    }
}
