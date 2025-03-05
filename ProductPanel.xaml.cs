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

namespace CompareAI
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class ProductPanel : UserControl
    {
        private Product product;
        private string productName;
        private bool isone;
        public string ProductName
        {
            get { return productName; }
            set { 
                productName = value; 
                tbProductName.Content = productName;
                }
        }
        private string productDesc;
        public string ProductDesc
        {
            get { return productDesc; }
            set
            {
                productDesc = value;
                tbProductDesc.Text = productDesc;
            }
        }
        public ProductPanel(bool isone)
        {
            InitializeComponent();
            this.isone = isone;
        }
        public ProductPanel(Product p, bool isone)
        {
            InitializeComponent();
            product = p;
            ProductName = p.productName;
            ProductDesc = p.productShortDesc;
            this.isone = isone;
            
        }

        private void btn_select_Click(object sender, RoutedEventArgs e)
        {
            if (isone)
            {
                General.productSelectOne = product;
            }
            else
            {
                General.productSelectTwo = product;
            }
            Window.GetWindow(this).Close();
        }
    }
}
