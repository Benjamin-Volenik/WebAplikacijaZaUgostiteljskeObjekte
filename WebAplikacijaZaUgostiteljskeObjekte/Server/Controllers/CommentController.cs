using Microsoft.AspNetCore.Mvc;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Services;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService commentService;
        private readonly Data _context;

        public CommentController(Data context, ICommentService commentService)
        {
            _context = context;
            this.commentService = commentService;
        }
        [HttpGet]
        public List<CommentModel> GetComments()
        {
            return commentService.Komentari();
        }

        [HttpPost]
        public void AddComment([FromBody] AddComment newComment)
        {
            commentService.DodajKomentar(newComment);
        }
    }
}
