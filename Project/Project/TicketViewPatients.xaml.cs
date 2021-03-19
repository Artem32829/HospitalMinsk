using Project.Model;
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
using System.Windows.Shapes;

namespace Project
{
    /// <summary>
    /// Логика взаимодействия для TicketViewPatients.xaml
    /// </summary>
    public partial class TicketViewPatients : Window
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public TicketViewPatients()
        {
            InitializeComponent();

            var qerty = from registrationPatient in db.TicketView
                        select new { registrationPatient.Номер_листа, registrationPatient.ФИО_пациента, registrationPatient.Участок, registrationPatient.Код_заболевания, registrationPatient.Дата_открытия_больничного, registrationPatient.Дата_закрытия_больничного };
            grid1.ItemsSource = qerty.ToList();
        }
    }
}
