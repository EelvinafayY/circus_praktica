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
    /// Логика взаимодействия для AddAnimalPage.xaml
    /// </summary>
    public partial class AddAnimalPage : Page
    {
        public static List<Gender> genders { get; set; }
 
        public static List<AnimalTrainer> trainers { get; set; }

        public static List<Cell> cells { get; set; }

        public static AnimalTrainer trainer = new AnimalTrainer();
        public static Cell cell = new Cell();

        public AddAnimalPage()
        {
            InitializeComponent();
            genders = new List<Gender>(dbconnection.Circus.Gender.ToList());
            cells = new List<Cell>(dbconnection.Circus.Cell.ToList());
            trainers = new List<AnimalTrainer>(dbconnection.Circus.AnimalTrainer.ToList());
            this.DataContext = this;
        }
        private void NumericOnly(System.Object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);

        }


        private static bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(str);

        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var a = TrainerCB.SelectedItem as AnimalTrainer;
                var b = GenderCB.SelectedItem as Gender;
                StringBuilder error = new StringBuilder();

                if (string.IsNullOrWhiteSpace(VidTB.Text) || string.IsNullOrWhiteSpace(NameTB.Text) || string.IsNullOrWhiteSpace(WeightTB.Text)
                   || string.IsNullOrWhiteSpace(GenderCB.Text) || string.IsNullOrWhiteSpace(RecEdaTB.Text) || BDayDP.SelectedDate == null || string.IsNullOrWhiteSpace(RecYxodTB.Text)
                   || string.IsNullOrWhiteSpace(TrainerCB.Text))
                {
                    error.AppendLine("Заполните все поля!");
                }


                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    cell.Name = NameTB.Text.Trim() + " " + VidTB.Text.Trim();
                    cell.Weight = int.Parse(WeightTB.Text.Trim());
                    cell.AgeDate = BDayDP.SelectedDate;
                    cell.IDGender = b.IDGender;
                    cell.IDAnimalTrainer = a.IDAnimalTrainer;
                    cell.Recommendations = RecYxodTB.Text.Trim();
                    cell.FoodPreferences = RecEdaTB.Text.Trim();
                    dbconnection.Circus.Cell.Add(cell);
                    DBConnection.dbconnection.Circus.SaveChanges();
                }

                
            }
            catch
            {
                MessageBox.Show("Ой, какая-то ошибка");
            }
            
        }
            


        }
    }

