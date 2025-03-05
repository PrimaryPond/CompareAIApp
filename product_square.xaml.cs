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
        private bool isone;
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
            get { return product.productShortDesc; }
            set
            {
                product.productShortDesc = value;
                tb_desc.Text = product.productShortDesc;
            }
        }
        
        public product_square(ApiKeyManager api, bool isone)
        {
            
            InitializeComponent();            
            product = new Product("", -1, -1, "");
            ProductName = "Error, couldn't find title";
            ProductDesc = "Error, couldn't find descritption";
            _apikey = api;
            this.isone = isone;

        }
        public product_square(Product p, ApiKeyManager api, bool isone)
        {
            InitializeComponent(); 
            product = p;
            ProductName = p.productName;
            ProductDesc = p.productShortDesc;
            _apikey = api;
            this.isone = isone;

        }

        private void tb_name_TextChanged()
        {

        }

        public void setVis(bool isVisible)
        {
            if (isVisible)
            {
                stk_name_close.Visibility = Visibility.Visible;
                
            }
            else
            {
                stk_name_close.Visibility = Visibility.Collapsed;
                
            }
        }
        private void btn_search_one_Click(object sender, RoutedEventArgs e)
        {
            PromptPage p = new PromptPage(_apikey, (CompareAI.ComparePage)Window.GetWindow(this), isone);
            p.Show();

            
        }

        private void btn_product_close_click(object sender, RoutedEventArgs e)
        {
            if (isone)
            {
                General.productSelectOne = null;
            }
            else
            {
                General.productSelectTwo = null;
            }
            setVis(false);
        }
    }
}
