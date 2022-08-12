using DocumentDetails.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentDetails.Entities
{
    public class Document
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("extension")]
        public Extension Extension { get; set; }
        [ForeignKey("ParentId")]
        public Document? Parent { get; set; }
        [Column("main_id")]
        public int? ParentId { get; set; }
        [Column("source")]
        public Source Source { get; set; }
    }
}
