using AbonnementManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace AbonnementManager.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        //Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options): base (options)
        {

        }
        //Dbset properties

        public DbSet<Client> clients { get; set; }  
        public DbSet<Abonnement> abonnements { get; set; }  
        public DbSet<Application> applications { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>().HasData(
                new Client { Id_Client = 1, Name = "Anis", LastName = "Belkacem", Email = "Anis@gmail.com", Tel = "+216 29172360", Description = "hello my name is anis" },
                new Client { Id_Client = 2, Name = "Test", LastName = "Test", Email = "Test@gmail.com", Tel = "+216 29172360", Description = "hello my name is Test" },
                new Client { Id_Client = 3, Name = "Admin", LastName = "Admin", Email = "Admin@gmail.com", Tel = "+216 29172360", Description = "hello my name is Admin" }
                );


        }
    }
}
