using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloPrism.ViewModels
{
    public class EditEventsViewModel : BindableBase
    {
        public EditEventsViewModel()
        {
            this.Title = "Edit Events Page";
        }

        private string title;
        public string Title
        {
            get => this.title;
            set => SetProperty(ref this.title, value);
        }

    }
}
