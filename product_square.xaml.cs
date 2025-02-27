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
        public product_square()
        {

            InitializeComponent();            
            product = new Product("", -1, -1, "");
            ProductName = "Error, couldn't find title";
            ProductDesc = "Error, couldn't find descritption";

        }
        public product_square(Product p)
        {
            InitializeComponent(); 
            product = p;
            ProductName = p.productName;
            ProductDesc = p.productDesc;

        }

        private void tb_name_TextChanged()
        {

        }
       
       
    }
}
