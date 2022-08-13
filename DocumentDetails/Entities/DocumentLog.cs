using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentDetails.Entities
{
    public class DocumentLog
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("dokumentum_id")]
        public int DocumentId { get; set; }
        [ForeignKey("DocumentId")]
        public Document Document { get; set; }
        [Column("esemeny_id")]
        public int EventId { get; set; }
        [ForeignKey("EventId")]
        public Event Event { get; set; }
        [Column("happened_at")]
        public DateTime HappenedAt { get; set; }

    }
}
