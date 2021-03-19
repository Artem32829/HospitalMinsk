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
using Project.Model;




namespace Project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> nameList;
        DataClasses1DataContext db;
        static public string name;
        public string nameorg = name;

        static public string User;
        public string idUser = User;

        static public string nameoragnization;
        public string nameorg2 = nameoragnization;
        public MainWindow()
        {
            InitializeComponent();
            
            try
            {
                db = new DataClasses1DataContext();
                var users = db.Autorization_users.Where(d => d.isenable == true);
                nameList = new List<string>();
                foreach (var item in users)
                {
                    nameList.Add(item.email);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
            if(e.ChangedButton == MouseButton.Left)
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

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                
                var user = db.Autorization_users.Where(d => (d.email.ToLower()).Equals(emailBox.Text.ToLower())
                && d.password_users == passwordBox.Text && d.isenable == true).FirstOrDefault();

                if (user != null)
                {
                    User = user.Id_users.ToString();
                    Menu menu = new Menu();
                    menu.Show();
                    this.Close();
                }
                else
                {
                    ErrorPass.Content = "Неверный Email или пароль.";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void LAbleOrg()
        {
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Для продолжения регистрации, проверьте подключение к интернету");
            Registration registration = new Registration();
            this.Close();
            registration.ShowDialog();
        }
    }
}
