using DocumentDetails.DTOs;
using DocumentDetails.Entities;
using DocumentDetails.Enums;

namespace DocumentDetails.Extensions
{
    public static class DocumentExtensions
    {
        public static Document ToDocumentEntity(this DocumentView documentView)
        {
            return new Document()
            {
                Id = documentView.id,
                Title = documentView.title,
                Extension = Enum.Parse<Extension>(documentView.extension),
                ParentId = documentView.main_id == 0 ? null : documentView.main_id,
                Source = Enum.Parse<Source>(documentView.source)
            };
        }
    }
}
