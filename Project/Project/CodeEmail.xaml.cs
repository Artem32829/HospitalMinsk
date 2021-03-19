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
    /// Логика взаимодействия для CodeEmail.xaml
    /// </summary>
    public partial class CodeEmail : Window
    {
        Registration registration = new Registration();
        DataClasses1DataContext db = new DataClasses1DataContext();
        MainWindow window = new MainWindow();
        int idusers;

        public CodeEmail()
        {
            InitializeComponent();
        }

        private void ExitButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MinButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void LogoContaner_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        public void TrueMail()
        {           
           
            if (tb1.Text == registration.code.ToString())
            {
                Table<Autorization_users> autoid = db.GetTable<Autorization_users>();
                foreach(var id in autoid)
                {
                    idusers = id.Id_users + 1;                    
                }                
                Autorization_users autorization_Users = new Autorization_users { email = registration.EText.ToString(), password_users = registration.PText.ToString(), isenable = true };
                db.GetTable<Autorization_users>().InsertOnSubmit(autorization_Users);
                db.SubmitChanges();
                HospitalInfo hospitalInfo = new HospitalInfo { name_hospital = registration.text.ToString(), city_hospital = registration.HCity.ToString(), adress_hospital = registration.HAdress.ToString(), id_fk_autorization = idusers};
                db.GetTable<HospitalInfo>().InsertOnSubmit(hospitalInfo);
                db.SubmitChanges();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else if (tb1.Text != registration.code.ToString())
            {
                mark.Content = "Неверно указан код";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {            
            TrueMail();
        }

        private void tb1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

