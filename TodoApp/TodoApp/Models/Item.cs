using SQLite;

namespace TodoApp.Models
{
    public class Item : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
