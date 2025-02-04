using CompareAI;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PromptPage : Window
    {
        public PromptPage()
        {
            InitializeComponent();
        }


        private void TextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (txtPrompt.Text.Equals("Enter a Product")) { txtPrompt.Text = ""; }
            
        }

        private void btn_Enter_Click(object sender, RoutedEventArgs e)
        {
            General.Products.Add(new Product("iphone", 20.10, 3.4, "clicks stuff", "none"));
            General.Products.Add(new Product("samsung", 10.10, 4, "clicks stuff", "none"));
            General.Products.Add(new Product("who knows", 15.10, 2, "clicks stuff", "none"));

            General.serialize();
        }

 
    }
}