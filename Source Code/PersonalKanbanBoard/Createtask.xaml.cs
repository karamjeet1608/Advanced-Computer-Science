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
    /// Interaction logic for Createtask.xaml
    /// </summary>
    public partial class Createtask : Window
    {
        public string taskprojectid;
        private string id;
        public string tasid = "";

        public Createtask(string proid)
        {
            id = proid;
            taskprojectid = proid;
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

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
            relatedtasks.SelectedItem = "No Selection";
            relatedtasks.ItemsSource = relatedtask;
        }

        private void Btn_createtask_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Tasks.xml");
            XmlNode task = doc.CreateElement("Task");
            int count = 0;
            foreach (XmlNode xn in doc.SelectNodes("ArrayOfTask/Task"))
            {
                count = count + 1;

            }
            int Count = count + 1;
            try
            {
                //Projectid
                XmlNode ProjectId = doc.CreateElement("ProjectId");
                ProjectId.InnerText = taskprojectid;
                task.AppendChild(ProjectId);

                //TaskId

                tasid = Convert.ToString(Count);

                XmlNode TaskId = doc.CreateElement("TaskId");
                TaskId.InnerText = tasid;
                task.AppendChild(TaskId);
                //TaskTitle
                XmlNode TaskTitle = doc.CreateElement("TaskTitle");
                TaskTitle.InnerText = taskTitle.Text;
                task.AppendChild(TaskTitle);
                // project description
                XmlNode TaskDescription = doc.CreateElement("TaskDescription");
                TaskDescription.InnerText = taskDescription.Text;
                task.AppendChild(TaskDescription);
                // startDate
                XmlNode TaskPriority = doc.CreateElement("TaskPriority");
                TaskPriority.InnerText = taskPriority.SelectionBoxItem.ToString();
                task.AppendChild(TaskPriority);
                // end date
                XmlNode TaskNotes = doc.CreateElement("TaskNotes");
                TaskNotes.InnerText = taskNotes.Text;
                task.AppendChild(TaskNotes);
                //ToDoLimit
                XmlNode TaskStatus = doc.CreateElement("TaskStatus");
                TaskStatus.InnerText = taskStatus.SelectionBoxItem.ToString();
                task.AppendChild(TaskStatus);
                doc.DocumentElement.AppendChild(task);


                if (string.IsNullOrEmpty(taskTitle.Text) || string.IsNullOrEmpty(taskDescription.Text) || string.IsNullOrEmpty(taskNotes.Text))
                {
                    MessageBox.Show("Please enter all the values");
                }

                else
                {


                    XmlDocument xddoc = new XmlDocument();
                    xddoc.Load("Tester.xml");
                    XmlNode tasksdependency = xddoc.CreateElement("TasksDependency");
                    XmlNode taskid = xddoc.CreateElement("TaskId");
                    XmlNode dependentaskid = xddoc.CreateElement("DependentTaskID");
                    taskid.InnerText = tasid;
                    dependentaskid.InnerText = relatedtasks.SelectedItem.ToString();
                    tasksdependency.AppendChild(taskid);
                    tasksdependency.AppendChild(dependentaskid);

                    successMsg.Visibility = Visibility.Visible;
                    xddoc.DocumentElement.AppendChild(tasksdependency);
                    xddoc.Save("Tester.xml");
                    doc.Save("Tasks.xml");

                    var gotokanbanboard = new Kanbanboard(id);
                    gotokanbanboard.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            var gotokanbanboard = new Kanbanboard(id);
            gotokanbanboard.Show();
            this.Close();
        }

        private void Dependenttaskview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //        // get selected task id from the dependenttaskview 
            //        var selectedtask = new Task();
            //        selectedtask = (Task)dependenttaskview.SelectedItem;
            //        string Selectedtaskid = selectedtask.TaskId;

            //        // taskid of dependent task
            //        //string dependentid = updatetaskid.Text;

            //        // to check the condition 
            //        XmlDocument doc = new XmlDocument();
            //        doc.Load("Tester.xml");
            //        foreach (XmlNode node in doc.SelectNodes("ArrayOfTask/TasksDependency"))
            //        {
            //            string dependenttaskid = node.SelectSingleNode("DependentTaskID").InnerText;
            //            string selecttaskid = node.SelectSingleNode("TaskId").InnerText;

            //            if (dependentid == selecttaskid & dependenttaskid == "")
            //            {
            //                MessageBoxResult result = System.Windows.MessageBox.Show("Add the task as Dependent task", "Add Task Dependency", MessageBoxButton.YesNo);
            //                switch (result)
            //                {
            //                    case MessageBoxResult.Yes:
            //                        var dooc = XDocument.Load("Tester.xml");
            //                        var tasnode = dooc.Descendants("TasksDependency").FirstOrDefault(tasksdependency => tasksdependency.Element("TaskId").Value == dependentid);
            //                        tasnode.SetElementValue("DependentTaskID", Selectedtaskid);
            //                        MessageBox.Show(node.ToString());
            //                        dooc.Save("Tester.xml");
            //                        MessageBox.Show("Task Added Successfully", "Add Task Dependency");
            //                        break;

            //                    case MessageBoxResult.No:
            //                        break;
            //                }

            //            }
            //            else
            //                if (dependentid == selecttaskid & dependenttaskid != "")
            //            {
            //                MessageBoxResult result = System.Windows.MessageBox.Show("Delete the Dependent task", "Delete Task Dependency", MessageBoxButton.YesNo);
            //                switch (result)
            //                {
            //                    case MessageBoxResult.Yes:
            //                        var dooc = XDocument.Load("Tester.xml");
            //                        var tasnode = dooc.Descendants("TasksDependency").FirstOrDefault(tasksdependency => tasksdependency.Element("TaskId").Value == dependentid);
            //                        tasnode.SetElementValue("DependentTaskID", "");
            //                        MessageBox.Show(node.ToString());
            //                        dooc.Save("Tester.xml");
            //                        MessageBox.Show("Task Dependency Deleted Successfully", "Add Task Dependency");
            //                        break;

            //                    case MessageBoxResult.No:
            //                        break;
            //                }

            //            }

            //      }

        }

        private void Relatedtasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string dependenttaskidxml = "";
            string selecttaskidxml = "";

            // taskid of dependent task
            string dependentid = tasid;

            XmlDocument doc = new XmlDocument();
            doc.Load("Tester.xml");
            foreach (XmlNode node in doc.SelectNodes("ArrayOfTask/TasksDependency"))
            {
                string selectedtask = relatedtasks.SelectedItem.ToString();
                string Selectedtaskid = selectedtask;
                dependenttaskidxml = node.SelectSingleNode("DependentTaskID").InnerText;
                selecttaskidxml = node.SelectSingleNode("TaskId").InnerText;
                if (dependentid == selecttaskidxml & dependenttaskidxml == "No Selection")
                {
                    MessageBoxResult result = System.Windows.MessageBox.Show("Add the task as Dependent task", "Add Task Dependency", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            var dooc = XDocument.Load("Tester.xml");
                            var tasnode = dooc.Descendants("TasksDependency").FirstOrDefault(tasksdependency => tasksdependency.Element("TaskId").Value == dependentid);
                            tasnode.SetElementValue("DependentTaskID", Selectedtaskid);
                            //MessageBox.Show(node.ToString());
                            dooc.Save("Tester.xml");
                            MessageBox.Show("Task Added Successfully", "Add Task Dependency");
                            break;

                        case MessageBoxResult.No:
                            break;
                    }
                }
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


    

