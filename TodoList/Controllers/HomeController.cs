using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using UseCases;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TodoListManager _listManager;
        private readonly ITodoItemRepository<Entities.ToDoItem> _todoRepository;

        public HomeController(ITodoItemRepository<Entities.ToDoItem> todoRepository, TodoListManager listManager, ILogger<HomeController> logger)
        {
            _logger = logger;
            _listManager = listManager;
            _todoRepository = todoRepository;
        }

        public IActionResult Index()
        {

            var items = _todoRepository.GetItems();

            var viewModel = new TodoListViewModel
            {
                Items = items

            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Add(string Text) {
            if (!string.IsNullOrEmpty(Text))
            {
                var newItem = new Entities.ToDoItem { Text = Text, IsComplete = false };
                _todoRepository.Add(newItem);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Finish(int id)
        {
            var item = _todoRepository.getById(id);
            if (item != null)
            {
                item.IsComplete = true;
                _todoRepository.Update(item);

                return Json(
                    new
                    {
                        success = true,
                        id = item.ID,
                        isComplete = item.IsComplete

                    });
            }
            return Json(new { success = false, message = "Task not found" });
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var item = _todoRepository.getById(id);
            if (item != null)
            {
                _todoRepository.Delete(id); // Assuming your repository has a Delete method

                return Json(new { success = true, id = item.ID });
            }
            return Json(new { success = false, message = "Task not found" });
        }

        public IActionResult Search(string text)
        {
            var list = _todoRepository.GetItemsByText(text);
            var viewModel = new TodoListViewModel
            {
                Items = list

            };
            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
