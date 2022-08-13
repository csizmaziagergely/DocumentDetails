using CsvHelper.Configuration;
using DocumentDetails.Entities;

namespace DocumentDetails.DTOs
{
    public class DocumentEvent
    {
        public string Title { get; set; }
        public string HappenedAt { get; set; }

    }
}
