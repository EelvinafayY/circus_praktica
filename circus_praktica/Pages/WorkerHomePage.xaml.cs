using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
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
    /// Логика взаимодействия для WorkerHomePage.xaml
    /// </summary>
    public partial class WorkerHomePage : Page
    {
        public static List<Admin> admins {  get; set; }
        public static List<Worker> workers { get; set; }
        public static List<DBConnection.Task> tasks { get; set; }

        public static Worker loggedUser;
        public WorkerHomePage()
        {
            InitializeComponent();
            admins = new List<Admin>(dbconnection.Circus.Admin.ToList());
            loggedUser = dbconnection.loginedStaff;
            workers = new List<Worker>(dbconnection.Circus.Worker.ToList());
            tasks = new List<DBConnection.Task>(dbconnection.Circus.Task.Where(x => x.IDWorker == loggedUser.IDWorker && x.Done != true).ToList());
            TaskLV.ItemsSource = tasks;
            this.DataContext = this;
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            var existingShedule = dbconnection.Circus.Task.FirstOrDefault(s => s.IDWorker == loggedUser.IDWorker);
            if (TaskLV.SelectedItems.Count > 0)
            {
                DataRowView row = TaskLV.SelectedItem as DataRowView; // Получаем выбранную строку как DataRowView

                if (row != null)
                {
                    string textFromColumn2 = row["Комментарий"].ToString(); // Получаем значение из столбца "Column2"

                    // Далее вы можете использовать textFromColumn2 в вашем коде
                    existingShedule.Comment = textFromColumn2;
                    DBConnection.dbconnection.Circus.SaveChanges();
                }
                
            }

            existingShedule.Done = true;



            DBConnection.dbconnection.Circus.SaveChanges();
            NavigationService.Navigate(new WorkerHomePage());
        }


    }
}
