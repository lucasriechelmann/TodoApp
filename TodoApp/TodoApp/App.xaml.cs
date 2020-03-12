using Prism;
using Prism.Ioc;
using TodoApp.Services.Classes;
using TodoApp.Services.Interfaces;
using TodoApp.ViewModels;
using TodoApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TodoApp
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/ListItemView");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            #region Views
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<ListItemView, ListItemViewModel>();
            containerRegistry.RegisterForNavigation<ItemView, ItemViewModel>();
            #endregion

            #region Services
            containerRegistry.RegisterSingleton<IRepositoryService, RepositoryService>();
            containerRegistry.RegisterForNavigation<ListItemView, ListItemViewModel>();
            #endregion            
        }
    }
}
