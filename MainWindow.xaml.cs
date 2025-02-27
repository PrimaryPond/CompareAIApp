using CompareAI;
using Microsoft.Extensions.DependencyInjection;
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

namespace CompareAI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ApiKeyManager _apiKeyManager;

        public MainWindow(ApiKeyManager apiKeyManager)
        {

            InitializeComponent();
            _apiKeyManager = apiKeyManager;
            General.setApi(apiKeyManager);

        }

        private void btn_startCompare_Click(object sender, RoutedEventArgs e)
        {
            //dosym();
           
           
            ComparePage p = new ComparePage(_apiKeyManager);
            p.Show();

            this.Close();
            
        }
        private async Task dosym()
        {
            string jsonthing = await GeminiApiClient.findmultipleproducts(_apiKeyManager, "phones");

            General.deserialize(jsonthing);


        }
    }
}