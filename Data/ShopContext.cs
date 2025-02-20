using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ShopContext : IdentityDbContext<IdentityUser>
    {
       
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<OrderEntity> Orders { get; set; } 
        
        

        public ShopContext(DbContextOptions<ShopContext> options)
    :   base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            

            modelBuilder.Entity<ProductEntity>().HasData(
                new ProductEntity { Id = 1, Name = "ASP.NET", Price = 199.99M, Description = "Podstawowy kurs ASP.NET" }
            );

            string ADMIN_ID = Guid.NewGuid().ToString();
            string ROLE_ID = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            var admin = new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "adminuser@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "adminuser@wsei.edu.pl",
                NormalizedUserName = "ADMINUSER@WSEI.EDU.PL",
                NormalizedEmail = "ADMINUSER@WSEI.EDU.PL"
            };

            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = ph.HashPassword(admin, "S3cretPassword");

            modelBuilder.Entity<IdentityUser>().HasData(admin);

            modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
        }
    }
}
