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
using System.Windows.Shapes;

namespace Project
{
    /// <summary>
    /// Логика взаимодействия для NextTicket.xaml
    /// </summary>
    public partial class NextTicket : Window
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        MainWindow window = new MainWindow();

        public NextTicket()
        {
            InitializeComponent();

            var qerty = from registrationPatient in db.ListTicket
                        select new {registrationPatient.ФИО_пациента, registrationPatient.Продление, registrationPatient.Дата_с, registrationPatient.Дата_по, registrationPatient.Дата_закрытия_больничного};
            data1.ItemsSource = qerty.ToList();
        }

        public void DateNext()
        {

            int b = 0;
            if(check1.IsChecked == false)
            {
                string datebox1 = date.Text;
                string[] datearr = datebox1.Split(new char[] { '.' });
                int year1 = 0;
                int mounth1 = 0;
                int day1 = 0;
                for (int i = 0; i < datearr.Length; ++i)
                {
                    year1 = Convert.ToInt32(datearr[2]);
                    mounth1 = Convert.ToInt32(datearr[1]);
                    day1 = Convert.ToInt32(datearr[0]);
                }
                DateTime date1 = new DateTime(year1, mounth1, day1);

                string datebox2 = sdate.Text;
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


                IQueryable<HospitalInfo> qerty = from lable in db.HospitalInfo
                                                 where lable.Id_hospital == Convert.ToInt32(window.idUser)
                                                 select lable;
                string s = "";
                string n = "";
                foreach (HospitalInfo cust in qerty)
                {
                    s += cust.name_hospital;
                    n += cust.city_hospital;
                }

                NextDate nextDate = new NextDate
                { next_number = Convert.ToInt32(nextnumber.Text), fio_doctor = s, soec_doctor = n, end_date = date1, id_fk_next = 1, star_date = date2 };
                db.GetTable<NextDate>().InsertOnSubmit(nextDate);
                db.SubmitChanges();
            }
            else if(check1.IsChecked == true)
            {
                Table<NextDate> nextDates = db.GetTable<NextDate>();
                foreach (var id in nextDates)
                {

                    if (id.next_number == Convert.ToInt32(nextnumber.Text))
                    {
                        b = 1;
                        DateTime u = (DateTime)id.end_date;
                        u = u.AddDays(1);
                        id.close_date = u;
                        db.SubmitChanges();
                    }
                }
                if (b == 0)
                {                       
                           
                            IQueryable<HospitalInfo> qerty = from lable in db.HospitalInfo
                                                             where lable.Id_hospital == Convert.ToInt32(window.idUser)
                                                             select lable;
                            string s = "";
                            string n = "";
                            foreach (HospitalInfo cust in qerty)
                            {
                                s += cust.name_hospital;
                                n += cust.city_hospital;
                            }
                            NextDate nextDate = new NextDate
                            { next_number = Convert.ToInt32(nextnumber.Text), fio_doctor = s, soec_doctor = n, id_fk_next = 1 };
                            db.GetTable<NextDate>().InsertOnSubmit(nextDate);
                            db.SubmitChanges();
                    Table<TicketList> t = db.GetTable<TicketList>();
                    DateTime y = new DateTime();
                    foreach (var c in t)
                    {
                        y = (DateTime)c.End_date_disease;
                        y = y.AddDays(1);
                                          
                    }
                    Table<NextDate> next = db.GetTable<NextDate>();
                    foreach (var id in next)
                    {
                        if (id.next_number == Convert.ToInt32(nextnumber.Text))
                        {
                            id.close_date = y;
                            db.SubmitChanges();
                        }
                            
                    }

                }



            }

        }
        public void CheckTrue()
        {
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateNext();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TicketViewPatients ticketViewPatients = new TicketViewPatients();
            ticketViewPatients.Show();
        }
    }
}
