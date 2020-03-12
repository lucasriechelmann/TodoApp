using TodoApp.Models;

namespace TodoApp.ViewModels.Interfaces
{
    public interface IItemViewModel : IViewModelBase
    {
        int Id { get; set; }
        Item Item { get; set; }
    }
}
