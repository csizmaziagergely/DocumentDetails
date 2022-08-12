using DocumentDetails.Entities;
using Microsoft.EntityFrameworkCore;


namespace DocumentDetails
{
    public class DocumentDetailsContext : DbContext
    {
        public DocumentDetailsContext(DbContextOptions<DocumentDetailsContext> options) : base(options)
        {

        }

        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentLog> DocumentLogs { get; set; }
        public DbSet<Event> EventLogs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Document>().ToTable("dokumentumok");
            modelBuilder.Entity<DocumentLog>().HasNoKey().ToTable("naplo");
            modelBuilder.Entity<Event>().ToTable("esemeny");
        }
    }
}
