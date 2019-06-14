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
    /// Interaction logic for Createproject.xaml
    /// </summary>
    public partial class Createproject : Window
    {
        public Createproject()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Btn_createProject_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                int parsedValue;
                var pro = TestStorage.ReadXml<ObservableCollection<Project>>("Projects.xml");
                var project = new ObservableCollection<Project>();
                Project ps = new Project();
                XmlDocument doc = new XmlDocument();
                doc.Load("Projects.xml");
                int count = 1;
                foreach (XmlNode xn in doc.SelectNodes("ArrayOfProject/Project"))
                {
                    count = count + 1;
                }
                string projectID = Convert.ToString(count);
                ps.ProjectId = projectID;
                ps.ProjectTitle = projectTitle.Text;
                ps.ProjectDescription = projectDescription.Text;
                ps.StartDate = startDate.Text;
                ps.EndDate = endDate.Text;
                ps.ToDoLimit = toDoLimit.Text;
                ps.WorkInProgressLimit = workInProgressLimit.Text;
                ps.DoneLimit = doneLimit.Text;

                if (string.IsNullOrEmpty(projectTitle.Text) || string.IsNullOrEmpty(projectDescription.Text) || string.IsNullOrEmpty(startDate.Text) || string.IsNullOrEmpty(endDate.Text) || string.IsNullOrEmpty(toDoLimit.Text) || string.IsNullOrEmpty(workInProgressLimit.Text) || string.IsNullOrEmpty(doneLimit.Text))
                {
                    MessageBox.Show("Please enter all the values");
                }
                
                else  if (!int.TryParse(toDoLimit.Text, out parsedValue))
                    {
                        MessageBox.Show("Please enter numeric value in set to do limit field ");
                        return;
                    }
                else if (!int.TryParse(workInProgressLimit.Text, out parsedValue))
                {
                    MessageBox.Show("Please enter numeric value in set work in progress limit field ");
                    return;
                }
                else if (!int.TryParse(doneLimit.Text, out parsedValue))
                {
                    MessageBox.Show("Please enter numeric value in set done limit field ");
                    return;
                }
                else
                {
                    pro.Add(ps);
                    TestStorage.WriteXml<ObservableCollection<Project>>(pro, "Projects.xml");
                    var gobacktomain = new MainWindow();
                    gobacktomain.Show();
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
            var gobacktomain = new MainWindow();
            gobacktomain.Show();
            this.Close();
        }

    }
}
