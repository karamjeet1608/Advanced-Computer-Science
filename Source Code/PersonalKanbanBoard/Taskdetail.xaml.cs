using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;

namespace PersonalKanbanBoard
{
    /// <summary>
    /// Interaction logic for Taskdetail.xaml
    /// </summary>
    public partial class Taskdetail : Window
    {
        public string selectedtaskstatus;
        public string tastodoid;
        public string tasdoneid;
        public string tasinprogressid;
        public string proid;
        private string id;
        public string valu = "";

        public string ProjectId { get; private set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //taskstatus combobox list 
            List<string> tasksstatus = new List<string>();
            tasksstatus.Add("done");
            tasksstatus.Add("todo");
            tasksstatus.Add("workinprogress");
            taskstatus.ItemsSource = tasksstatus;

            //taskpriority combobox list 
            List<string> taskpriority = new List<string>();
            taskpriority.Add("high");
            taskpriority.Add("Low");
            taskpriority.Add("Medium");
            taskprioritys.ItemsSource = taskpriority;
            string selectedtask = relatedtasks.SelectionBoxItem.ToString();

        }

        // fetching the values from different listview and displaying it on task detail page.
        public Taskdetail(string tastodoid, string tasinprogressid, string tasdoneid, string proid)
        {
            id = proid;
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            {
                //Based on TODO
                if (tastodoid != null)
                {
                    string tastodoids = tastodoid;
                    var tasktododetail = TestStorage.ReadXml<ObservableCollection<Task>>("Tasks.xml");
                    var tasktododata = from s in tasktododetail where s.TaskId.Equals(tastodoid) select s;
                    {
                        taskdetailsstk.DataContext = tasktododata;

                        XmlDocument docum = new XmlDocument();
                        docum.Load("Tasks.xml");
                        foreach (XmlNode x in docum.SelectNodes("ArrayOfTask/Task"))
                            if (x.SelectSingleNode("TaskId").InnerText == tastodoid)
                            {
                                taskstatus.SelectedItem = x.SelectSingleNode("TaskStatus").InnerText;
                                taskprioritys.SelectedItem = x.SelectSingleNode("TaskPriority").InnerText;
                                valu = x.SelectSingleNode("TaskId").InnerText;
                            }
                    }

                }

                //Based on Work In progress
                else if (tasinprogressid != null)
                {
                    string tasinprogressids = tasinprogressid;
                    var taskinprogressdetail = TestStorage.ReadXml<ObservableCollection<Task>>("Tasks.xml");
                    var taskinprogressdata = from s in taskinprogressdetail where s.TaskId.Equals(tasinprogressid) select s;
                    {

                        taskdetailsstk.DataContext = taskinprogressdata;
                        XmlDocument docum = new XmlDocument();
                        docum.Load("Tasks.xml");
                        foreach (XmlNode x in docum.SelectNodes("ArrayOfTask/Task"))
                            if (x.SelectSingleNode("TaskId").InnerText == tasinprogressid)
                            {
                                taskstatus.SelectedItem = x.SelectSingleNode("TaskStatus").InnerText;
                                taskprioritys.SelectedItem = x.SelectSingleNode("TaskPriority").InnerText;
                                valu = x.SelectSingleNode("TaskId").InnerText;
                            }
                    }
                }
                else
                {
                    // Based on Done 
                    var taskdonedetail = TestStorage.ReadXml<ObservableCollection<Task>>("Tasks.xml");
                    var taskdonedata = from s in taskdonedetail where s.TaskId.Equals(tasdoneid) select s;
                    {

                        taskdetailsstk.DataContext = taskdonedata;
                        XmlDocument docum = new XmlDocument();
                        docum.Load("Tasks.xml");
                        foreach (XmlNode x in docum.SelectNodes("ArrayOfTask/Task"))
                            if (x.SelectSingleNode("TaskId").InnerText == tasdoneid)
                            {
                                taskstatus.SelectedItem = x.SelectSingleNode("TaskStatus").InnerText;
                                taskprioritys.SelectedItem = x.SelectSingleNode("TaskPriority").InnerText;
                                valu = x.SelectSingleNode("TaskId").InnerText;
                            }
                    }
                }


                var gettasks = TestStorage.ReadXml<ObservableCollection<Task>>("Tasks.xml");
                var alltaskproject = from s in gettasks where s.ProjectId.Equals(proid) select s;
                var xc = gettasks.Select(f => f.ProjectId == proid);
                List<string> relatedtask = new List<string>();
                relatedtask.Add("No Selection");
                foreach (var q in gettasks)
                {
                    if (q.ProjectId == proid)
                    {
                        relatedtask.Add(q.TaskId);
                    }
                }
                relatedtasks.ItemsSource = relatedtask;
                // relatedtasks.SelectedItem = brg.TaskId;


                XmlDocument doc = new XmlDocument();
                doc.Load("Tester.xml");
                foreach (XmlNode node in doc.SelectNodes("ArrayOfTask/TasksDependency"))
                {
                    string rdependenttaskidxml = node.SelectSingleNode("DependentTaskID").InnerText;
                    string rselecttaskidxml = node.SelectSingleNode("TaskId").InnerText;
                    if (rselecttaskidxml == valu & rdependenttaskidxml != "")
                    {
                        relatedtasks.SelectedItem = node.SelectSingleNode("DependentTaskID").InnerText;
                    }

                }

            }
        }

        // Delete Task
        private void Btn_deletetaskd_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Tasks.xml");
            foreach (XmlNode x in doc.SelectNodes("ArrayOfTask/Task"))
                if (x.SelectSingleNode("TaskId").InnerText == updatetaskid.Text)
                {
                    x.ParentNode.RemoveChild(x);
                    doc.Save("Tasks.xml");
                }
            MessageBox.Show("Deleted!!!!!");

            XmlDocument docu = new XmlDocument();
            docu.Load("Tester.xml");
            foreach (XmlNode x in docu.SelectNodes("ArrayOfTasksDependency/TasksDependency"))
                if (x.SelectSingleNode("TaskId").InnerText == updatetaskid.Text)
                {
                    x.ParentNode.RemoveChild(x);
                    doc.Save("Tester.xml");
                }
            var gotokanbanboard = new Kanbanboard(id);
            gotokanbanboard.Show();
            this.Close();
        }

        //Update task
        private void Btn_updatetaskd_Click(object sender, RoutedEventArgs e)
        {
            // to get and the task status from the combobox to check work in progress condition
            var tsk = TestStorage.ReadXml<ObservableCollection<Task>>("Tasks.xml");
            var tssk = new ObservableCollection<Task>();
            var br = tsk.First(f => f.TaskId == updatetaskid.Text);
            br.TaskStatus = taskstatus.SelectionBoxItem.ToString();

            // to get the value of work in progress for the project.
            var project = TestStorage.ReadXml<ObservableCollection<Project>>("Projects.xml");
            var proj = new ObservableCollection<Project>();
            var pr = project.First(f => f.ProjectId == id);
            string wipcount = pr.WorkInProgressLimit;
            int wipCount = Convert.ToInt32(wipcount);
           // MessageBox.Show(wipcount);

            // to get the number of tasks which have number of taskstatus as work in progress
            XmlDocument docu = new XmlDocument();
            docu.Load("Tasks.xml");
            int count = 0;

            string selectval = relatedtasks.SelectedItem.ToString();
            foreach (XmlNode x in docu.SelectNodes("ArrayOfTask/Task"))
            {
                string taskstat = x.SelectSingleNode("TaskStatus").InnerText;
                string prid = x.SelectSingleNode("ProjectId").InnerText;
                string tsid = x.SelectSingleNode("TaskId").InnerText;

                if (taskstat == "workinprogress" && prid == id)
                {
                    count = count + 1;
                }

                if (selectval == tsid)
                {
                    selectedtaskstatus = x.SelectSingleNode("TaskStatus").InnerText;
                }
            }
            string value = Convert.ToString(count);
           // MessageBox.Show(value);

            if (relatedtasks.SelectedItem.ToString() != "No Selection" & (br.TaskStatus == "done" || br.TaskStatus == "workinprogress") & selectedtaskstatus != "done")
            {
                
                    string selecttask = relatedtasks.SelectedItem.ToString();
                    MessageBox.Show("Sorry task is dependent on Task " + selecttask + " Complete it inorder to update");
        

            }
            else
            if (wipCount == count & br.TaskStatus != "done")
            {
                MessageBox.Show("Oooopss you have reached to the limit No. of Tasks as Work in progress first complete other Task and then add more task in Progress");
            }
            else
            {
                var tak = TestStorage.ReadXml<ObservableCollection<Task>>("Tasks.xml");
                var task = new ObservableCollection<Task>();
                var ps = tak.First(f => f.TaskId == updatetaskid.Text);
                ps.TaskTitle = dtaskTitle.Text;
                ps.TaskDescription = dtaskDescription.Text;
                ps.TaskPriority = taskprioritys.SelectionBoxItem.ToString();
                ps.TaskNotes = dtaskNote.Text;
                ps.TaskStatus = taskstatus.SelectionBoxItem.ToString();

                if (string.IsNullOrEmpty(dtaskTitle.Text) || string.IsNullOrEmpty(dtaskDescription.Text) || string.IsNullOrEmpty(dtaskNote.Text))
                {
                    MessageBox.Show("Please enter all the values");
                }
                else
                {
                    TestStorage.WriteXml<ObservableCollection<Task>>(tak, "Tasks.xml");
                    var gotokanbanboard = new Kanbanboard(id);
                    gotokanbanboard.Show();
                    this.Close();

                }
            }

        }

        private void Btn_Canceld_Click(object sender, RoutedEventArgs e)
        {
            var gotokanbanboard = new Kanbanboard(id);
            gotokanbanboard.Show();
            this.Close();
        }


        private void Relatedtasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string dependenttaskidxml = "";
            string selecttaskidxml = "";

            // taskid of dependent task
            string dependentid = updatetaskid.Text;

            // reading the tester Xml for Dependency logic
            XmlDocument doc = new XmlDocument();
            doc.Load("Tester.xml");
            foreach (XmlNode node in doc.SelectNodes("ArrayOfTask/TasksDependency"))
            {
                // to get the selected item value from combobox
                string selectedtask = relatedtasks.SelectedItem.ToString();
                // to get the value of DependentTaskID element 
                dependenttaskidxml = node.SelectSingleNode("DependentTaskID").InnerText;
                // to get the value of TaskId element 
                selecttaskidxml = node.SelectSingleNode("TaskId").InnerText;

                // condition for self dependency
                if (dependentid == selectedtask)
                {
                    MessageBox.Show("You can not add task self dependent");
                    return;
                }
                // condition for add of dependency
                else if (dependentid == selecttaskidxml & dependenttaskidxml == "No Selection")
                {
                    MessageBoxResult result = System.Windows.MessageBox.Show("Add the task as Dependent task", "Add Task Dependency", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            var dooc = XDocument.Load("Tester.xml");
                            var tasnode = dooc.Descendants("TasksDependency").FirstOrDefault(tasksdependency => tasksdependency.Element("TaskId").Value == dependentid);
                            tasnode.SetElementValue("DependentTaskID", selectedtask);
                            //MessageBox.Show(node.ToString());
                            dooc.Save("Tester.xml");
                            MessageBox.Show("Task Added Successfully", "Add Task Dependency");
                            break;

                        case MessageBoxResult.No:
                            break;
                    }
                }
                // condition for delete dependency
                else if (dependentid == selecttaskidxml & dependenttaskidxml != "No Selection")
                {
                    MessageBoxResult result = System.Windows.MessageBox.Show("Delete the Dependent task", "Delete Task Dependency", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            var dooc = XDocument.Load("Tester.xml");
                            var tasnode = dooc.Descendants("TasksDependency").FirstOrDefault(tasksdependency => tasksdependency.Element("TaskId").Value == dependentid);
                            tasnode.SetElementValue("DependentTaskID", "No Selection");
                            // MessageBox.Show(node.ToString());
                            dooc.Save("Tester.xml");
                            MessageBox.Show("Task Dependency Deleted Successfully", "Add Task Dependency");
                            break;

                        case MessageBoxResult.No:
                            break;
                    }

                }
            }

        }
    }
}


