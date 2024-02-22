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
    /// Логика взаимодействия для AuhorizationPage.xaml
    /// </summary>
    public partial class AuhorizationPage : Page
    {
        public static List<Admins> admins { get; set; }
        public static List<Artist> artists { get; set; }
        public static List<Animal_trainer> trainers { get; set; }
        public static List<Staff> staffs { get; set; }
        public AuhorizationPage()
        {
            InitializeComponent();
        }

        private void VxodBT_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTB.Text.Trim();
            string password = PasswordPB.Password.Trim();


            admins = new List<Admins>(DBConnection.dbconnection.Circus.Admins.ToList());
            Admins currentAdmin = admins.FirstOrDefault(i => i.Login == login && i.Password == password);
            dbconnection.loginedAdmin = currentAdmin;

            artists = new List<Artist>(DBConnection.dbconnection.Circus.Artist.ToList());
            Artist currentArtist = artists.FirstOrDefault(i => i.Login == login && i.Password == password);
            dbconnection.loginedArtist = currentArtist;

            trainers = new List<Animal_trainer>(DBConnection.dbconnection.Circus.Animal_trainer.ToList());
            Animal_trainer currentTrainer = trainers.FirstOrDefault(i => i.Login == login && i.Password == password);
            dbconnection.loginedAnimal_trainer = currentTrainer;

            staffs = new List<Staff>(DBConnection.dbconnection.Circus.Staff.ToList());
            Staff currentStaff = staffs.FirstOrDefault(i => i.Login == login && i.Password == password);
            dbconnection.loginedStaff = currentStaff;
            if (currentAdmin != null)
            {
                NavigationService.Navigate(new AdminHomePage());
            }
            if (currentArtist != null)
            {

            }
            if (currentTrainer != null)
            {

            }
            if (currentStaff != null)
            {

            }
            if(currentAdmin == null && currentArtist == null && currentTrainer == null && currentStaff == null )
            {
                MessageBox.Show("Такого пользователя не существует(((");
            }
        }
    }
}
