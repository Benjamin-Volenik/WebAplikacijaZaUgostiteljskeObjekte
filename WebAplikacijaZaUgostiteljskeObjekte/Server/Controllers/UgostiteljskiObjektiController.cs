using Microsoft.AspNetCore.Mvc;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Services;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UgostiteljskiObjektiController : ControllerBase
    {
        private readonly IUgostiteljskiObjektiService ugostiteljskiObjektiService;

        public UgostiteljskiObjektiController(IUgostiteljskiObjektiService ugostiteljskiObjektiService)
        {
            this.ugostiteljskiObjektiService = ugostiteljskiObjektiService;
        }
        [HttpGet]
        public List<UgostiteljskiObjektiModel> DajUgostiteljskeObjekte()
        {
            return ugostiteljskiObjektiService.UgostiteljskiObjekti();
        }
    }
}
