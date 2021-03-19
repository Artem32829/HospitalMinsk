using Project.Model;
using System;
using System.Collections.Generic;
using System.Data.Linq;
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

namespace Project.View
{
    /// <summary>
    /// Логика взаимодействия для Catalog.xaml
    /// </summary>
    public partial class Catalog : UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public string[] arrpol = new string[] { "Мужской", "Женский" };
        public string[] adrespatienta = new string[] { "Авакяна", "Быховская", "Воронянского", "Левкова", "Радищева", "Аэродромный пер",
            "Аэродромная", "Быховская", "Жуковского проезд", "Жуковского", "Нефтяная", "Нефтяной пер","Пензенская", "Рогачевский проезд", "Сенницкая",
            "Вирская", "Чкалова", "Брилевская","Короткевича", "Братская", "Вильямса","Германовская", "Докучаева", "Физкультурная" };


        public string[] side1 = new string[] { "Авакяна", "Быховская", "Воронянского" };
        public string[] side2 = new string[] { "Левкова", "Радищева", "Аэродромный пер" };
        public string[] side3 = new string[] { "Аэродромная", "Быховская", "Жуковского проезд" };
        public string[] side4 = new string[] { "Жуковского", "Нефтяная", "Нефтяной пер" };
        public string[] side5 = new string[] { "Пензенская", "Рогачевский проезд", "Сенницкая" };
        public string[] side6 = new string[] { "Вирская", "Чкалова", "Брилевская" };
        public string[] side7 = new string[] { "Короткевича", "Братская", "Вильямса" };
        public string[] side8 = new string[] { "Германовская", "Докучаева", "Физкультурная" };



        public Catalog()
        {
            InitializeComponent();
            PolPatient();
        }
        public void Patien()
        {
            string home = "";
            for (int i = 0; i < side1.Length; ++i)
            {
                if (adresbox.Text == side1[i])
                {
                    home = "1";
                }
                if (adresbox.Text == side2[i])
                {
                    home = "2";
                }
                if (adresbox.Text == side3[i])
                {
                    home = "3";
                }
                if (adresbox.Text == side4[i])
                {
                    home = "4";
                }
                if (adresbox.Text == side5[i])
                {
                    home = "5";
                }
                if (adresbox.Text == side6[i])
                {
                    home = "6";
                }
                if (adresbox.Text == side7[i])
                {
                    home = "7";
                }
                if (adresbox.Text == side8[i])
                {
                    home = "8";
                }

            }
            RegistrationPatient registrationPatient = new RegistrationPatient { side = home, pol = comboxpol.Text.ToString(), adress_patient = adresbox.Text.ToString(), birthday = birthday.Text.ToString(), name_patient = namepatient.Text.ToString(), numberPhone_patient = number.Text.ToString() };
            db.GetTable<RegistrationPatient>().InsertOnSubmit(registrationPatient);
            db.SubmitChanges();
            TiketPaatient();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string datebox2 = birthday.Text;
            int year2 = 0;
            int mounth2 = 0;
            int day2 = 0;
            string[] datearr2 = datebox2.Split(new char[] { '.' });
            for (int i = 0; i < datearr2.Length; ++i)
            {
                year2 = Convert.ToInt32(datearr2[2]);
                mounth2 = Convert.ToInt32(datearr2[1]);
                day2 = Convert.ToInt32(datearr2[0]);
            }
            DateTime date2 = new DateTime(year2, mounth2, day2);
            DateTime dateTime = DateTime.Now;
            TimeSpan timeSpan = dateTime - date2;
            TimeSpan span = new TimeSpan(6574, 0, 0, 0);
            if (timeSpan < span)
            {
                error.Content = "Регистрируемому пациенту меньше 18 лет. Регистрация невозможна";
            }
            else
            {
                Patien();
            }
        }
        
        private void Save_Button(object sender, RoutedEventArgs e)
        {
            db.SubmitChanges();           
        }        
        public void PolPatient()
        {            
            for(int i = 0; i<arrpol.Length;++i)
            {
                comboxpol.Items.Add(arrpol[i]);               
            }
            for(int a = 0; a<adrespatienta.Length; ++a)
            {
                adresbox.Items.Add(adrespatienta[a]);
            }
        }
        public void TiketPaatient()
        {
            Table<RegistrationPatient> autoid = db.GetTable<RegistrationPatient>();
            foreach (var id in autoid)
            {
                lablnuberticket.Content = id.Id_patient + 1;
            }
            FIOlable.Content = namepatient.Text;
            Birthdaylable.Content = birthday.Text;
            Placelable.Content = adresbox.Text;
            NumberPhonelable.Content = number.Text;
        }
        public void TrueDate()
        {
            
        }
    }
}
