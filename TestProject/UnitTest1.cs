using Entities;
using Infractructure;
using UseCases;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void CreateTodoItem_And_Set_Completed_Test()
        {
            var mockRepository = new InMemoryTodoItemRepository();
            var todoListManager = new TodoListManager(mockRepository);
            var todoItem = new Entities.ToDoItem { ID = 1, Text = "Mai Trang", IsComplete = false };
            var todoItem2 = new Entities.ToDoItem { ID = 2, Text = "Minh Hoàng", IsComplete = false };

            todoListManager.AddTodoItem(todoItem);
            todoListManager.MarkComplete(1);
            todoListManager.AddTodoItem(todoItem2);
            todoListManager.MarkComplete(2);


            Assert.True(todoListManager.getTodoItems().First().IsComplete);
            Assert.Equal("Mai Trang",todoListManager.getTodoItems().First().Text);
        }
    }
}