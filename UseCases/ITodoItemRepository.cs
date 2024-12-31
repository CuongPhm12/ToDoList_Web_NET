using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace UseCases
{
    public interface ITodoItemRepository<ToDoItem>
    {
        void Add(ToDoItem item);
        void Delete(int id);
        ToDoItem getById(int id);
        IEnumerable<ToDoItem> GetItemsByText(string text);
        IEnumerable<ToDoItem> GetItems();
        void Update(ToDoItem item);
    }
}
