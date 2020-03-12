using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TodoApp.Models;
using TodoApp.Services.Interfaces;
using TodoApp.ViewModels.Interfaces;

namespace TodoApp.Services.Classes
{
    public class ListItemService : IListItemService
    {
        public ListItemService(IListItemViewModel viewModel, IRepositoryService repository)
        {
            _viewModel = viewModel;
            _viewModel.Title = "List Items";
            _repository = repository;
        }

        IListItemViewModel _viewModel;
        IRepositoryService _repository;

        public async Task Load(string search)
        {
            var list = string.IsNullOrEmpty(search) ? 
                await _repository.Get<Item>() : 
                await _repository.Get<Item>(x => x.Title.ToLower().Contains(search.ToLower()) || x.Description.ToLower().Contains(search.ToLower()));
            _viewModel.ListItems = new ObservableCollection<Item>(list);
        }

        public async Task OpenItem(int? id)
        {
            INavigationParameters param = new NavigationParameters();
            
            if (id.HasValue)
                param.Add("id", id.Value);

            await _viewModel.NavigationService.NavigateAsync("ItemView", param);
        }

        public async Task DeleteItem(int id)
        {
            var result = await _viewModel.DialogService.DisplayAlertAsync(_viewModel.Title, "Do you want to delete that item?", "Yes", "No");

            if (!result)
                return;

            await _repository.Delete<Item>(id);
            await Load(null);
        }
    }
}
