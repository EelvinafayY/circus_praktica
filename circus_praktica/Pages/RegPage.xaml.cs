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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public static List<Gender> genders { get; set; }
        public static List<Admins> admins { get; set; }
        public static List<Artist> artists { get; set; }
        public static List<Animal_trainer> trainers { get; set; }
        public static List<Staff> staffs { get; set; }
        public static Admins adm = new Admins();
        public static Artist art = new Artist();
        public static Animal_trainer trainer = new Animal_trainer();
        public static Staff st = new Staff();
        public RegPage()
        {
            InitializeComponent();
            genders = new List<Gender>(dbconnection.Circus.Gender.ToList());
            this.DataContext = this;
            GenderCB.ItemsSource = dbconnection.Circus.Gender.ToList();
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            var a = RoleCB.SelectedItem as Role;
            var b = GenderCB.SelectedItem as Gender;
            if(RoleCB.Text == "Администратор")
            {
                adm.Surname = SurnameTB.Text.Trim();
                adm.Name = NameTB.Text.Trim();
                adm.Patronymic = PatronymicTB.Text.Trim();
                adm.BDay = BDayDP.SelectedDate;
                adm.Id_Gender = b.Id_Gender;
                adm.Id_Role = a.Id_Role;
                adm.Login = LoginTB.Text.Trim();
                adm.Password = PasswordTB.Text.Trim();
                dbconnection.Circus.Admins.Add(adm);
            }
            if (RoleCB.Text == "Артист")
            {
                art.Surname = SurnameTB.Text.Trim();
                art.Name = NameTB.Text.Trim();
                art.Patronymic = PatronymicTB.Text.Trim();
                art.Id_Gender = b.Id_Gender;
                art.Id_Role = a.Id_Role;
                art.Login = LoginTB.Text.Trim();
                art.Password = PasswordTB.Text.Trim();
                dbconnection.Circus.Artist.Add(art);
            }
            if (RoleCB.Text == "Тренер")
            {
                trainer.Surname = SurnameTB.Text.Trim();
                trainer.Name = NameTB.Text.Trim();
                trainer.Patronymic = PatronymicTB.Text.Trim();
                trainer.BDay = BDayDP.SelectedDate;
                trainer.Id_Gender = b.Id_Gender;
                trainer.Id_Role = a.Id_Role;
                trainer.Login = LoginTB.Text.Trim();
                trainer.Password = PasswordTB.Text.Trim();
                dbconnection.Circus.Animal_trainer.Add(trainer);
            }
            if (RoleCB.Text == "Обслуж. персонал")
            {
                st.Surname = SurnameTB.Text.Trim();
                st.Name = NameTB.Text.Trim();
                st.Patronymic = PatronymicTB.Text.Trim();
                st.BDay = BDayDP.SelectedDate;
                st.Id_Gender = b.Id_Gender;
                st.Id_Role = a.Id_Role;
                st.Login = LoginTB.Text.Trim();
                st.Password = PasswordTB.Text.Trim();
                dbconnection.Circus.Staff.Add(st);
            }
            dbconnection.Circus.SaveChanges();
        }
    }
}
