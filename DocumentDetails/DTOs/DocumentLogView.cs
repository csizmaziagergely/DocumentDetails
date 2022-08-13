using CsvHelper.Configuration;
using DocumentDetails.Entities;

namespace DocumentDetails.DTOs
{
    public class DocumentLogView
    {
        public int id { get; set; }
        public int dokumentum_id { get; set; }
        public int esemeny_id { get; set; }
        public DateTime happened_at { get; set; }
    }
}
