using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp.EntityLayer.Concrete
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsCompleted { get; set; }
        public TimeSpan? CompletedDuration { get; set; }
        public DateTime? StartTime { get; set; }
    }
}
