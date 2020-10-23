using HelloPrism.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloPrism.ViewModels
{
    public class EventsViewModel : BindableBase
    {
        private INavigationService _navigationService;

        public DelegateCommand PrimaryButtonCommand { get; private set; }

        public string Title { get; private set; }
        public string HeaderLabel { get; private set; }
        public string PrimaryButtonLabel { get; private set; }

        public Event[] Events { get; private set; }


        public EventsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            this.Title = "Events Page";

            var name = "Tim";

            this.HeaderLabel = $"Service Events Assigned to {name}";
            this.PrimaryButtonLabel = "Back to Main Page";

            this.PrimaryButtonCommand = new DelegateCommand(Back);

            this.Events = new Event[]
            {
                new Event(_navigationService, 1, "Inspection", "05 Aug 2020"),
                new Event(_navigationService, 2, "Service", "01 Sep 2020"),
                new Event(_navigationService, 3, "Calibration", "25 Oct, 2020"),
                new Event(_navigationService, 4, "Inspection", "09 Nov, 2020"),
                new Event(_navigationService, 5, "Service", "15 Dec, 2020"),
                new Event(_navigationService, 6, "Inspection", "16 Dec, 2020")
            };      
        }

        public void OnAppearing()
        {
            this.SelectedEvent = null;
        }

        private Event _selectedEvent;
        public Event SelectedEvent
        {
            get => this._selectedEvent;
            set
            {
                if (SetProperty(ref this._selectedEvent, value) && this.SelectedEvent != null)
                {
                    _selectedEvent.EditEventCommand.Execute();
                }
            }
        }

        private void Back()
        {
            _navigationService.GoBackAsync();
        }
    }
}
