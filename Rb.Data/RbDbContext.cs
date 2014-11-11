using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Rb.Data.Entities;

namespace Rb.Data
{
    public class RbDbContext : DbContext
    {
        public RbDbContext()
            : base("RbDatabase")
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}