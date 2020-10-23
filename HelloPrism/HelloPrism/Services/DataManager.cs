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
                eventList.Add(new Event(1, "Inspection", "05 Aug 2020"));
                eventList.Add(new Event(2, "Service", "01 Sep 2020"));
                eventList.Add(new Event(3, "Calibration", "25 Oct, 2020"));
                eventList.Add(new Event(4, "Inspection", "09 Nov, 2020"));
                eventList.Add(new Event(5, "Service", "15 Dec, 2020"));
                eventList.Add(new Event(6, "Inspection", "16 Dec, 2020"));
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
