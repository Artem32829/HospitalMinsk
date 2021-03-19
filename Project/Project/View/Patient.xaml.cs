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
using System.Data.Entity.Core.Objects;

namespace Project.View
{
    /// <summary>
    /// Логика взаимодействия для Patient.xaml
    /// </summary>
    public partial class Patient : UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        

        public Patient()
        {
            InitializeComponent();
            Info();
        }
        
       public void Info()
       {
            var qerty = from registrationPatient in db.RegPatientView
                        select new { registrationPatient.Номер_по_журналу, registrationPatient.ФИО_пациента, registrationPatient.Адрес_пациента, registrationPatient.Дата_рождения, registrationPatient.Номер_телефона_пациента  };
                        datagrid1.ItemsSource = qerty.ToList();
            
        }
       public void SortPatient()
        {
            
            if(sortfio.Text != "")
            {
                var qerty = from registrationPatient in db.RegPatientView
                            where registrationPatient.ФИО_пациента == sortfio.Text
                            orderby registrationPatient.Дата_рождения
                            select new { registrationPatient.Номер_по_журналу, registrationPatient.ФИО_пациента, registrationPatient.Адрес_пациента, registrationPatient.Дата_рождения, registrationPatient.Номер_телефона_пациента };
                datagrid1.ItemsSource = qerty.ToList();
            }
            if(sortadress.Text != "")
            {
                var qerty = from registrationPatient in db.RegPatientView
                            where registrationPatient.Адрес_пациента == sortadress.Text
                            orderby registrationPatient.ФИО_пациента
                            select new { registrationPatient.Номер_по_журналу, registrationPatient.ФИО_пациента, registrationPatient.Адрес_пациента, registrationPatient.Дата_рождения, registrationPatient.Номер_телефона_пациента };
                datagrid1.ItemsSource = qerty.ToList();
            }
            if (sortbirthday.Text != "")
            {
                var qerty = from registrationPatient in db.RegPatientView
                            where registrationPatient.Дата_рождения == sortbirthday.Text
                            orderby registrationPatient.ФИО_пациента
                            select new { registrationPatient.Номер_по_журналу, registrationPatient.ФИО_пациента, registrationPatient.Адрес_пациента, registrationPatient.Дата_рождения, registrationPatient.Номер_телефона_пациента };
                datagrid1.ItemsSource = qerty.ToList();
            }
            if (sortphone.Text != "")
            {
                var qerty = from registrationPatient in db.RegPatientView
                            where registrationPatient.Номер_телефона_пациента == sortphone.Text
                            orderby registrationPatient.ФИО_пациента
                            select new { registrationPatient.Номер_по_журналу, registrationPatient.ФИО_пациента, registrationPatient.Адрес_пациента, registrationPatient.Дата_рождения, registrationPatient.Номер_телефона_пациента };
                datagrid1.ItemsSource = qerty.ToList();
            }
            if (sortbirthday.Text != "" && sortfio.Text != "" && sortphone.Text != "" && sortadress.Text != "")
            {
                var qerty = from registrationPatient in db.RegPatientView
                            where registrationPatient.Адрес_пациента == sortadress.Text && registrationPatient.ФИО_пациента == sortfio.Text && registrationPatient.Дата_рождения == sortbirthday.Text && registrationPatient.Номер_телефона_пациента == sortphone.Text
                            select new { registrationPatient.Номер_по_журналу, registrationPatient.ФИО_пациента, registrationPatient.Адрес_пациента, registrationPatient.Дата_рождения, registrationPatient.Номер_телефона_пациента };
                datagrid1.ItemsSource = qerty.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SortPatient();
        }
    }
}
