using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases;
using Entities;

namespace Infractructure
{
    public class InMemoryTodoItemRepository : ITodoItemRepository<Entities.ToDoItem>
    {
        private readonly List<Entities.ToDoItem> _items;
        public InMemoryTodoItemRepository()
        {
            _items = new List<Entities.ToDoItem>();
        }
        public void Add(Entities.ToDoItem item)
        {
            _items.Add(item);
        }

        public void Delete(int id)
        {
            var item = _items.FirstOrDefault(x => x.ID == id);
            if (item != null)
            {
                _items.Remove(item);
            }

        }

        public Entities.ToDoItem getById(int id)
        {
            return _items.FirstOrDefault(x => x.ID == id);

        }


        public IEnumerable<Entities.ToDoItem> GetItems()
        {
            return _items;
        }

        public IEnumerable<Entities.ToDoItem> GetItemsByText(string text)
        {
            throw new NotImplementedException();
        }

        public void Update(Entities.ToDoItem item)
        {
            var existItem = _items.FirstOrDefault(x => x.ID == item.ID);
            if (existItem != null)
            {
                existItem.Text = item.Text;
                existItem.IsComplete = item.IsComplete;

            }
        }
    }
}
