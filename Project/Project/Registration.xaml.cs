using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        static Random random = new Random();
        static public int r_check = random.Next(1000, 9999);
        public int code = r_check;

        static public string lableText;
        public string text = lableText;

        static public string emailText;
        public string EText = emailText;

        static public string passwordText;
        public string PText = passwordText;        

        static public string cityHos;
        public string HCity = cityHos;

        static public string adressHos;
        public string HAdress = adressHos;
        public Registration()
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

       

        public void Mail()
        {

            string mail = tb4.Text;
            MailAddress from = new MailAddress("iushinarty@yandex.by", "Бот");
            MailAddress to = new MailAddress($"{mail}");
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Код подтверждения";
            m.Body = $"Ваш код подтверждения:{r_check}";
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587);
            smtp.Credentials = new NetworkCredential("iushinarty@yandex.by", "Kfcrf12345");
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(m);
            }
            catch (Exception ex)
            {

            }
        }

        public void OpenCodeWindow()
        {
            CodeEmail codeEmail = new CodeEmail();            
            codeEmail.ShowDialog();
        }

        public void TextLable()
        {
            lableText = name.Text;
            passwordText = tb5.Text;
            emailText = tb4.Text;
            cityHos = city.Text;
            adressHos = adress.Text;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(name.Text != "" || city.Text != "" || adress.Text != "" || tb4.Text != "" || tb5.Text != "" || tb6.Text != "")
            {
                if (tb5.Text == tb6.Text)
                {
                    TextLable();
                    Mail();
                    OpenCodeWindow();
                }
                else
                {
                    LablePassword.Content = "Пароли не совпадают";
                }
            }
            else
            {
                LablePassword.Content = "Заполните все поля";
            }

            
            
        }
    }
}
