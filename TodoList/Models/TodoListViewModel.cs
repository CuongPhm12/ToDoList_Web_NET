using Entities;

namespace TodoList.Models
{
    public class TodoListViewModel
    {
       public required IEnumerable<Entities.ToDoItem> Items { get; init; }//chỉ cho phép đặt lại giá trị khi khởi tạo lớp
    }
}
