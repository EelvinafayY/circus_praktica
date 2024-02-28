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
    /// Логика взаимодействия для ArtistHomePage.xaml
    /// </summary>
    public partial class ArtistHomePage : Page
    {
        public static List<SheduleArtist> shedules { get; set; }
        public static List<Artist> artists { get; set; }
        public static List<Perfomance> perfomances { get; set; }
        Artist contextartist;
        public ArtistHomePage(Artist artist)
        {
            InitializeComponent();
            artists = new List<Artist>(dbconnection.Circus.Artist.ToList());
            perfomances = new List<Perfomance>(dbconnection.Circus.Perfomance.ToList());
            shedules = new List<SheduleArtist>(dbconnection.Circus.SheduleArtist.Where(x => x.IDArtist == artist.IDArtist).ToList());
            contextartist = artist;
            SheduleLV.ItemsSource = shedules;
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ApplicationPage());
        }
    }
}
