using DotnetCore.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace DotnetCore.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Institution> Institutions { get; set; }
    }
}
