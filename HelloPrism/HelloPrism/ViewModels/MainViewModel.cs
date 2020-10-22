using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloPrism.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public MainViewModel()
        {
            this.Title = "Main Page";
            this.WelcomeMessage = "Welcome to Xamarin Sample!";
        }

        private string title;
        public string Title
        {
            get => this.title;
            set => SetProperty(ref this.title, value);
        }

        private string welcomeMessage;
        public string WelcomeMessage
        {
            get => this.welcomeMessage;
            set => SetProperty(ref this.welcomeMessage, value);
        }
    }
}
