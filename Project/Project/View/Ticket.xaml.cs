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
    /// Логика взаимодействия для Ticket.xaml
    /// </summary>
    public partial class Ticket : UserControl
    {
        static public DateTime date1 = new DateTime();
        public DateTime date3 = date1;
        static public DateTime date2 = new DateTime();
        public DateTime date4 = date2;

        DataClasses1DataContext db = new DataClasses1DataContext();
        MainWindow window = new MainWindow();
        public string[] arrpol = new string[] { "Мужской", "Женский" };

        public Ticket()
        {
            InitializeComponent();
            NameBox();
        }

        private void OpenCodeInfo(object sender, MouseButtonEventArgs e)
        {
            CodeInfo codeInfo = new CodeInfo();
            codeInfo.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Date();
        }
        public void NameBox()
        {
            Table<RegistrationPatient> autoid = db.GetTable<RegistrationPatient>();
            foreach (var id in autoid)
            {
                namepatbox.Items.Add(id.name_patient);
            }
            for (int i = 0; i < arrpol.Length; ++i)
            {
                polpatbox.Items.Add(arrpol[i]);
            }
        }
         public void Insrt()
         {
            IQueryable<HospitalInfo> qerty = from lable in db.HospitalInfo
                                             where lable.Id_hospital == Convert.ToInt32(window.idUser)
                                             select lable;
            string s = "";
            string spec = "";
            foreach (HospitalInfo cust in qerty)
            {
                s += cust.name_hospital;
                spec += cust.city_hospital;
            }            
            try
            {
                
                TicketList registrationticket = new TicketList
                {
                    FIO_patient = namepatbox.Text.ToString(),
                    Pol = polpatbox.Text.ToString(),                   
                    Job_patient = namejob.Text.ToString(),
                    FIO_doctor = s,
                    Specialty_doctor = spec,
                    Code_diseases = codeticket.Text.ToString(),
                    Other = other.Text.ToString(),
                    Start_date_disease =date1,
                    End_date_disease = date2,
                    id_fk_side = 1,
                    number = Convert.ToInt32(number.Text)                    
                };
                db.GetTable<TicketList>().InsertOnSubmit(registrationticket);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Date()
        {
            if(enddate.Text != "")
            {                
                date1 = DateTime.Now;
                string datebox2 = enddate.Text;
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
                date2 = new DateTime(year2, mounth2, day2);
                TimeSpan timeSpan = date2 - date1;
                TimeSpan span = new TimeSpan(14, 0, 0, 0);
                if (timeSpan > span)
                {
                    lableerror.Content = "Неверно введена дата(Дата следующего посещения не должна привышать 14 дней от текущей даты)";
                }
                else
                {                    
                    Insrt();
                    MessageBox.Show("Больничный лист добавлен");
                }
            }
            else
            {
                Insrt();
                MessageBox.Show("Больничный лист добавлен");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NextTicket nextTicket = new NextTicket();
            nextTicket.Show();
        }
    }
}
