using System;
using Prism.Commands;
using Prism.Navigation;

namespace HelloPrism.Models
{
    public class Event
    {
        public DelegateCommand DelegatCommand { get; private set; }

        private INavigationService _navigationService;

        public Event(INavigationService navigationService, string eventType, string eventDate)
        {
            this._navigationService = navigationService;

            this.EventTypeLabel = "Event Type:";
            this.EventType = eventType;
            this.EventDateLabel = "Event Date:";
            this.EventDate = eventDate;

            this.DelegatCommand = new DelegateCommand(Edit);
        }

        void Edit()
        {
            this._navigationService.NavigateAsync("EditEvents");
        }

        public string EventTypeLabel { get; private set; }
        public string EventType { get; private set; }
        public string EventDateLabel { get; private set; }
        public string EventDate { get; private set; }
    }
}
