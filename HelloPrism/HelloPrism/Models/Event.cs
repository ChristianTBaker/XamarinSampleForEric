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

        public int Id { get; private set; }
        public string EventTypeLabel { get; private set; }
        public string EventType { get; private set; }
        public string EventDateLabel { get; private set; }
        public string EventDate { get; private set; }
    }
}
