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
    /// Interaction logic for Projectdetail.xaml
    /// </summary>
    public partial class Projectdetail : Window
    {
        public string projectdetailid;

        public Projectdetail(string param)
        { 
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            //fetch the project details from Projects.xml and display it on Projectdetail page.
            projectdetailid = param;
            var projectdata = TestStorage.ReadXml<ObservableCollection<Project>>("Projects.xml");
            var projectdetail = from s in projectdata where s.ProjectId.Equals(projectdetailid) select s;

            projectdetailsstk.DataContext = projectdetail;

        }

        // update projectdetails
        private void Btn_updateproject_Click(object sender, RoutedEventArgs e)
        {
            int parsedValue;
            var pro = TestStorage.ReadXml<ObservableCollection<Project>>("Projects.xml");
            var project = new ObservableCollection<Project>();
            //Project ps = new Project();
            var ps = pro.First(f => f.ProjectId == getprojectid.Text);
            ps.ProjectTitle = projectTitle.Text;
            ps.ProjectTitle = projectTitle.Text;
            ps.ProjectDescription = projectDescription.Text;
            ps.StartDate = startDate.Text;
            ps.EndDate = endDate.Text;
            ps.ToDoLimit = toDoLimit.Text;
            ps.WorkInProgressLimit = workInProgressLimit.Text;
            ps.DoneLimit = doneLimit.Text;
            if (string.IsNullOrEmpty(projectTitle.Text) || string.IsNullOrEmpty(projectDescription.Text) || string.IsNullOrEmpty(startDate.Text) || string.IsNullOrEmpty(endDate.Text) || string.IsNullOrEmpty(toDoLimit.Text) || string.IsNullOrEmpty(workInProgressLimit.Text) || string.IsNullOrEmpty(doneLimit.Text))
            {
                MessageBox.Show("Please enter all the values ");
            }
            else if (!int.TryParse(toDoLimit.Text, out parsedValue))
            {
                MessageBox.Show("Please enter numeric value in set to do limit field ");
                return;
            }
            else if (!int.TryParse(workInProgressLimit.Text, out parsedValue))
            {
                MessageBox.Show("Please enter numeric value in work set in progress limit field ");
                return;
            }
            else if (!int.TryParse(doneLimit.Text, out parsedValue))
            {
                MessageBox.Show("Please enter numeric value set in done limit field ");
                return;
            }
            else
           
            {
                TestStorage.WriteXml<ObservableCollection<Project>>(pro, "Projects.xml");
                successMsg.Visibility = Visibility.Visible;
                var gotomainwindow = new MainWindow();
                gotomainwindow.Show();
                this.Close();
            }
            
        }
        // redirect to ProjectBoard
        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            var gotomainwindow = new MainWindow();
            gotomainwindow.Show();
            this.Close();
        }

        // delete project
        private void Btn_deleteproject_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Projects.xml");
            foreach (XmlNode x in doc.SelectNodes("ArrayOfProject/Project"))
                if (x.SelectSingleNode("ProjectId").InnerText == getprojectid.Text)
                {
                   x.ParentNode.RemoveChild(x);
                    doc.Save("Projects.xml");
                }
            MessageBox.Show("Deleted!!!!!");

            var gotomainwindow = new MainWindow();
            gotomainwindow.Show();
            this.Close();
        }   
    }
}
