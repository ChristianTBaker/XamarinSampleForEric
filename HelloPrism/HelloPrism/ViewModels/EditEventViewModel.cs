using HelloPrism.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloPrism.ViewModels
{
    public class EditEventViewModel : BindableBase, INavigatedAware
    {
        private INavigationService _navigationService;
        private IDataManager _dataManager;

        public DelegateCommand PrimaryButtonCommand { get; private set; }

        public string Title { get; private set; }
        public string EventNameLabel { get; private set; }
        public string EventDateLabel { get; private set; }
        public string PrimaryButtonLabel { get; private set; }

        private int _id;
        private DateTime _validDateTime;

        public EditEventViewModel(INavigationService navigationService, IDataManager dataManager)
        {
            this._navigationService = navigationService;
            this._dataManager = dataManager;

            this.Title = "Edit Events Page";
            this.HeaderLabel = $"Edit Event {_id}";
            this.EventNameLabel = "Event Name";
            this.EventDateLabel = "Event Date";
            this.PrimaryButtonLabel = "Save Changes";

            this.PrimaryButtonCommand = new DelegateCommand(Save, CanSave);
        }

        private void Save()



        {
            this._dataManager.EditEvent(new Models.Event(_id, this.EventNameEntry, this._validDateTime));

            //This is a hack made for two reasons"
            // A) I'm already runnning past time and want to skip setting up the ListView to update on item source change
            // B) I would just use CollectionView if I was using a more upto date version of Xamarin
            //    Updating anything is just causing more propblems right now that I'm avoiding
            _navigationService.NavigateAsync("/Main");;
            _navigationService.NavigateAsync("Events");

        }

        private bool CanSave()
        {
            if (!string.IsNullOrEmpty(this.EventNameEntry) &&
                !string.IsNullOrEmpty(this.DateEntry) &&
                DateTime.TryParse(this.DateEntry, out DateTime date))
            {
                this._validDateTime = date;

                return true;
            }

            return false;
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            int id;

            if (parameters.TryGetValue<int>("Id", out id))
            {
                this._id = id;
                this.HeaderLabel = $"Edit Event {_id}";
            }
            else
            {
                //TODO Add error handeling (skipping for time)
            }
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        private string _headerLabel;
        public string HeaderLabel
        {
            get => _headerLabel;
            set => this.SetProperty(ref _headerLabel, value);
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
