using CRM.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM.Context
{
    public class CRMContext : DbContext
    {
        public CRMContext(DbContextOptions<CRMContext> options) : base(options)
        {
            
        }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CRMContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
