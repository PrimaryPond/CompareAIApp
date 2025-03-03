using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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

namespace CompareAI
{
    /// <summary>
    /// Interaction logic for product_square.xaml
    /// </summary>
    public partial class product_square : UserControl
    {
        private readonly ApiKeyManager _apikey;
        Product product;
        public string ProductName
        {
            get { return product.productName; }
            set
            {
                product.productName = value;
                tb_name.Text = product.productName;
            }
        }
        public string ProductDesc
        {
            get { return product.productDesc; }
            set
            {
                product.productDesc = value;
                tb_desc.Text = product.productDesc;
            }
        }
        public string NumberID
        public string numberID
        {
            get { return NumberID; }
            set
            {
                NumberID = value;
            }
        }
        public product_square(ApiKeyManager api)
        {
            
            InitializeComponent();            
            product = new Product("", -1, -1, "");
            ProductName = "Error, couldn't find title";
            ProductDesc = "Error, couldn't find descritption";
            _apikey = api;

        }
        public product_square(Product p, ApiKeyManager api)
        {
            numberID = num;
            InitializeComponent(); 
            product = p;
            ProductName = p.productName;
            ProductDesc = p.productDesc;
            _apikey = api;

        }

        private void tb_name_TextChanged()
        {

        }

        private void btn_search_one_Click(object sender, RoutedEventArgs e)
        {
            PromptPage p = new PromptPage(_apikey, (CompareAI.ComparePage)Window.GetWindow(this));
            p.Show();

            
        }
    }
}
