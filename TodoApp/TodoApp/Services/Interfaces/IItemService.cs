using System.Threading.Tasks;

namespace TodoApp.Services.Interfaces
{
    public interface IItemService
    {
        Task Load();
        Task Save();
    }
}
