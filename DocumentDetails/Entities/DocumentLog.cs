namespace DocumentDetails.Entities
{
    public class DocumentLog
    {
        public int DocumentId { get; set; }
        public Document Document { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public DateTime HappenedAt { get; set; }

    }
}
