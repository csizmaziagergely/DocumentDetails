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

        public static List<DocumentView> ToDocumentView(this List<Document> documents)
        {
            List<DocumentView> documentViewList = new List<DocumentView>();
            foreach (var document in documents)
            {
                documentViewList.Add( new DocumentView()
                {
                    id = document.Id,
                    title = document.Title,
                    extension = document.Extension.ToString(),
                    main_id = document.ParentId ?? 0,
                    source = document.Source.ToString()
                });
            }
            return documentViewList;
        }
    }
}
