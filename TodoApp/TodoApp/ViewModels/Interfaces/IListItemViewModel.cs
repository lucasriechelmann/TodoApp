using System.Collections.ObjectModel;
using TodoApp.Models;

namespace TodoApp.ViewModels.Interfaces
{
    public interface IListItemViewModel : IViewModelBase
    {
        ObservableCollection<Item> ListItems { get; set; }
    }
}
