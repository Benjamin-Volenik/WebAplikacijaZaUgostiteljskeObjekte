namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
