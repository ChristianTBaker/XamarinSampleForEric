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
                EventCollection eventCollection = JsonConvert.DeserializeObject<EventCollection>((string)events);

                return eventCollection.EventList;
            }

            return new List<Event>();
        }

        public void SaveEvents(List<Event> eventsList)
        {
            var eventsJson = JsonConvert.SerializeObject(new EventCollection(eventsList));

            object events;

            if (App.Current.Properties.TryGetValue("Events", out events))
                App.Current.Properties["Events"] = eventsJson;
            else
                App.Current.Properties.Add("Events", eventsJson);

            App.Current.SavePropertiesAsync();
        }
    }
}
