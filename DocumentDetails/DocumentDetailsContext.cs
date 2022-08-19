using CsvHelper;
using CsvHelper.Configuration;
using DocumentDetails.DTOs;
using DocumentDetails.Entities;
using DocumentDetails.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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
        public DbSet<User> Users { get; set; }
        public DbSet<UserLog> UserLogs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var documents = CsvRead<DocumentView>("dokumentumok.csv").Select(d => d.ToDocumentEntity());
            var documentLogs = CsvRead<DocumentLogView>("naplo.csv").Select(dl => dl.ToDocumentLogEntity());
            var events = CsvRead<EventView>("esemeny.csv").Select(e => e.ToEventEntity());
            modelBuilder.Entity<Document>().ToTable("dokumentumok").HasData(documents);
            modelBuilder.Entity<DocumentLog>().ToTable("naplo").HasData(documentLogs);
            modelBuilder.Entity<Event>().ToTable("esemeny").HasData(events);
            modelBuilder.Entity<User>().ToTable("User").HasAlternateKey(u => u.UserName);
            modelBuilder.Entity<UserLog>().ToTable("UserLog");

        }

        private List<T> CsvRead<T>(string fileName)
        {
            string path = Path.Join(Directory.GetCurrentDirectory(), "Data", fileName);
            using (var reader = new StreamReader(path))
            {
                var config = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";" };
                using (var csv = new CsvReader(reader, config))
                {
                    var records = csv.GetRecords<T>();
                    return records.ToList();
                }
            }
        }
    }
}
