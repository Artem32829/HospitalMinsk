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
    /// Логика взаимодействия для TicketFail.xaml
    /// </summary>
    public partial class TicketFail : UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        MainWindow window = new MainWindow();
        public TicketFail()
        {
            InitializeComponent();
            NameBoxIMG();
        }
        public void Information()
        {
            Table<TicketList> list = db.GetTable<TicketList>();
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
            
            foreach (var namepatient in list)
            {
                if (namepatient.FIO_patient == namepatbox.Text)
                {
                    pollable.Content = namepatient.Pol;
                    fiolable.Content = namepatient.FIO_patient;
                    joblableticket.Content = namepatient.Job_patient;                  
                    otherlable.Content = namepatient.Other;                  
                    
                    codelable.Content = namepatient.Code_diseases;
                    number_ticket.Content = namepatient.number;
                    Table<NextDate> autoid = db.GetTable<NextDate>();                    
                    foreach (var id in autoid)
                    {
                        if(namepatient.number == id.next_number)
                        {                           
                            
                            
                                startlable.Content = $"{namepatient.Start_date_disease}\n{id.star_date}+\n";
                                endlable.Content = $"{namepatient.End_date_disease}\n{id.end_date}\n";
                                jobdoctorlable.Content = $"({namepatient.Specialty_doctor}\n{namepatient.FIO_doctor})\n({id.fio_doctor}\n{id.soec_doctor})";
                            if(id.close_date != null)
                            {
                                fiodoctorlable.Content = id.close_date;
                            }
                            else
                            {
                                fiodoctorlable.Content = "";
                            }
                            
                            
                            
                        }
                        else if(namepatient.number != id.next_number)
                        {
                            startlable.Content = namepatient.Start_date_disease;
                            endlable.Content = namepatient.End_date_disease;
                            jobdoctorlable.Content = $"({namepatient.Specialty_doctor}\n{namepatient.FIO_doctor})";
                        }
                        


                    }


                }                
            }
        }
        public void NameBoxIMG()
        {
            Table<RegistrationPatient> autoid = db.GetTable<RegistrationPatient>();
            foreach (var id in autoid)
            {
                namepatbox.Items.Add(id.name_patient);
            }
        }
        private void Use(object sender, RoutedEventArgs e)
        {
            Information();
        }

        private void Canvas_Img(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(canvas, "Распечатываем элемент Canvas");
            }
        }
    }
}
