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
    /// Логика взаимодействия для StatsDoctor.xaml
    /// </summary>
    public partial class StatsDoctor : UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();        
        public StatsDoctor()
        {
            InitializeComponent();
            start.Visibility = Visibility.Collapsed;
            end.Visibility = Visibility.Collapsed;
            but.Visibility = Visibility.Collapsed;
        }

        public void StatsDoctorHospital()
        {

            if (check1.IsChecked == true)
            {
                start.Visibility = Visibility.Visible;
                end.Visibility = Visibility.Visible;
                but.Visibility = Visibility.Visible;
            }       
            if(check2.IsChecked == true)
            {
                start.Visibility = Visibility.Visible;
                end.Visibility = Visibility.Collapsed;
                but.Visibility = Visibility.Visible;
            }
            if (check3.IsChecked == true)
            {
                start.Visibility = Visibility.Visible;
                end.Visibility = Visibility.Collapsed;
                but.Visibility = Visibility.Visible;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StatsDoctorHospital();
        }

        private void but_Click(object sender, RoutedEventArgs e)
        {
            if (check1.IsChecked == true)
            {
                Date();
            }
            if (check2.IsChecked == true)
            {
                Side();
            }
            if(check3.IsChecked == true)
            {
                Code();
            }
        }
        
        public void Code()
        {
            var qerty = from listPatient in db.TicketView
                        where listPatient.Код_заболевания == start.Text
                        select new { listPatient.ФИО_пациента, listPatient.Участок, listPatient.Код_заболевания, listPatient.Место_работы, listPatient.Дата_открытия_больничного, listPatient.Дата_закрытия_больничного };
            data1.ItemsSource = qerty.ToList();
        }

        public void Side()
        {
            var qerty = from listPatient in db.TicketView
                        where listPatient.Участок == start.Text
                        select new { listPatient.ФИО_пациента, listPatient.Участок, listPatient.Код_заболевания, listPatient.Место_работы, listPatient.Дата_открытия_больничного, listPatient.Дата_закрытия_больничного };
            data1.ItemsSource = qerty.ToList();
        }

        public void Date()
        {
            string first = start.Text;
            string second = end.Text;


            string datebox1 = start.Text;
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

            string datebox2 = end.Text;
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

            var qerty = from listPatient in db.TicketView
                        where listPatient.Дата_открытия_больничного >= date1 && listPatient.Дата_закрытия_больничного <= date2
                        select new { listPatient.ФИО_пациента, listPatient.Участок, listPatient.Код_заболевания, listPatient.Место_работы, listPatient.Дата_открытия_больничного, listPatient.Дата_закрытия_больничного };
            data1.ItemsSource = qerty.ToList();
        }
    }
}
