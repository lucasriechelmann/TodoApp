using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using TodoApp.Models;
using TodoApp.Services.Classes;
using TodoApp.Services.Interfaces;
using TodoApp.ViewModels.Interfaces;
using Xamarin.Forms;

namespace TodoApp.ViewModels
{
    public class ItemViewModel : ViewModelBase, IItemViewModel
    {
        public ItemViewModel(INavigationService navigationService, IPageDialogService dialogService, IRepositoryService repository) : base(navigationService, dialogService)
        {
            _service = new ItemService(this, repository);
            SaveCommand = new DelegateCommand(async () => await _service.Save());
        }

        IItemService _service;

        public int Id { get; set; }
        Item _item;
        public Item Item { get => _item; set => SetProperty(ref _item, value); }
        public DelegateCommand SaveCommand { get; set; }

        public override void Initialize(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("id"))
            {
                Id = (int)parameters["id"];
                Device.BeginInvokeOnMainThread(async () => await _service.Load());
            }

            base.Initialize(parameters);
        }
    }
}
