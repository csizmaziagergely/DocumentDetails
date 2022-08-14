using DocumentDetails.DTOs;
using DocumentDetails.Entities;
using DocumentDetails.Enums;

namespace DocumentDetails.Extensions
{
    public static class DocumentLogExtensions
    {
        public static DocumentLog ToDocumentLogEntity(this DocumentLogView documentLogView)
        {
            return new DocumentLog()
            {
                Id = documentLogView.id,
                DocumentId = documentLogView.dokumentum_id,
                EventId = documentLogView.esemeny_id,
                HappenedAt = documentLogView.happened_at
            };
        }

        public static List<DocumentEvent> ToDocumentEvent(this List<DocumentLog> documentLogs)
        {
            List<DocumentEvent> documentEvents = new List<DocumentEvent>();
            foreach (var log in documentLogs)
            {
                documentEvents.Add(new DocumentEvent()
                {
                    HappenedAt = log.HappenedAt.ToString(),
                    Title = log.Event.Title
                });
            }
            return documentEvents;
        }
    }
}
