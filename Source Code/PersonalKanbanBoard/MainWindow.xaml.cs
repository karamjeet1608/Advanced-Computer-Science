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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PersonalKanbanBoard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        // To fetch the list of projects from Projects.xml file on window load
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var projects = TestStorage.ReadXml<ObservableCollection<Project>>("Projects.xml");
            Projectlistview.ItemsSource = projects;
        }

        //redirects to create project page.
        private void Btn_createproject_Click(object sender, RoutedEventArgs e)
        {
            var gotocreateproject = new Createproject();
            gotocreateproject.Show();
            this.Close();
        }

        // fetches the Projectid of selected item from Projectlistview and pass it to kanbanboard class.
        private void Projectlistview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proj = new Project();
            proj = (Project)Projectlistview.SelectedItem;
            string id = proj.ProjectId;
            var gotokanbanboard = new Kanbanboard(id);
            gotokanbanboard.Show();
            this.Close();
        }

        //fetch the searched projected id and pass it to Project details classs
        private void Findproject_Click(object sender, RoutedEventArgs e)
        {
            string param = findprojectids.Text;
            int parsedValue;
            if (!int.TryParse(findprojectids.Text, out parsedValue))
            {
                MessageBox.Show("Please enter Project number");
                return;
            }
            else
            {
              var gotoprojectdetail = new Projectdetail(param);
              gotoprojectdetail.Show();
              this.Close();
            }
            
        }
    }
}

