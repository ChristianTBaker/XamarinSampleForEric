using Prism;
using Prism.Ioc;
using Prism.Unity;
using HelloPrism.Views;
using HelloPrism.ViewModels;
using Xamarin.Forms.Xaml;
using HelloPrism.Interfaces;
using HelloPrism.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HelloPrism
{
    public partial class App : PrismApplication
	{
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await this.NavigationService.NavigateAsync("Main");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage, MainViewModel>("Main");
            containerRegistry.RegisterForNavigation<EventsPage, EventsViewModel>("Events");
            containerRegistry.RegisterForNavigation<EditEventPage, EditEventViewModel>("EditEvent");

            containerRegistry.Register<IProfileManager, ProfileManager>();
            containerRegistry.Register<IDataManager, DataManager>();
        }
    }
}
