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
    public class MainViewModel : BindableBase
    {
        private INavigationService _navigationService;
        private IProfileManager _profileManager;

        public DelegateCommand PrimaryButtonCommand { get; private set; }

        public string Title { get; private set; }
        public string HeaderLabel { get; private set; }
        public string FirstNameLabel { get; private set; }
        public string LastNameLabel { get; private set; }
        public string EmailLabel { get; private set; }
        public string PrimaryButtonLabel { get; private set; }

        public MainViewModel(INavigationService navigationService, IProfileManager profileManager, IDataManager dataManager)
        {
            this._navigationService = navigationService;

            this.Title = "Main Page";
            this.HeaderLabel = "Welcome to Xamarin Sample!";
            this.FirstNameLabel = "First Name";
            this.LastNameLabel = "Last Name";
            this.EmailLabel = "email";
            this.PrimaryButtonLabel = "View Service Events";

            this.PrimaryButtonCommand = new DelegateCommand(Submit, CanSubmit);

            //Setting MOCK Data
            var events = new List<Event>();
            events.Add(new Event(_navigationService, 1, "Inspection", "05 Aug 2020"));
            events.Add(new Event(_navigationService, 2, "Service", "01 Sep 2020"));
            events.Add(new Event(_navigationService, 3, "Calibration", "25 Oct, 2020"));
            events.Add(new Event(_navigationService, 4, "Inspection", "09 Nov, 2020"));
            events.Add(new Event(_navigationService, 5, "Service", "15 Dec, 2020"));
            events.Add(new Event(_navigationService, 6, "Inspection", "16 Dec, 2020"));
            dataManager.SaveEvents(events);
        }

        private void Submit()
        {
            //I'm assuming id would come from api and there's not multiple users on a local app
            _profileManager.SaveProfile(new Models.Profile(1, this.FirstNameEntry, this.LastNameEntry, this.EmailEntry));

            _navigationService.NavigateAsync("Events");
        }

        private bool CanSubmit()
        {
            if (!string.IsNullOrEmpty(this.FirstNameEntry) &&
                !string.IsNullOrEmpty(this.LastNameEntry) &&
                !string.IsNullOrEmpty(this.EmailEntry))
            {
                return true;
            }

            return false;
        }

        private string _firstNameEntry;
        public string FirstNameEntry
        {
            get => this._firstNameEntry;
            set => SetProperty(ref this._firstNameEntry, value);
        }

        private string _lastNameEntry;
        public string LastNameEntry
        {
            get => this._lastNameEntry;
            set => SetProperty(ref this._lastNameEntry, value);
        }

        private string _emailEntry;
        public string EmailEntry
        {
            get => this._emailEntry;
            set => SetProperty(ref this._emailEntry, value);
        }
    }
}
