using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalKanbanBoard
{
    public class Project
    {
        public string ProjectId { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectDescription { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ToDoLimit { get; set; }
        public string WorkInProgressLimit { get; set; }
        public string DoneLimit { get; set; }
    }
}
