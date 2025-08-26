
using CQRS_lib.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS_lib.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {

        }
        public DbSet<Items> Items { get; set; }
    }
}
