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
    /// Логика взаимодействия для AddShedulePage.xaml
    /// </summary>
    public partial class AddShedulePage : Page
    {
        public static List<Artist> artists {  get; set; }
        public static List<Perfomance> perfomances { get; set; }
        public static List<SheduleArtist> shedules { get; set; }
        public static SheduleArtist shedule = new SheduleArtist();
        public AddShedulePage()
        {
            InitializeComponent();
            artists = new List<Artist>(dbconnection.Circus.Artist.ToList());
            perfomances = new List<Perfomance>(dbconnection.Circus.Perfomance.ToList());
            shedules = new List<SheduleArtist>(dbconnection.Circus.SheduleArtist.ToList());
            this.DataContext = this;
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var a = ArtistCB.SelectedItem as Artist;
                var b = PerfomanceCB.SelectedItem as Perfomance;
                StringBuilder error = new StringBuilder();

                if (string.IsNullOrWhiteSpace(ArtistCB.Text) || string.IsNullOrWhiteSpace(PerfomanceCB.Text) || string.IsNullOrWhiteSpace(DateDP.Text) || string.IsNullOrWhiteSpace(TimeTB.Text))
                {
                    error.AppendLine("Заполните все поля!");
                }

                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    DateTime d = (DateTime)DateDP.SelectedDate;
                    int hour = int.Parse(TimeTB.Text.Split(':')[0]);
                    int minute = int.Parse(TimeTB.Text.Split(':')[1]);
                    DateTime dateTime = new DateTime(d.Year, d.Month, d.Day, hour, minute, 0);
                    shedule.Date = dateTime;
                    shedule.IDArtist = a.IDArtist;
                    shedule.IDPerfomance = b.IDPerfomance;
                    dbconnection.Circus.SheduleArtist.Add(shedule);
                    DBConnection.dbconnection.Circus.SaveChanges();
                    NavigationService.Navigate(new ShedulePage());
                }

            }
            catch
            {
                MessageBox.Show("Ой, какая-то ошибка");
            }
        }
    }
}
