using System;
using System.Collections.Generic;
using HelloPrism.Models;

namespace HelloPrism.Interfaces
{
    public interface IDataManager
    {
        public List<Event> GetEvents();
        public void SaveEvents(List<Event> eventsList);
        public void EditEvent(Event eventToUpdate);
    }
}
