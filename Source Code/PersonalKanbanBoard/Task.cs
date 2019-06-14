using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalKanbanBoard
{
   public class Task
    {
        public string TaskId { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public string TaskPriority { get; set; }
        public string TaskNotes { get; set; }
        public string TaskStatus { get; set; }
        public string ProjectId { get; set; }
        public string DependentTaskID { get; set; }
    }
}
