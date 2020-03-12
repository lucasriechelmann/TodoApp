using SQLite;

namespace TodoApp.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {

        }
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
