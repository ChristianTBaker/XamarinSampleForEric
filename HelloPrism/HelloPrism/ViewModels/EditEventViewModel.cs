using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloPrism.ViewModels
{
    public class EditEventViewModel : BindableBase
    {
        private INavigationService _navigationService;

        public DelegateCommand PrimaryButtonCommand { get; private set; }

        public string Title { get; private set; }
        public string HeaderLabel { get; private set; }
        public string EventNameLabel { get; private set; }
        public string EventDateLabel { get; private set; }
        public string PrimaryButtonLabel { get; private set; }

        private int _id;

        public EditEventViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;

            this.Title = "Edit Events Page";
            this.HeaderLabel = $"Edit Event {_id}";
            this.EventNameLabel = "Event Name";
            this.EventDateLabel = "Event Date";
            this.PrimaryButtonLabel = "Save Changes";

            this.PrimaryButtonCommand = new DelegateCommand(Save);
        }

        private void Save()
        {
            //This is a hack made for two reasons"
            // A) I'm already runnning past time and want to skip setting up the ListView to update on item source change
            // B) I would just use CollectionView if I was using a more upto date version of Xamarin
            //    Updating anything is just causing more propblems right now that I'm avoiding
            _navigationService.NavigateAsync("/Main");;
            _navigationService.NavigateAsync("Events");

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            int id;

            if (parameters.TryGetValue<int>("Id", out id))
            {
                this._id = id;
            }
            else
            {
                //TODO Add error handeling (skipping for time)
            }
        }

        private string _eventNameEntry;
        public string EventNameEntry
        {
            get => this._eventNameEntry;
            set => SetProperty(ref this._eventNameEntry, value);
        }

        private string _dateEntry;
        public string DateEntry
        {
            get => this._dateEntry;
            set => SetProperty(ref this._dateEntry, value);
        }

    }
}
