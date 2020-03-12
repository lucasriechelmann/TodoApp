using Prism.Navigation;
using Prism.Services;

namespace TodoApp.ViewModels.Interfaces
{
    public interface IViewModelBase
    {
        string Title { get; set; }
        INavigationService NavigationService { get; }
        IPageDialogService DialogService { get; }
    }
}
