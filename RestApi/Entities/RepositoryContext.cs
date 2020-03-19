using Entities.Configuration;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : IdentityDbContext<AuthUser>
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
            {
            }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}