using System;
using Prism.Commands;
using Prism.Navigation;

namespace HelloPrism.Models
{
    public class EventBindingModel
    {
        public DelegateCommand EditEventCommand { get; private set; }

        private INavigationService _navigationService;

        public EventBindingModel(INavigationService navigationService, Event basicEventModel)
        {
            this._navigationService = navigationService;

            this.Id = basicEventModel.Id;
            this.EventTypeLabel = "Event Type:";
            this.EventType = basicEventModel.EventType;
            this.EventDateLabel = "Event Date:";
            this.EventDate = basicEventModel.EventDate;

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
        public DateTime EventDate { get; set; }
    }
}
