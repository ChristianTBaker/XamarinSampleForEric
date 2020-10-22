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

        public DelegateCommand SubmitCommand { get; private set; }

        public string Title { get; private set; }
        public string WelcomeMessage { get; private set; }
        public string FirstNameLabel { get; private set; }
        public string LastNameLabel { get; private set; }
        public string EmailLabel { get; private set; }
        public string SubmitButtonLabel { get; private set; }

        public MainViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;

            this.Title = "Main Page";
            this.WelcomeMessage = "Welcome to Xamarin Sample!";
            this.FirstNameLabel = "First Name";
            this.LastNameLabel = "Last Name";
            this.EmailLabel = "email";
            this.SubmitButtonLabel = "View Service Events";

            this.SubmitCommand = new DelegateCommand(Submit, CanSubmit);
        }

        private void Submit()
        {
            _navigationService.NavigateAsync("Events");
        }

        private bool CanSubmit()
        {
            //if (!string.IsNullOrEmpty(this.FirstNameEntry) &&
            //    !string.IsNullOrEmpty(this.LastNameEntry) &&
            //    !string.IsNullOrEmpty(this.EmailEntry))
            // {
            //     return true;
            // }

            // return false;

            return true;
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
