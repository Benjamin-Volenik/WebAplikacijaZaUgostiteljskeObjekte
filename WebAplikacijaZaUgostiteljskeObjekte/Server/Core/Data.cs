using Microsoft.EntityFrameworkCore;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Core
{
    public class Data : DbContext
    {
        public Data()
        {

        }
        public Data(DbContextOptions<Data> options) : base(options)
        {

        }
        public DbSet<User> Korisnici { get; set; }
        public DbSet<Comment> Komentari { get; set; }
        public DbSet<Jela> Jela { get; set; }
        public DbSet<Ocjene> Ocjene { get; set; }
        public DbSet<UgostiteljskiObjekti> UgostiteljskiObjekti { get; set; }
    }
}
