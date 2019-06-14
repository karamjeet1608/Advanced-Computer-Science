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

namespace PersonalKanbanBoard
{
    /// <summary>
    /// Interaction logic for Kanbanboard.xaml
    /// </summary>
    public partial class Kanbanboard : Window
    {
        public string tasinprogressid;
        public string tastodoid;
        public string tasdoneid;
        public string proid;

        public Kanbanboard(string id)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            proid = id;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var projects = TestStorage.ReadXml<ObservableCollection<Project>>("Projects.xml");
            var projectdetails = from s in projects where s.ProjectId.Equals(proid) select s;

            {

                prodetail.DataContext = projectdetails;


            }

            {
                var tasks = TestStorage.ReadXml<ObservableCollection<Task>>("Tasks.xml");
                if (tasks != null)
                {

                    var todo = from s in tasks where s.ProjectId.Equals(proid) && s.TaskStatus.Contains("todo") select s;

                    {

                        taskstodo.ItemsSource = todo;

                       
                    }
                }
                {
                    var inprogress = from s in tasks where s.ProjectId.Equals(proid) && s.TaskStatus.Contains("workinprogress") select s;

                    {

                        tasksinprogress.ItemsSource = inprogress;
                    }
                }

                {
                    var done = from s in tasks where s.ProjectId.Equals(proid) && s.TaskStatus.Contains("done") select s;

                    {

                        tasksdone.ItemsSource = done;
                    }
                }

            }
        }

        private void Taskstodo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tastodo = new Task();
            tastodo = (Task)taskstodo.SelectedItem;
            string tastodoid = tastodo.TaskId;
            string tastodostatus = tastodo.TaskStatus;
           // MessageBox.Show(tastodoid, tastodostatus);

            var gototaskdetails = new Taskdetail(tastodoid, tasinprogressid, tasdoneid, proid);
            gototaskdetails.Show();
            this.Close();
        }

        private void Tasksinprogress_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tasinprogress = new Task();
            tasinprogress = (Task)tasksinprogress.SelectedItem;
            string tasinprogressid = tasinprogress.TaskId;
            string tasinprogressstatus = tasinprogress.TaskStatus;
           // MessageBox.Show(tasdoneid, tasinprogressstatus);

            var gototaskdetails = new Taskdetail(tastodoid, tasinprogressid, tasdoneid,proid);
            gototaskdetails.Show();
            this.Close();
        }

        private void Tasksdone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tasdone = new Task();
            tasdone = (Task)tasksdone.SelectedItem;
            string tasdoneid = tasdone.TaskId;
            string tasdonestatus = tasdone.TaskStatus;
            //MessageBox.Show(tasdoneid, tasdonestatus);

            var gototaskdetails = new Taskdetail(tastodoid, tasinprogressid, tasdoneid, proid);
            gototaskdetails.Show();
            this.Close();
        }

        private void createtask_Click(object sender, RoutedEventArgs e)
        { 
             var project = TestStorage.ReadXml<ObservableCollection<Project>>("Projects.xml");
            var proj = new ObservableCollection<Project>();
            var pr = project.First(f => f.ProjectId == proid);
            string todocount = pr.ToDoLimit;
            int todoCount = Convert.ToInt32(todocount);
          //  MessageBox.Show(todocount);

            XmlDocument docu = new XmlDocument();
            docu.Load("Tasks.xml");
            int count = 0;
            foreach (XmlNode x in docu.SelectNodes("ArrayOfTask/Task"))
            {
                string taskstat = x.SelectSingleNode("TaskStatus").InnerText;
                string prid = x.SelectSingleNode("ProjectId").InnerText;

                if (taskstat == "todo" && prid == proid)
                {
                    count = count + 1;
                }
            }

            string value = Convert.ToString(count);
          //  MessageBox.Show(value);
            if (todoCount == count )
            {
                MessageBox.Show("Oooopss you have reached to the limit of Todo  first complete the Task and then add more task");
            }
            else
            {
                var gotocreatetask = new Createtask(proid);
                gotocreatetask.Show();
                this.Close();
            }

            
        }

        private void GotoProjectboard_Click(object sender, RoutedEventArgs e)
        {
            var gotoprojectboard = new MainWindow();
            gotoprojectboard.Show();
            this.Close();
        }
    }
}
