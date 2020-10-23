using System;
using System.Collections.Generic;
using HelloPrism.Models;

namespace HelloPrism.Interfaces
{
    interface IDataManager
    {
        public List<Event> GetEvents();
        public void SaveEvents(List<Event> eventsList);
    }
}
