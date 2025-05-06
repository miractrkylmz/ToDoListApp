using Microsoft.AspNetCore.Mvc;
using ToDoListApp.BusinessLayer.Abstract;
using ToDoListApp.BusinessLayer.Concrete;
using ToDoListApp.DataAccessLayer.Repositories.ToDoRepo;
using ToDoListApp.EntityLayer.Concrete;

namespace ToDoListApp.WebUI.Controllers
{
    public class ToDoController(IToDoService _todoService) : Controller
    {
        private static DateTime _startTime;
        public IActionResult Index()
        {
            var todos = _todoService.GetAll();
            return View(todos);
        }

        [HttpPost]
        public IActionResult StartTask(int id)
        {
            _todoService.StartTask(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CompleteTask(int id)
        {
            _todoService.CompleteTask(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ToDo todo)
        {
            if (ModelState.IsValid)
            {
                _todoService.Add(todo);
                return RedirectToAction("Index");
            }
            return View(todo);
        }
        public ActionResult Delete(int id)
        {
            var todo = _todoService.GetById(id);
            _todoService.Remove(todo);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var todo = _todoService.GetById(id);
            return View(todo);
        }

        [HttpPost]
        public ActionResult Edit(ToDo todo)
        {
            _todoService.Update(todo);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateIsCompleted(int id, bool isCompleted)
        {
            var todo = _todoService.GetById(id);
            if (todo != null)
            {
                todo.IsCompleted = isCompleted;
                _todoService.Update(todo);
            }
            return RedirectToAction("Index");
        }
    }
}
