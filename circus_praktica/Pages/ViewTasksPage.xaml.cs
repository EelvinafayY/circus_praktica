using circus_praktica.DBConnection;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace circus_praktica.Pages
{
    /// <summary>
    /// Логика взаимодействия для ViewTasksPage.xaml
    /// </summary>
    public partial class ViewTasksPage : Page
    {
        public static List<Admin> admins { get; set; }
        public static List<Worker> workers { get; set; }
        public static List<DBConnection.Task> tasks { get; set; }

        public static Admin loggedUser;
        public ViewTasksPage()
        {
            InitializeComponent();
            admins = new List<Admin>(dbconnection.Circus.Admin.ToList());
            loggedUser = dbconnection.loginedAdmin;
            workers = new List<Worker>(dbconnection.Circus.Worker.ToList());
            tasks = new List<DBConnection.Task>(dbconnection.Circus.Task.Where(x => x.IDAdmin == loggedUser.IDAdmin && x.Viewed != true).ToList());
            this.DataContext = this;
            TaskLV.ItemsSource = tasks;
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            var existingShedule = dbconnection.Circus.Task.FirstOrDefault(s => s.IDAdmin == loggedUser.IDAdmin);
            if (TaskLV.SelectedItems.Count > 0)
            {
                DataRowView row = TaskLV.SelectedItem as DataRowView; // Получаем выбранную строку как DataRowView

                if (row != null)
                {
                    
                    existingShedule.Viewed = true;
                    DBConnection.dbconnection.Circus.SaveChanges();
                }

            }

            DBConnection.dbconnection.Circus.SaveChanges();
            NavigationService.Navigate(new ViewTasksPage());
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminHomePage());
        }
    }
}
