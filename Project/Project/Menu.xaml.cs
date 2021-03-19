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
using Project.View;
using Project.ViewModels;
using System.Diagnostics;

namespace Project
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        Registration registration = new Registration();
        MainWindow window = new MainWindow();
        DataClasses1DataContext db = new DataClasses1DataContext();
        
        public Menu()
        {            
            InitializeComponent();
            Lable();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new StatsViewModel();            
        }

        private void Catalog_Click(object sender, RoutedEventArgs e)
        {
                        
        }

        

        public void Lable()
        {
            IQueryable<HospitalInfo> qerty = from lable in db.HospitalInfo
                         where lable.Id_hospital == Convert.ToInt32(window.idUser)
                         select lable;
            string s = "";
            foreach (HospitalInfo cust in qerty)
            {
                s += cust.name_hospital;
            }
            lable1.Content = s;            
        }
        public void ContexMenu()
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataContext = new SearchPatient();            
        }

        private void Catalog_open(object sender, RoutedEventArgs e)
        {
            DataContext = new CatalogViewModel();
        }

        private void TicketFail(object sender, RoutedEventArgs e)
        {
            DataContext = new TicketFailModel();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DataContext = new TicketModel();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Report report = new Report();
            report.Show();
        }
        void hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("www.38gp.by"); //открытие ссылки в браузере

        }
    }
}
