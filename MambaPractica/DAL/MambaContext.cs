using MambaPractica.Models;
using Microsoft.EntityFrameworkCore;

namespace MambaPractica.DAL
{
    public class MambaContext : DbContext
    {
        public MambaContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Team> Teams { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("server=LAPTOP-IM3K1CPI\\SQLEXPRESS;database=MambaDb;trusted_connection=true;Integrated security=true;encrypt=false;");
            base.OnConfiguring(options);
        }
    }
}
