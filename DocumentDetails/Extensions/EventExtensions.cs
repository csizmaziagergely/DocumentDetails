using DocumentDetails.DTOs;
using DocumentDetails.Entities;
using DocumentDetails.Enums;

namespace DocumentDetails.Extensions
{
    public static class EventExtensions
    {
        public static Event ToEventEntity(this EventView eventView)
        {
            return new Event()
            {
                Id = eventView.id,
                Title = eventView.title,
            };
        }
    }
}
