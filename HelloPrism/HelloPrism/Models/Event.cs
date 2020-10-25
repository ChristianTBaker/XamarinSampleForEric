using System;
namespace HelloPrism.Models
{
    public class Event
    {
        public Event(int id, string eventType, DateTime eventDate)
        {
            this.Id = id;
            this.EventType = eventType;
            this.EventDate = eventDate;
        }

        public int Id { get; set; }
        public string EventType { get; set; }
        public DateTime EventDate { get; set; }
    }
}
