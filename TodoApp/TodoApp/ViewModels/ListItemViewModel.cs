using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Collections.ObjectModel;
using TodoApp.Models;
using TodoApp.Services.Classes;
using TodoApp.Services.Interfaces;
using TodoApp.ViewModels.Interfaces;
using Xamarin.Forms;

namespace TodoApp.ViewModels
{
    public class ListItemViewModel : ViewModelBase, IListItemViewModel
    {
        public ListItemViewModel(INavigationService navigationService, IPageDialogService dialogService, IRepositoryService repository) : base(navigationService, dialogService)
        {
            _service = new ListItemService(this, repository);

            AddCommand = new DelegateCommand(async () => await _service.OpenItem(null));
            EditCommand = new DelegateCommand<Item>(async (item) => await _service.OpenItem(item.Id));
            DeleteCommand = new DelegateCommand<Item>(async (item) => await _service.DeleteItem(item.Id));
            SearchCommand = new DelegateCommand(async () => await _service.Load(SearchText));
        }


        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand<Item> EditCommand { get; set; }
        public DelegateCommand<Item> DeleteCommand { get; set; }
        public DelegateCommand SearchCommand { get; set; }

        IListItemService _service;
        ObservableCollection<Item> _listItems;
        public ObservableCollection<Item> ListItems { get => _listItems; set => SetProperty(ref _listItems, value); }
        string _searchText;
        public string SearchText 
        { 
            get => _searchText; 
            set
            {
                SetProperty(ref _searchText, value);
                if (string.IsNullOrEmpty(value))
                    Device.BeginInvokeOnMainThread(async () => await _service.Load(null));
            } 
        }

        public override void Initialize(INavigationParameters parameters)
        {
            Device.BeginInvokeOnMainThread(async () => await _service.Load(null));
            base.Initialize(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("load"))
            {
                Device.BeginInvokeOnMainThread(async () => await _service.Load(null));
            }

            base.OnNavigatedTo(parameters);
        }
    }
}
