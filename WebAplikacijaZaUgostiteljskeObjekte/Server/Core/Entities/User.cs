namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}
