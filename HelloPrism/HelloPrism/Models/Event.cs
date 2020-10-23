using System;
using Prism.Commands;
using Prism.Navigation;

namespace HelloPrism.Models
{
    public class Event
    {
        public DelegateCommand EditEventCommand { get; private set; }

        private INavigationService _navigationService;

        public Event(INavigationService navigationService, int id, string eventType, string eventDate)
        {
            this._navigationService = navigationService;

            this.Id = id;
            this.EventTypeLabel = "Event Type:";
            this.EventType = eventType;
            this.EventDateLabel = "Event Date:";
            this.EventDate = eventDate;

            this.EditEventCommand = new DelegateCommand(Edit);
        }

        void Edit()
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("Id", this.Id);

            this._navigationService.NavigateAsync("EditEvent", navigationParameters);
        }

        public int Id { get; set; }
        public string EventTypeLabel { get; set; }
        public string EventType { get; set; }
        public string EventDateLabel { get; set; }
        public string EventDate { get; set; }
    }
}
