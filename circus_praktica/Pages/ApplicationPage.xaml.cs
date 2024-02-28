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
    /// Логика взаимодействия для ApplicationPage.xaml
    /// </summary>
    public partial class ApplicationPage : Page
    {
        public static List<Admin> admins { get; set; }
        public static Artist loggedUser;
        public static List<Artist> artists { get; set; }
        public static List<DBConnection.Application> applications { get; set; }
        public static DBConnection.Application app = new DBConnection.Application();
        public ApplicationPage()
        {
            InitializeComponent();
            admins = new List<Admin>(dbconnection.Circus.Admin.ToList());
            loggedUser = dbconnection.loginedArtist;
            artists = new List<Artist>(dbconnection.Circus.Artist.ToList());
            applications = new List<DBConnection.Application>(dbconnection.Circus.Application.ToList());
            this.DataContext = this;
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var a = AdminCB.SelectedItem as Admin;
                StringBuilder error = new StringBuilder();

                if (string.IsNullOrWhiteSpace(AdminCB.Text) || string.IsNullOrWhiteSpace(DescripTB.Text))
                {
                    error.AppendLine("Заполните все поля!");
                }

                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    app.IDArtist = loggedUser.IDArtist;
                    app.IDAdmin = a.IDAdmin;
                    app.Description = DescripTB.Text.Trim();
                    app.Done = false;
                    dbconnection.Circus.Application.Add(app);
                    DBConnection.dbconnection.Circus.SaveChanges();
                    NavigationService.GoBack();
                }
            }
            catch
            {
                MessageBox.Show("Ой, какая-то ошибка");
            }
        }
    }
}
