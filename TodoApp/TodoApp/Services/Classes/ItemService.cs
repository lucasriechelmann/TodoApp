using Prism.Navigation;
using System.Threading.Tasks;
using TodoApp.Models;
using TodoApp.Services.Interfaces;
using TodoApp.ViewModels.Interfaces;

namespace TodoApp.Services.Classes
{
    public class ItemService : IItemService
    {
        public ItemService(IItemViewModel viewModel, IRepositoryService repository)
        {
            _viewModel = viewModel;
            _viewModel.Title = "Item";
            _viewModel.Item = new Item();
            _repository = repository;
        }

        IItemViewModel _viewModel;
        IRepositoryService _repository;

        public async Task Load()
        {
            _viewModel.Item = await _repository.Get<Item>(_viewModel.Id);
        }

        public async Task Save()
        {
            if(string.IsNullOrEmpty(_viewModel.Item.Title) || string.IsNullOrEmpty(_viewModel.Item.Description))
            {
                await _viewModel.DialogService.DisplayAlertAsync(_viewModel.Title, "Need to inform Title and Description", "Ok");
                return;
            }

            await _repository.Save(_viewModel.Item);
            INavigationParameters param = new NavigationParameters();
            param.Add("load", true);
            await _viewModel.NavigationService.GoBackAsync(param);
        }
    }
}
