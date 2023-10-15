using Microsoft.EntityFrameworkCore;

namespace Task.Models
{
    public class Context:DbContext
    {
        public DbSet<Glass> Glass { get; set; } 
        public DbSet<Catalog>Catalogs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=.;Initial Catalog=drGreiche_task;Integrated Security=True;TrustServerCertificate=True");
        }
    }
    
}
