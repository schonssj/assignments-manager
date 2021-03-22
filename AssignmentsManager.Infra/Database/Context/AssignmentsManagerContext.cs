using AssignmentsManager.Core.Entities.Assignments;
using Microsoft.EntityFrameworkCore;

namespace AssignmentsManager.Infra.Database.Context
{
    public class AssignmentsManagerContext : DbContext
    {
        public DbSet<Assignment> Assignment { get; set; }

        public AssignmentsManagerContext(DbContextOptions<AssignmentsManagerContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.Entity<Assignment>().HasKey(t => t.Id);
    }
}
