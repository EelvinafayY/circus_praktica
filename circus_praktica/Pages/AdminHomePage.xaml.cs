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
    /// Логика взаимодействия для AdminHomePage.xaml
    /// </summary>
    public partial class AdminHomePage : Page
    {
        public static Admin loggedAdmin;
        public AdminHomePage()
        {
            InitializeComponent();
            loggedAdmin = dbconnection.loginedAdmin;
            this.DataContext = this;
        }

        private void RegBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegPage());
        }

        private void AddAnimalBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddAnimalPage());
        }
    }
}
