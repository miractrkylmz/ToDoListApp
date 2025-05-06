using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.BusinessLayer.Abstract;
using ToDoListApp.DataAccessLayer.Repositories.ToDoRepo;
using ToDoListApp.EntityLayer.Concrete;

namespace ToDoListApp.BusinessLayer.Concrete
{
    public class ToDoManager : IToDoService
    {

        private readonly IToDoDal _todoDal;
        public ToDoManager(IToDoDal todoDal)
        {
            _todoDal = todoDal;
        }

        public void Add(ToDo todo)
        {
            _todoDal.Insert(todo);
        }

        public void StartTask(int id)
        {
            var task = GetById(id);
            if (task != null && task.StartTime == null)
            {
                task.StartTime = DateTime.Now;
                Update(task);
            }
        }

        public void CompleteTask(int id)
        {
            var task = GetById(id);
            if (task != null && task.StartTime != null)
            {
                task.CompletedDuration = DateTime.Now - task.StartTime.Value;
                task.IsCompleted = true;
                task.StartTime = null;
                Update(task);
            }
        }

        public List<ToDo> GetAll()
        {
            return _todoDal.GetAll();
        }

        public ToDo GetById(int id)
        {
            return _todoDal.GetById(id);
        }

        public void Remove(ToDo todo)
        {
            _todoDal.Delete(todo);
        }


        public void Update(ToDo todo)
        {
            _todoDal.Update(todo);
        }
    }
}
