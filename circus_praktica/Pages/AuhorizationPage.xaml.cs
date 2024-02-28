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
        public static List<Admin> Admin { get; set; }
        public static List<Artist> artists { get; set; }
        public static List<AnimalTrainer> trainers { get; set; }
        public static List<Worker> Workers { get; set; }
        public AuhorizationPage()
        {
            InitializeComponent();
        }

        private void VxodBT_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTB.Text.Trim();
            string password = PasswordPB.Password.Trim();


            Admin = new List<Admin>(DBConnection.dbconnection.Circus.Admin.ToList());
            Admin currentAdmin = Admin.FirstOrDefault(i => i.Login == login && i.Password == password);
            dbconnection.loginedAdmin = currentAdmin;

            artists = new List<Artist>(DBConnection.dbconnection.Circus.Artist.ToList());
            Artist currentArtist = artists.FirstOrDefault(i => i.Login == login && i.Password == password);
            dbconnection.loginedArtist = currentArtist;

            trainers = new List<AnimalTrainer>(DBConnection.dbconnection.Circus.AnimalTrainer.ToList());
            AnimalTrainer currentTrainer = trainers.FirstOrDefault(i => i.Login == login && i.Password == password);
            dbconnection.loginedAnimal_trainer = currentTrainer;

            Workers = new List<Worker>(DBConnection.dbconnection.Circus.Worker.ToList());
            Worker currentWorker = Workers.FirstOrDefault(i => i.Login == login && i.Password == password);
            dbconnection.loginedStaff = currentWorker;
            if (currentAdmin != null)
            {
                NavigationService.Navigate(new AdminHomePage());
            }
            if (currentArtist != null)
            {
                NavigationService.Navigate(new ArtistHomePage(currentArtist));
            }
            if (currentTrainer != null)
            {

            }
            if (currentWorker != null)
            {
                NavigationService.Navigate(new WorkerHomePage());
            }
            if(currentAdmin == null && currentArtist == null && currentTrainer == null && currentWorker == null )
            {
                MessageBox.Show("Такого пользователя не существует(((");
            }
        }
    }
}
