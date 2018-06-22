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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InvoiceWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        InvoiceDBContext db = new InvoiceDBContext();
        //InvoiceDBContext
        public MainWindow()
        {
            InitializeComponent();
            getInvoices();
            getItem();
        }
        private void getInvoices()
        {
            dgrdInvoice.ItemsSource =
                (from a in db.Invoices
                 select new { a.Name,a.Address })
                 .ToList();
        }
        private void getItem()
        {
            dgrdItem.ItemsSource =
                (from a in db.Items
                 select new { a.Name, a.Quantity,a.Price })
                 .ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            getInvoices();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            getItem();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Item newItem = new Item();
            newItem.Name = txtName.Text;
            newItem.Quantity = Convert.ToInt32( txtQuantity.Text);
            newItem.Price = Convert.ToDecimal(txtPrice.Text);
            newItem.InvoiceID = Convert.ToInt32(txtInvoice.Text);
            db.Items.Add(newItem);
            db.SaveChanges();
        }
    }
}
