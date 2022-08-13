using CsvHelper.Configuration;
using DocumentDetails.Entities;

namespace DocumentDetails.DTOs
{
    public class DocumentView
    {
        public int id { get; set; }
        public string title { get; set; }
        public string extension { get; set; }
        public int main_id { get; set; }
        public string source { get; set; }
    }
}
