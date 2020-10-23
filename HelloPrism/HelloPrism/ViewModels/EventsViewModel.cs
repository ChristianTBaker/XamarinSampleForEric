using HelloPrism.Interfaces;
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

        public List<Event> Events { get; private set; }


        public EventsViewModel(INavigationService navigationService, IProfileManager profileManager, IDataManager dataManager)
        {
            _navigationService = navigationService;

            this.Title = "Events Page";

            var profile = profileManager.GetProfile();

            this.HeaderLabel = $"Service Events Assigned to {profile.FirstName}";
            this.PrimaryButtonLabel = "Back to Main Page";

            this.PrimaryButtonCommand = new DelegateCommand(Back);

            this.Events = dataManager.GetEvents();
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
