namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities
{
    public class Ocjene
    {
        public int OcjeneId { get;set; }
        public int UserId { get;set; }
        public int UgostiteljskiObjektiId { get;set; }
        public int Ocjena { get;set; }
    }
}
