using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace SkyTask.Models
{
    public class SkyDbContext : DbContext
    {
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Plant> Plants { get; set; }

        public string DbPath { get; }

        public SkyDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "skyDB.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
