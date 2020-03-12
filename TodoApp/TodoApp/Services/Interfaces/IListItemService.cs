using System.Threading.Tasks;

namespace TodoApp.Services.Interfaces
{
    public interface IListItemService
    {
        Task Load(string search);
        Task OpenItem(int? id);
        Task DeleteItem(int id);
    }
}
