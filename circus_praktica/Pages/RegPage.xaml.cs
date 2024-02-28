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
        public static List<Admin> Admin { get; set; }
        public static List<Artist> artists { get; set; }
        public static List<AnimalTrainer> trainers { get; set; }
        public static List<Role> roles { get; set; }
        public static List<Worker> Workers { get; set; }
        public static Admin adm = new Admin();
        public static Artist art = new Artist();
        public static AnimalTrainer trainer = new AnimalTrainer();
        public static Worker st = new Worker();
        public RegPage()
        {
            InitializeComponent();
            genders = new List<Gender>(dbconnection.Circus.Gender.ToList());
            roles = new List<Role>(dbconnection.Circus.Role.ToList());
            Admin = new List<Admin>(dbconnection.Circus.Admin.ToList());
            artists = new List<Artist>(dbconnection.Circus.Artist.ToList());
            trainers = new List<AnimalTrainer>(dbconnection.Circus.AnimalTrainer.ToList());
            Workers = new List<Worker>(dbconnection.Circus.Worker.ToList());
            this.DataContext = this;
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            var a = RoleCB.SelectedItem as Role;
            var b = GenderCB.SelectedItem as Gender;
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(SurnameTB.Text) || string.IsNullOrWhiteSpace(NameTB.Text) || string.IsNullOrWhiteSpace(PatronymicTB.Text)
               || string.IsNullOrWhiteSpace(GenderCB.Text) || string.IsNullOrWhiteSpace(PasswordTB.Text) || BDayDP.SelectedDate == null || string.IsNullOrWhiteSpace(LoginTB.Text)
               || string.IsNullOrWhiteSpace(RoleCB.Text))
            {
                error.AppendLine("Заполните все поля!");
            }

            
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
            }
            if (RoleCB.SelectedIndex == 0)
            {
                if (BDayDP.SelectedDate != null && (DateTime.Now - (DateTime)BDayDP.SelectedDate).TotalDays < 365 * 18 + 4)
                {
                    error.AppendLine("Сотрудник не может быть младше 18 лет.");
                }
                else
                {
                    adm.Surname = SurnameTB.Text.Trim();
                    adm.Name = NameTB.Text.Trim();
                    adm.Patronymic = PatronymicTB.Text.Trim();
                    adm.DateOfBirth = BDayDP.SelectedDate;
                    adm.IDGender = b.IDGender;
                    adm.IDRole = a.IDRole;
                    adm.Login = LoginTB.Text.Trim();
                    adm.Password = PasswordTB.Text.Trim();
                    dbconnection.Circus.Admin.Add(adm);
                    DBConnection.dbconnection.Circus.SaveChanges();
                }
                
            }
            if (RoleCB.SelectedIndex == 1)
            {
                if (BDayDP.SelectedDate != null && (DateTime.Now - (DateTime)BDayDP.SelectedDate).TotalDays < 365 * 18 + 4)
                {
                    error.AppendLine("Сотрудник не может быть младше 18 лет.");
                }
                else
                {
                    art.Surname = SurnameTB.Text.Trim();
                    art.Name = NameTB.Text.Trim();
                    art.Patronymic = PatronymicTB.Text.Trim();
                    art.IDGender = b.IDGender;
                    art.IDRole = a.IDRole;
                    art.DateOfBirth = BDayDP.SelectedDate;
                    art.Login = LoginTB.Text.Trim();
                    art.Password = PasswordTB.Text.Trim();
                    dbconnection.Circus.Artist.Add(art);
                    DBConnection.dbconnection.Circus.SaveChanges();
                }
                
            }
            if (RoleCB.SelectedIndex == 2)
            {
                if (BDayDP.SelectedDate != null && (DateTime.Now - (DateTime)BDayDP.SelectedDate).TotalDays < 365 * 18 + 4)
                {
                    error.AppendLine("Сотрудник не может быть младше 18 лет.");
                }
                else
                {
                    trainer.Surname = SurnameTB.Text.Trim();
                    trainer.Name = NameTB.Text.Trim();
                    trainer.Patronymic = PatronymicTB.Text.Trim();
                    trainer.DateOfBirth = BDayDP.SelectedDate;
                    trainer.IDGender = b.IDGender;
                    trainer.IDRole = a.IDRole;
                    trainer.Login = LoginTB.Text.Trim();
                    trainer.Password = PasswordTB.Text.Trim();
                    dbconnection.Circus.AnimalTrainer.Add(trainer);
                    DBConnection.dbconnection.Circus.SaveChanges();
                }
                
            }
            if(RoleCB.SelectedIndex == 3)
            {
                if (BDayDP.SelectedDate != null && (DateTime.Now - (DateTime)BDayDP.SelectedDate).TotalDays < 365 * 18 + 4)
                {
                    error.AppendLine("Сотрудник не может быть младше 18 лет.");
                }
                else
                {
                    st.Surname = SurnameTB.Text.Trim();
                    st.Name = NameTB.Text.Trim();
                    st.Patronymic = PatronymicTB.Text.Trim();
                    st.DateOfBirth = BDayDP.SelectedDate;
                    st.IDGender = b.IDGender;
                    st.IDRole = a.IDRole;
                    st.Login = LoginTB.Text.Trim();
                    st.Password = PasswordTB.Text.Trim();
                    dbconnection.Circus.Worker.Add(st);
                    DBConnection.dbconnection.Circus.SaveChanges();
                }
                

            }
            

        }
    }
}
