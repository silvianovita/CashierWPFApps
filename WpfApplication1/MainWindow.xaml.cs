using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using WpfApplication1.Context;
using WpfApplication1.Model;
using Outlook = Microsoft.Office.Interop.Outlook;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.ComponentModel;
using System.Drawing;
using System.Collections.ObjectModel;
using System.Data;
using Syncfusion.Pdf.Grid;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyContext myContext = new MyContext();

        int role_id;
        int sup_id;
        int Item_id;

        int Total = 0;

        List<TransactionItem> TList = new List<TransactionItem>();

        public MainWindow()
        {
            InitializeComponent();
            Imported.ItemsSource = myContext.Suppliers.ToList();
            Imported_Item.ItemsSource = myContext.Item.ToList();
            TxtId.IsEnabled = false;
            TxtId_item.IsEnabled = false;
            TxtPricePcs.IsEnabled = false;


            //Combobox Untuk Supplier Name
            Cbx_Supplier.ItemsSource = myContext.Suppliers.ToList();
            Cbx_Supplier.DisplayMemberPath = "Name";
            Cbx_Supplier.SelectedValuePath = "id";
            var data = Cbx_Supplier.SelectedValue;

            Cbx_Item.ItemsSource = myContext.Item.ToList();
            Cbx_Item.DisplayMemberPath = "Name";
            Cbx_Item.SelectedValuePath = "ID";
            var data1 = Cbx_Item.SelectedValue;

            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnUpdate_Item.IsEnabled = false;
            btnDelete_Item.IsEnabled = false;
            TxtReturn.IsEnabled = false;
            TxtTotal.IsEnabled = false;
            btnCreate.IsEnabled = false;

            //register dan role
            TxtId_Role.IsEnabled = false;
            TxtIDR.IsEnabled = false;
            btnUpdate_user.IsEnabled = false;
            btnUpdate_Role.IsEnabled = false;

            Imported_Role.ItemsSource = myContext.Role.ToList();
            Imported_User.ItemsSource = myContext.User.ToList();
            Cbx_Role.ItemsSource = myContext.Role.ToList();
            Cbx_Role.DisplayMemberPath = "Name";
            Cbx_Role.SelectedValuePath = "id";
            var dtRole = Cbx_Role.SelectedValue;
        }
        public void TextName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^A-Za-z!]+$");
            e.Handled = regex.IsMatch(e.Text);
        }
        public void TextPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+$");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void TextStock_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+$");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void TextEmail_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^A-Za-z0-9.@]+$");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //String ID = TxtId.Text;
            //String Name = TxtName.Text;
            //MessageBox.Show("Your ID : " + ID + ", Your Name : " + Name);

            var push = new Supplier(TxtName.Text, TxtEmail.Text);
            myContext.Suppliers.Add(push);
            var result = myContext.SaveChanges();

            myContext.Suppliers.Where(p => p.Email == TxtEmail.Text);

            var emailDiff = myContext.Suppliers.Where(p => p.Email == TxtEmail.Text).FirstOrDefault();
            if (String.IsNullOrEmpty(TxtName.Text))
            {
                TxtName.BorderBrush = System.Windows.Media.Brushes.Red;
                TxtName.Focus();
            }
            if (String.IsNullOrEmpty(TxtEmail.Text))
            {
                TxtEmail.BorderBrush = System.Windows.Media.Brushes.Red;
                TxtEmail.Focus();
            }
            if (String.IsNullOrEmpty(TxtName.Text) && String.IsNullOrEmpty(TxtEmail.Text))
            {
                TxtName.BorderBrush = System.Windows.Media.Brushes.Red;
                TxtName.Focus();
                TxtEmail.BorderBrush = System.Windows.Media.Brushes.Red;
                TxtEmail.Focus();
            }
            if (emailDiff == null)
            {
                MessageBox.Show("Your Email has been registered");
                TxtName.Text = "";
                TxtEmail.Text = "";
            }
            else
            {
                if (result > 0)
                {
                    Imported.ItemsSource = myContext.Suppliers.ToList();
                    //MessageBox.Show(result + " row has been inserted");

                    //Send Outlook 
                    try
                    {
                        Outlook._Application _app = new Outlook.Application();
                        Outlook.MailItem mail = (Outlook.MailItem)_app.CreateItem(Outlook.OlItemType.olMailItem);
                        mail.To = TxtEmail.Text;
                        mail.Subject = "Your Data has been saved";
                        mail.Body = "Hi " + TxtName.Text + ", this email is automatically sent to inform you, that your data (included this email) has been saved in Bootcamp32 ";
                        mail.Importance = Outlook.OlImportance.olImportanceNormal;
                        ((Outlook._MailItem)mail).Send();
                        TxtName.Text = "";
                        TxtEmail.Text = "";
                        MessageBox.Show("Your Message has been successfully sent.", "Message", MessageBoxButton.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK);
                    }
                }
            }
            Cbx_Supplier.ItemsSource = myContext.Suppliers.ToList();

        }


        private void Imported_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var data = Imported.SelectedItem;
            string id = (Imported.SelectedCells[0].Column.GetCellContent(data) as TextBlock).Text;
            TxtId.Text = id;
            TxtId.IsEnabled = false;
            string name = (Imported.SelectedCells[1].Column.GetCellContent(data) as TextBlock).Text;
            TxtName.Text = name;
            string email = (Imported.SelectedCells[2].Column.GetCellContent(data) as TextBlock).Text;
            TxtEmail.Text = email;

            btnSubmit.IsEnabled = false;
            btnUpdate.IsEnabled = true;
            btnDelete.IsEnabled = true;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                int id = Convert.ToInt32(TxtId.Text);
                var upRow = myContext.Suppliers.Where(u => u.id == id).FirstOrDefault();
                upRow.Name = TxtName.Text;
                upRow.Email = TxtEmail.Text;
                myContext.SaveChanges();

                Imported.ItemsSource = myContext.Suppliers.ToList();

                TxtId.IsEnabled = true;
                TxtId.Text = "";
                TxtName.Text = "";
                TxtEmail.Text = "";
                btnSubmit.IsEnabled = true;
                btnUpdate.IsEnabled = false;
                btnDelete.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you Want to delete the supplier?", "Delete", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
                {
                    int id = Convert.ToInt32(TxtId.Text);
                    var deRow = myContext.Suppliers.Where(d => d.id == id).FirstOrDefault();
                    myContext.Suppliers.Remove(deRow);
                    myContext.SaveChanges();


                    Imported.ItemsSource = myContext.Suppliers.ToList();

                    TxtId.IsEnabled = true;
                    TxtId.Text = "";
                    TxtName.Text = "";
                    TxtEmail.Text = "";
                    btnSubmit.IsEnabled = true;
                    btnUpdate.IsEnabled = false;
                    btnDelete.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK);
            }
        }

        private void btnSubmitItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int stock = Convert.ToInt32(TxtStock.Text);
                int price = Convert.ToInt32(TxtPrice.Text);

                var supplier = myContext.Suppliers.Where(w => w.id == sup_id).FirstOrDefault();
                var iName = myContext.Item.Where(i => i.Name == TxtName_item.Text).SingleOrDefault();
                var iPrice = myContext.Item.Where(i => i.Price == price).SingleOrDefault();
                if (iName != null && Cbx_Supplier.Text != null)
                {
                    if (iPrice != null)
                    {
                        iName.Stock += stock;

                        myContext.SaveChanges();
                        MessageBox.Show("Your data has been saved");

                    }
                    else
                    {
                        var push = new Items(TxtName_item.Text, stock, price, supplier);
                        myContext.Item.Add(push);
                        var result = myContext.SaveChanges();

                        if (result > 0)
                        {
                            MessageBox.Show("Your data has been saved");
                        }

                    }
                }


                TxtName_item.Text = "";
                TxtStock.Text = "";
                TxtPrice.Text = "";
                btnDelete_Item.IsEnabled = false;
                btnDelete_Item.IsEnabled = false;

                Imported_Item.ItemsSource = myContext.Item.ToList();
                Cbx_Item.ItemsSource = myContext.Item.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("");
            }
        }

        private void btnUpdateItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var supp = myContext.Suppliers.Where(w => w.id == sup_id).FirstOrDefault();
                int id = Convert.ToInt32(TxtId_item.Text);
                var upRow = myContext.Item.Where(u => u.ID == id).FirstOrDefault();
                upRow.Name = TxtName_item.Text;
                upRow.Stock = Convert.ToInt32(TxtStock.Text);
                upRow.Price = Convert.ToInt32(TxtPrice.Text);
                upRow.Supplier = supp;

                myContext.SaveChanges();

                Imported_Item.ItemsSource = myContext.Item.ToList();

                TxtId_item.Text = "";
                TxtName_item.Text = "";
                TxtStock.Text = "";
                TxtStock.Text = "";
                TxtPrice.Text = "";

                btnSubmit.IsEnabled = true;
                btnUpdate.IsEnabled = false;
                btnDelete.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK);
            }
        }

        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you Want to delete the Item", "Delete", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
                {
                    int id = Convert.ToInt32(TxtId.Text);
                    var deRow = myContext.Item.Where(d => d.ID == id).FirstOrDefault();
                    myContext.Item.Remove(deRow);


                    Imported.ItemsSource = myContext.Item.ToList();

                    TxtId_item.Text = "";
                    TxtName_item.Text = "";
                    TxtStock.Text = "";
                    TxtPrice.Text = "";
                    Cbx_Supplier.Text = "";
                    btnSubmit.IsEnabled = true;
                    btnUpdate.IsEnabled = false;
                    btnDelete.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Cbx_Supplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sup_id = Convert.ToInt32(Cbx_Supplier.SelectedValue.ToString());
        }

        private void Imported_Item_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var data = Imported_Item.SelectedItem;
                string id = (Imported_Item.SelectedCells[0].Column.GetCellContent(data) as TextBlock).Text;
                TxtId_item.Text = id;
                TxtId.IsEnabled = false;
                string name = (Imported_Item.SelectedCells[1].Column.GetCellContent(data) as TextBlock).Text;
                TxtName_item.Text = name;
                string stock = (Imported_Item.SelectedCells[2].Column.GetCellContent(data) as TextBlock).Text;
                TxtStock.Text = stock;
                string price = (Imported_Item.SelectedCells[3].Column.GetCellContent(data) as TextBlock).Text;
                TxtPrice.Text = price;
                string supplierName = (Imported_Item.SelectedCells[4].Column.GetCellContent(data) as TextBlock).Text;
                Cbx_Supplier.Text = supplierName;

                btnSubmit_Item.IsEnabled = false;
                btnUpdate_Item.IsEnabled = true;
                btnDelete_Item.IsEnabled = true;

            }
            catch (Exception)
            {

            }
        }
        private void Cbx_Item_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Item_id = Convert.ToInt32(Cbx_Item.SelectedValue.ToString());
            var data = Imported_Item.SelectedValue;
            var itemsid = myContext.Item.Where(p => p.ID == Item_id).FirstOrDefault();

            TxtPricePcs.Text = itemsid.Price.ToString();

        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {

            var itm = myContext.Item.Where(i => i.ID == Item_id).FirstOrDefault();
            int price = Convert.ToInt32(TxtPricePcs.Text);
            int quantity = Convert.ToInt32(TxtQty.Text);

            int stock = itm.Stock;

            if (quantity > stock)
            {
                MessageBox.Show("Quantity yang diinputkan lebih besar dari jumlah stok");
            }
            else
            {
                int totalpcs = price * quantity;
                Imported_Transaction.Items.Add(new { Name = Cbx_Item.Text, qty = quantity, Price = totalpcs });
                int Tqty = stock - quantity;
                itm.Stock = Convert.ToInt32(Tqty);
                myContext.SaveChanges();

                Total += totalpcs;
                TxtTotal.Text = Total.ToString();

                TList.Add(new TransactionItem { quantity = quantity, Item = itm });
                Imported_Item.ItemsSource = myContext.Item.ToList();

                btnPay.IsEnabled = true;

            }
        }


        private void Imported_Transaction_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var data = Imported_Transaction.SelectedItem;
                string name = (Imported_Transaction.SelectedCells[1].Column.GetCellContent(data) as TextBlock).Text;
                Cbx_Item.Text = name;
                string Qty = (Imported_Transaction.SelectedCells[2].Column.GetCellContent(data) as TextBlock).Text;
                TxtQty.Text = Qty;
                string Total = (Imported_Transaction.SelectedCells[3].Column.GetCellContent(data) as TextBlock).Text;
                TxtPricePcs.Text = Total;

            }
            catch (Exception)
            {

            }
        }
        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var data = Imported_Transaction.SelectedItem;
                var itm = myContext.Item.Where(w => w.ID == sup_id).FirstOrDefault();
                var upRow = myContext.TcItem.Where(u => u.id == Item_id).FirstOrDefault();
                int qtyup = Convert.ToInt32(TxtQty.Text);


                myContext.SaveChanges();

                Imported_Transaction.ItemsSource = myContext.Item.ToList();

                string name_item = Cbx_Item.Text;
                int quantity = Convert.ToInt32(TxtQty.Text);

                int stock = itm.Stock;
                int Tqty = stock + quantity;
                itm.Stock = Convert.ToInt32(Tqty);
                myContext.SaveChanges();

                TxtId_item.Text = "";
                TxtName_item.Text = "";
                TxtStock.Text = "";
                TxtStock.Text = "";
                TxtPrice.Text = "";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK);
            }
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            Imported_Transaction.Items.Remove(Imported_Transaction.SelectedItem);

            string name_item = Cbx_Item.Text;
            int quantity = Convert.ToInt32(TxtQty.Text);

            var itm = myContext.Item.Where(i => i.Name == name_item).SingleOrDefault();
            int stock = itm.Stock;
            int Tqty = stock + quantity;
            itm.Stock = Convert.ToInt32(Tqty);

            int tlpcs = Convert.ToInt32(TxtTotal.Text);
            Total -= itm.Price;
            TxtTotal.Text = Total.ToString();

            myContext.SaveChanges();

        }

        private void btn_refresh_Click_1(object sender, RoutedEventArgs e)
        {
            TxtQty.Text = "";
            TxtPricePcs.Text = "";

        }


        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            var push = new Transaction(DateTime.Now);
            myContext.Transaction.Add(push);
            var result = myContext.SaveChanges();


            if (result > 0)
            {
                var tsc = myContext.Transaction.OrderByDescending(t => t.id).First();

                foreach (var s in TList)
                {
                    var isi = new TransactionItem(s.quantity, tsc, s.Item);
                    myContext.TcItem.Add(isi);
                    myContext.SaveChanges();
                }

                //var it= Imported_Transaction.Items;

                //for (int i = 0; i <= Imported_Transaction.Items.Count; ++i)
                //{
                //    string nama = (Imported_Transaction.SelectedCells[1].Column.GetCellContent(it[i]) as TextBlock).Text;
                //    var itm = myContext.Item.Where(j => j.Name==nama).SingleOrDefault();
                //    int qty = Convert.ToInt32((Imported_Transaction.Columns[2].GetCellContent(it[i]) as TextBlock).Text);
                //    var push_ti = new TransactionItem(qty, tsc, itm);
                //    myContext.TcItem.Add(push_ti);
                //    myContext.SaveChanges();
                //}

                //Bisa!
                //Create a new PDF document.
                PdfDocument doc = new PdfDocument();
                //Add a page.
                PdfPage page = doc.Pages.Add();


                PdfGraphics graphics = page.Graphics;

                //Create a PdfGrid.
                PdfGrid pdfGrid = new PdfGrid();
                string judul = "---- Barang----";// +Qty;
                string isian = "Total Harga : " + TxtTotal.Text + "\nUang yang dibayarkan : " + TxtPay.Text + "\nKembalian : " + TxtReturn.Text;

                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
                graphics.DrawString(judul, font, PdfBrushes.Black, new PointF(0, 0));
                
                //Header :

                //Create a DataTable.
                DataTable dataTable = new DataTable();
                //Add columns to the DataTable
                dataTable.Columns.Add("Barang");
                dataTable.Columns.Add("QTY");
                dataTable.Columns.Add("Harga");
                //Add rows to the DataTable.
                foreach (var p in TList)
                {
                    int harga = p.Item.Price * p.quantity;
                    dataTable.Rows.Add(new object[] { p.Item.Name, p.quantity, harga });
                }

                //Assign data source.
                pdfGrid.DataSource = dataTable;
                //Draw grid to the page of PDF document.
                pdfGrid.Draw(page, new PointF(0, 30));
                graphics.DrawString(isian, font, PdfBrushes.Black, new PointF(0, 150));
                //Save the document.
                doc.Save("Struk.pdf");
                System.Diagnostics.Process.Start("Struk.pdf");
                //close the document
                doc.Close(true);


                //using (PdfDocument document = new PdfDocument())
                //{

                //    //Add a page to the document
                //    PdfPage page = document.Pages.Add();

                //    //Create PDF graphics for a page
                //    PdfGraphics graphics = page.Graphics;

                //    //Set the standard font
                //    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

                //    //Draw the text

                //    //string Qty ;//= Imported_Transaction.SelectedValue();
                //    string judul = "---- Barang----";// +Qty;
                //    string isi = "Total Harga : " + TxtTotal.Text + "\nUang yang dibayarkan : " + TxtPay.Text + "\nKembalian : " + TxtReturn.Text;

                //    graphics.DrawString(judul, font, PdfBrushes.Black, new PointF(0, 0));
                //    graphics.DrawString(isi, font, PdfBrushes.Black, new PointF(0, 15));

                //    //Save the document
                //    document.Save("Struk.pdf");

                //    #region View the Workbook
                //    //Message box confirmation to view the created document.
                //    string pesan = "Total Kembalian = " + TxtReturn.Text + ", Ingin Mencetak Struk?";
                //    if (MessageBox.Show(pesan, "Struk PDF has been created",
                //        MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                //    {
                //        try
                //        {
                //            //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                //            System.Diagnostics.Process.Start("Struk.pdf");


                //            //Exit
                //            //Close();
                //        }
                //        catch (Win32Exception ex)
                //        {
                //            Console.WriteLine(ex.ToString());
                //        }
                //    }
                //    else
                //        Close();
                //    #endregion
                //}
            }

        }


        private void btnpay_Click(object sender, RoutedEventArgs e)
        {
            int pay = Convert.ToInt32(TxtPay.Text);
            int ttal = Convert.ToInt32(TxtTotal.Text);
            int total = pay - ttal;
            if (pay < ttal)
            {
                MessageBox.Show("Uang yang dibayarkan kurang", "Uang yang kurang sejumlah " + total);
                TxtReturn.Text = Convert.ToString(total);
                Imported_Transaction.IsEnabled = false;
            }
            else
            {
                TxtReturn.Text = Convert.ToString(total);
                btnCreate.IsEnabled = true;
            }
        }

#region register dan login
        private void Cbx_Role_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           role_id = Convert.ToInt32(Cbx_Role.SelectedValue.ToString());

        }

        private void btnSubmit_user_Click(object sender, RoutedEventArgs e)
        {
            string pass = Guid.NewGuid().ToString();

            var role = myContext.Role.Where(r => r.id == role_id).FirstOrDefault();

            var add = new User(TxtNameR.Text, TxtEmailR.Text, pass, role);
            myContext.User.Add(add);
            var result= myContext.SaveChanges();
            
            var emailDiff = myContext.User.Where(p => p.Email == TxtEmailR.Text).FirstOrDefault();
            if (String.IsNullOrEmpty(TxtNameR.Text))
            {
                TxtNameR.BorderBrush = System.Windows.Media.Brushes.Red;
                TxtNameR.Focus();
            }
            if (String.IsNullOrEmpty(TxtEmailR.Text))
            {
                TxtEmailR.BorderBrush = System.Windows.Media.Brushes.Red;
                TxtEmailR.Focus();
            }
            if (String.IsNullOrEmpty(TxtNameR.Text) && String.IsNullOrEmpty(TxtEmail.Text))
            {
                TxtNameR.BorderBrush = System.Windows.Media.Brushes.Red;
                TxtNameR.Focus();
                TxtEmailR.BorderBrush = System.Windows.Media.Brushes.Red;
                TxtEmailR.Focus();
            }
            if (emailDiff == null)
            {
                MessageBox.Show("Your Email has been registered");
                TxtNameR.Text = "";
                TxtEmailR.Text = "";
            }
            else
            {
                if (result > 0)
                {
                    Imported_User.ItemsSource = myContext.User.ToList();

                    //Send Outlook 
                    try
                    {
                        Outlook._Application _app = new Outlook.Application();
                        Outlook.MailItem mail = (Outlook.MailItem)_app.CreateItem(Outlook.OlItemType.olMailItem);
                        mail.To = TxtEmailR.Text;
                        mail.Subject = "Your Data has been saved (Sending Password)";
                        mail.Body = "Hi " + TxtNameR.Text + ", this email is automatically sent to inform you, that your data (included this email) has been saved in Bootcamp32 ";
                        mail.Body = "";
                        mail.Body = "This is Your password : "+pass;
                        mail.Importance = Outlook.OlImportance.olImportanceNormal;
                        ((Outlook._MailItem)mail).Send();
                        TxtNameR.Text = "";
                        TxtEmailR.Text = "";
                        MessageBox.Show("Your Message has been successfully sent.", "Message", MessageBoxButton.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK);
                    }
                }
            }
        }

        private void btnUpdate_user_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(TxtIDR.Text);
                var rname = myContext.Role.Where(r => r.id == role_id).FirstOrDefault();


                var upRow = myContext.User.Where(u => u.id == id).FirstOrDefault();
                upRow.Role = rname;
                myContext.SaveChanges();
                Imported_User.ItemsSource = myContext.User.ToList();
            }
            catch
            {

            }
        }

        private void Imported_User_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                btnSubmit_user.IsEnabled = false;
                btnUpdate_user.IsEnabled = true;

                var data = Imported_User.SelectedItem;
                string id = (Imported_User.SelectedCells[0].Column.GetCellContent(data) as TextBlock).Text;
                TxtIDR.Text = id;
                string name = (Imported_User.SelectedCells[1].Column.GetCellContent(data) as TextBlock).Text;
                TxtNameR.Text = name;
                string email = (Imported_User.SelectedCells[2].Column.GetCellContent(data) as TextBlock).Text;
                TxtEmailR.Text = email;
                string role = (Imported_User.SelectedCells[4].Column.GetCellContent(data) as TextBlock).Text;
                Cbx_Role.Text = role;
            }
            catch
            {

            }
        }
        private void btn_deleteRole_Click(object sender, RoutedEventArgs e)
        {
            Imported_Role.Items.Remove(Imported_Role.SelectedItem);
        }
        private void btn_deleteUser_Click(object sender, RoutedEventArgs e)
        {
            Imported_User.Items.Remove(Imported_User.SelectedItem);
            myContext.SaveChanges();
        }

        private void Imported_Role_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                btnUpdate_Role.IsEnabled = true;
            }
            catch { }
        }

        private void btnSubmitRole_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var role = new Role(TxtName_Role.Text);
                myContext.Role.Add(role);
                var result = myContext.SaveChanges();
                Imported_Role.ItemsSource = myContext.Role.ToList();
                Cbx_Role.ItemsSource = myContext.Role.ToList();
            }
            catch { }

        }

        private void btnUpdateRole_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(TxtId_Role.Text);
                string name = TxtName_Role.Text;
                var data = myContext.Role.Where(d => d.id == id).FirstOrDefault();
                data.id = id;
                myContext.SaveChanges();
                Imported_Role.ItemsSource = myContext.Role.ToList();
            }
            catch { }
        }
        #endregion
        //Register Email
        #region ChangenPassword
        public void TxtEmailR_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^A-Za-z0-9.@]+$");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnCP_Click(object sender, RoutedEventArgs e)
        {
            string email = TxtCEmail.Text;
            string newpass = TxtCPass.Password.ToString();

            var data = myContext.User.Where(m => m.Email == email).SingleOrDefault();
            if (data!=null)
            {
                data.Password = newpass;
                myContext.SaveChanges();
                MessageBox.Show("Password Changed");
                Microsoft.Office.Interop.Outlook._Application _app = new Outlook.Application();
                Outlook.MailItem mail = (Outlook.MailItem)_app.CreateItem(Outlook.OlItemType.olMailItem);
                mail.To = TxtCEmail.Text;
                mail.Subject = "You change your password";
                mail.Body = "Hi " + data.Name + ", this is your new password : " + newpass;
                mail.Importance = Outlook.OlImportance.olImportanceNormal;
                ((Outlook._MailItem)mail).Send();
                TxtCEmail.Text = "";
                TxtCPass.Password = "";

            }
            else
            {
                MessageBox.Show("Re-Entry Email");
                TxtCEmail.Text = "";
                TxtCPass.Password = "";
            }
        }
        #endregion

    }

}