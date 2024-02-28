using circus_praktica.DBConnection;
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

namespace circus_praktica.Pages
{
    /// <summary>
    /// Логика взаимодействия для ViewAppPage.xaml
    /// </summary>
    public partial class ViewAppPage : Page
    {
        public static List<Admin> admins {  get; set; }
        public static List<Artist> artists { get; set; }
        public static List<DBConnection.Application> application { get; set; }

        public static Admin loggedUser;
        public ViewAppPage()
        {
            InitializeComponent();
            admins = new List<Admin>(dbconnection.Circus.Admin.ToList());
            artists = new List<Artist>(dbconnection.Circus.Artist.ToList());
            loggedUser = dbconnection.loginedAdmin;
            application = new List<DBConnection.Application>(dbconnection.Circus.Application.Where(x => x.IDAdmin == loggedUser.IDAdmin && x.Done != true).ToList());
            
            AppLV.ItemsSource = application; 
            this.DataContext = this;
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            var existingShedule = dbconnection.Circus.Application.FirstOrDefault(s => s.IDAdmin == loggedUser.IDAdmin);

            
            existingShedule.Done = true;

            DBConnection.dbconnection.Circus.SaveChanges();
            NavigationService.Navigate(new ViewAppPage());
        }



        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminHomePage());
        }
    }
}
