using Microsoft.EntityFrameworkCore;
using MvcApp.Domain.Entities.Concrete;

namespace MvcApp.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
     
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        
    }
}