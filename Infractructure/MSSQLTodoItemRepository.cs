using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases;

namespace Infractructure
{
    public class MSSQLTodoItemRepository : ITodoItemRepository<Entities.ToDoItem>
    {
        private readonly DX_TESTEntities db;

        public MSSQLTodoItemRepository(DX_TESTEntities db)
        {
            this.db = db;
        }

        public IEnumerable<Entities.ToDoItem> GetItems()
        {
            var dbItems = db.ToDoItems.ToList();

            return dbItems.Select(x => new Entities.ToDoItem
            {
                ID = x.ID,
                Text = x.Text,
                IsComplete = x.IsComplete
            }).ToList();
        }
        public void Add(Entities.ToDoItem item)
        {

            db.ToDoItems.Add(new ToDoItem { ID = item.ID, Text = item.Text, IsComplete = item.IsComplete });
            db.SaveChanges();
        }
        IEnumerable<Entities.ToDoItem> ITodoItemRepository<Entities.ToDoItem>.GetItemsByText(string text)
        {
            var items = db.ToDoItems.Where(x => x.Text.Contains(text)).ToList();
            return items.Select(x => new Entities.ToDoItem
            {
                ID = x.ID,
                Text = x.Text,
                IsComplete = x.IsComplete
            }).ToList();
        }
        public void Update(Entities.ToDoItem item)

        {
            var updateEntity = db.ToDoItems.Where(x=>x.ID == item.ID).FirstOrDefault();
            if (updateEntity != null)
            {
                updateEntity.IsComplete = true;
                db.SaveChanges();
            }
        }
        Entities.ToDoItem ITodoItemRepository<Entities.ToDoItem>.getById(int id)
        {

            var rs = db.ToDoItems.FirstOrDefault(x => x.ID == id);
            return new Entities.ToDoItem { ID = rs.ID, Text = rs.Text, IsComplete = rs.IsComplete };
        }

        public void Delete(int id)
        {
            var entity = db.ToDoItems.Where(x => x.ID == id).FirstOrDefault();
            if (entity != null)
            {
                db.ToDoItems.Remove(entity);
                db.SaveChanges();
            }
        }






    }
}
