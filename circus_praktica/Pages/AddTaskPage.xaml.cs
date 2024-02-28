using System;
using System.Collections.Generic;
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
using circus_praktica.DBConnection;

namespace circus_praktica.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddTaskPage.xaml
    /// </summary>
    public partial class AddTaskPage : Page
    {
        public static List<Admin> admins { get; set; }
        public static Admin loggedUser;
        public static List<Worker> workers {  get; set; }
        public static List<DBConnection.Task> tasks { get; set; }
        public static DBConnection.Task task = new DBConnection.Task();

        
        public AddTaskPage()
        {
            InitializeComponent();
            admins = new List<Admin>(dbconnection.Circus.Admin.ToList());
            loggedUser = dbconnection.loginedAdmin;
            workers = new List<Worker>(dbconnection.Circus.Worker.ToList());
            tasks = new List<DBConnection.Task>(dbconnection.Circus.Task.ToList());
            this.DataContext = this;
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var a = WorkerCB.SelectedItem as Worker;
                StringBuilder error = new StringBuilder();

                if (string.IsNullOrWhiteSpace(WorkerCB.Text) || string.IsNullOrWhiteSpace(DescripTB.Text))
                {
                    error.AppendLine("Заполните все поля!");
                }

                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    task.IDAdmin = loggedUser.IDAdmin;
                    task.IDWorker = a.IDWorker;
                    task.Description = DescripTB.Text.Trim();
                    task.Done = false;
                    task.Viewed = false;
                    dbconnection.Circus.Task.Add(task);
                    DBConnection.dbconnection.Circus.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Ой, какая-то ошибка");
            }
        }
    }
}
