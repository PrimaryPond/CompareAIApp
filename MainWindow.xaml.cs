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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_startCompare_Click(object sender, RoutedEventArgs e)
        {
            dosym();
           
           /*
            ComparePage p = new ComparePage();
            p.Show();

            this.Close();
            */
        }
        private async Task dosym()
        {
            OllamaProductInfoApp.ProductInfoService service = new OllamaProductInfoApp.ProductInfoService();
            var productInfo = await OllamaProductInfoApp.ProductInfoService.GetProductInformationAsync("iphone 13");
            MessageBox.Show(productInfo);

        }
    }
}