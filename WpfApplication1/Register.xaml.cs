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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        MyContext myContext = new MyContext();
        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string name=TxtName.Text;
            string email=TxtEmail.Text;
            var data = myContext.User.Where(d => d.Email == email).SingleOrDefault();
            if (data!=null)
            {
                MessageBox.Show("You have been Register");
            }
            else
            {
                string pass = Guid.NewGuid().ToString();
                var insert = new Model.User(name, email, pass);
                myContext.User.Add(insert);
                myContext.SaveChanges();
                MessageBox.Show("Register Successful");
                try
                {
                    Microsoft.Office.Interop.Outlook._Application _app = new Outlook.Application();
                    Outlook.MailItem mail = (Outlook.MailItem)_app.CreateItem(Outlook.OlItemType.olMailItem);
                    mail.To = TxtEmail.Text;
                    mail.Subject = "Successful Register";
                    mail.Body = "Hi " + TxtName.Text + ", this is your password : " + pass;
                    mail.Importance = Outlook.OlImportance.olImportanceNormal;
                    ((Outlook._MailItem)mail).Send();
                    TxtName.Text = "";
                    TxtEmail.Text = "";
                    MessageBox.Show("Your Message has been successfully sent.", "Message", MessageBoxButton.OKCancel);
                    Login log = new Login();
                    log.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK);
                }

                Login l = new Login();
                l.Show();
                this.Close();
            }
        }
    }
}
