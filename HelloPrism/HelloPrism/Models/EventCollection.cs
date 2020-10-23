using System;
using System.Collections.Generic;

namespace HelloPrism.Models
{
    public class EventCollection
    {
        public List<Event> EventList { get; set; }

        public EventCollection()
        {
        }

        public EventCollection(List<Event> events)
        {
            this.EventList = new List<Event>(events);
        }
    }
}
