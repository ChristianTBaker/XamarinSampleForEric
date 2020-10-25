using System;
using System.Collections.Generic;
using HelloPrism.Interfaces;
using HelloPrism.Models;
using Newtonsoft.Json;

namespace HelloPrism.Services
{
    public class DataManager : IDataManager
    {
        public DataManager()
        {
        }

        public List<Event> GetEvents()
        {
            object events;

            if (App.Current.Properties.TryGetValue("Events", out events))
            {
                return JsonConvert.DeserializeObject<List<Event>>((string)events);
            }
            else
            {
                var eventList = new List<Event>();
                eventList.Add(new Event(1, "Inspection", new DateTime(2020, 8, 5)));
                eventList.Add(new Event(2, "Service", new DateTime(2020, 9, 1)));
                eventList.Add(new Event(3, "Calibration", new DateTime(2020, 10, 25)));
                eventList.Add(new Event(4, "Inspection", new DateTime(2020, 11, 9)));
                eventList.Add(new Event(5, "Service", new DateTime(2020, 12, 15)));
                eventList.Add(new Event(6, "Inspection", new DateTime(2020, 12, 16)));
                this.SaveEvents(eventList);

                return eventList;
            }
        }

        public void SaveEvents(List<Event> eventsList)
        {
            var eventsJson = JsonConvert.SerializeObject(eventsList, Formatting.Indented);

            object events;

            if (App.Current.Properties.TryGetValue("Events", out events))
                App.Current.Properties["Events"] = eventsJson;
            else
                App.Current.Properties.Add("Events", eventsJson);

            App.Current.SavePropertiesAsync();
        }

        public void EditEvent(Event eventToUpdate)
        {
            var eventList = this.GetEvents();

            for (var i = 0; i < eventList.Count; i++)
            {
                if (eventList[i].Id == eventToUpdate.Id)
                {
                    eventList[i] = eventToUpdate;
                }
            }

            this.SaveEvents(eventList);
        }
    }
}
