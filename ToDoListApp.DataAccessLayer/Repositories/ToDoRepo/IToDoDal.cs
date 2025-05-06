using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.DataAccessLayer.Repositories.Generic;
using ToDoListApp.EntityLayer.Concrete;

namespace ToDoListApp.DataAccessLayer.Repositories.ToDoRepo
{
    public interface IToDoDal:IGenericDal<ToDo>
    {
    }
}
