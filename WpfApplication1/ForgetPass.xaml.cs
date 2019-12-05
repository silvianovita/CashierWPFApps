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
using Outlook = Microsoft.Office.Interop.Outlook;
using WpfApplication1.Context;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for ForgetPass.xaml
    /// </summary>
    public partial class ForgetPass : Window
    {
        MyContext myContext = new MyContext();
        public ForgetPass()
        {
            InitializeComponent();
        }

        private void ForPass_Click(object sender, RoutedEventArgs e)
        {
            string name = TxtFName.Text;
            string email = TxtFEmail.Text;

            var data = myContext.User.Where(d => d.Email == email).SingleOrDefault();

            if (data == null)
            {
                TxtFName.Text = "";
                TxtFEmail.Text = "";
                MessageBox.Show("Don't Have Account? Please Register!");

            }
            else
            {
                string pass = Guid.NewGuid().ToString();
                data.Password = pass;
                myContext.SaveChanges();

                Microsoft.Office.Interop.Outlook._Application _app = new Outlook.Application();
                Outlook.MailItem mail = (Outlook.MailItem)_app.CreateItem(Outlook.OlItemType.olMailItem);
                mail.To = TxtFEmail.Text;
                mail.Subject = "New Password";
                mail.Body = "Hi " + TxtFName.Text + ", this is your new password : " + pass;
                mail.Importance = Outlook.OlImportance.olImportanceNormal;
                ((Outlook._MailItem)mail).Send();
                TxtFName.Text = "";
                TxtFEmail.Text = "";
                MessageBox.Show("Your Message has been successfully sent.", "Message", MessageBoxButton.OKCancel);
                Login log = new Login();
                log.Show();
                this.Close();
            }
        }
    }
}
