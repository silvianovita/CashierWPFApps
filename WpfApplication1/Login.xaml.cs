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
using WpfApplication1.Context;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        MyContext myContext = new MyContext();

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = TxtEmail.Text;
            string pass = TxtPassword.Password;

            var data = myContext.User.Where(d => d.Email == email).SingleOrDefault();
            if (email == null)
            {
                TxtEmail.BorderBrush = Brushes.Red;
                TxtEmail.Focus();
            }
            if (pass == null)
            {
                TxtPassword.BorderBrush = Brushes.Red;
                TxtPassword.Focus();
            }
            if (data!=null)
            {
                MessageBox.Show("Login Successful");
                MainWindow dboard = new MainWindow();
                dboard.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login Unsuccessful! Re-entry your input");
                TxtEmail.Text = "";
                TxtPassword.Password = "";
            }
        }
         
        private void btnForgotPass_Click(object sender, RoutedEventArgs e)
        {
            ForgetPass fp = new ForgetPass();
            fp.Show();
            this.Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Register r = new Register();
            r.Show();
            this.Close();
        }
    }
}
