namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities
{
    public class Ocjene
    {
        public int OcjeneId { get;set; }
        public string UserId { get;set; }
        public string UgostiteljskiObjektiId { get;set; }
        public int Ocjena { get;set; }
    }
}
