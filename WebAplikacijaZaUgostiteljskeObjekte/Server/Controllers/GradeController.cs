using Microsoft.AspNetCore.Mvc;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Services;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Controllers
{
    [Route("api/Ocjene")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService gradeService;
        private readonly Data _context;

        public GradeController(Data context, IGradeService gradeService)
        {
            _context = context;
            this.gradeService = gradeService;
        }
        [HttpGet]
        public List<OcjeneModel> GetGrades()
        {
            return gradeService.sveOcjene();
        }

        [HttpPost]
        public void AddGrade([FromBody] AddGrade newGrade)
        {
            gradeService.DodajOcjenu(newGrade);
        }

        [HttpDelete("{id}")]
        public void DeleteGrade([FromRoute] int id)
        {
            gradeService.UkloniOcjenu(id);
        }
    }
}
