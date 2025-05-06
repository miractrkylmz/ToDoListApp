using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.EntityLayer.Concrete;

namespace ToDoListApp.BusinessLayer.Abstract
{
    public interface IToDoService
    {
        void Add(ToDo todo);
        void Remove(ToDo todo);
        void Update(ToDo todo);
        List<ToDo> GetAll();
        ToDo GetById(int id);
        void StartTask(int id);
        void CompleteTask(int id);
    }
}
