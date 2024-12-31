using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace UseCases
{
    public class TodoListManager
    {
        private readonly ITodoItemRepository<Entities.ToDoItem> repository;
        //private readonly ITodoItemRepository<Entities.ToDoItem> repository;

        public TodoListManager(ITodoItemRepository<Entities.ToDoItem> repository)
        {
            this.repository = repository;
        }
        public IEnumerable<ToDoItem> getTodoItems()
        {
            return repository.GetItems();
        }

        public void AddTodoItem(ToDoItem item)
        {
            repository.Add(item);
        }

        public void MarkComplete(int id)
        {
            //var item = repository.getById(id);
            ToDoItem item = repository.getById(id);
            if (item != null)
            {
                item.IsComplete = true;
                repository.Update(item);
            }
        }
        public void Delete(int id)
        {

            repository.Delete(id);

        }
    }
}
