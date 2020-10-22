using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloPrism.ViewModels
{
    public class EventsViewModel : BindableBase
    {
        public EventsViewModel()
        {
            this.Title = "Events Page";
        }

        private string title;
        public string Title
        {
            get => this.title;
            set => SetProperty(ref this.title, value);
        }
        
    }
}
