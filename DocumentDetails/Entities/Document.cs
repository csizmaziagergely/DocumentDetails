using DocumentDetails.Enums;

namespace DocumentDetails.Entities
{
    public class Document
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Extension Extension { get; set; }
        public Document? Parent { get; set; }
        public int? ParentId { get; set; }
        public Source Source { get; set; }
    }
}
