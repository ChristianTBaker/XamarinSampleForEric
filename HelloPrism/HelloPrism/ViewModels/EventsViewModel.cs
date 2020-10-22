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


        public EventsViewModel(INavigationService navigationService)
        {
            this.Title = "Events Page";

            var name = "Tim";

            this.HeaderLabel = $"Service Events Assigned to {name}";
            this.PrimaryButtonLabel = "Back to Main Page";

            this.PrimaryButtonCommand = new DelegateCommand(Back);
        }

        private void Back()
        {
            _navigationService.GoBackAsync();
        }

    }
}
