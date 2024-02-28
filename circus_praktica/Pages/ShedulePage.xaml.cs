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
    /// Логика взаимодействия для ShedulePage.xaml
    /// </summary>
    public partial class ShedulePage : Page
    {
        public static List<SheduleArtist> shedules {  get; set; }
        public static List<Artist> artists { get; set; }
        public static List<Perfomance> perfomances { get; set; }

        public ShedulePage()
        {
            InitializeComponent();
            artists = new List<Artist>(dbconnection.Circus.Artist.ToList());
            perfomances = new List<Perfomance>(dbconnection.Circus.Perfomance.ToList());
            shedules = new List<SheduleArtist>(dbconnection.Circus.SheduleArtist.ToList());
            SheduleLV.ItemsSource = shedules;
            this.DataContext = this;
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddShedulePage());
        }

        private void ArtistCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = ArtistCB.SelectedItem as Artist;
            SheduleLV.ItemsSource = new List<SheduleArtist>(dbconnection.Circus.SheduleArtist.Where(x => x.IDArtist == a.IDArtist).ToList());
        }

        private void SheduleLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SheduleLV.SelectedItem is SheduleArtist shedule)
            {
                SheduleLV.SelectedItem = null;
                NavigationService.Navigate(new EditSheduleArtistPage(shedule));
            }
        }
    }
}
