using Microsoft.EntityFrameworkCore;

namespace Rufat_Soap_to_Rest.Models
{
    /// <summary>
    /// Main data context of project.
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Constructor of data context.
        /// </summary>
        /// <param name="options"></param>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        
        public DbSet<Operations> Operations { get; set; }
        public DbSet<Logs> Logs{ get; set; }

        /// <summary>
        /// Function to implement Fluent API.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Logs>(entity =>
            {
                entity.HasOne(s => s.Operation)
                    .WithMany(s => s.Logs)
                    .HasForeignKey(s => s.Parent_Id)
                    .HasPrincipalKey(s => s.Id)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
