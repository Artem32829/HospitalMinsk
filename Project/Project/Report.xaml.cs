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
    /// Логика взаимодействия для Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Report1 report1 = new Report1();
            report1.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ReportTicket reportTicket = new ReportTicket();
            reportTicket.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NextReport nextReport = new NextReport();
            nextReport.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ReportAuthor reportAuthor = new ReportAuthor();
            reportAuthor.Show();
        }
    }
}
