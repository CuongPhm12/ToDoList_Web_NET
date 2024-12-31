using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ToDoItem
    {
        public int ID { get; set; }
        public string Text { get; set; } = string.Empty;
        public bool IsComplete { get; set; }
    }
}
