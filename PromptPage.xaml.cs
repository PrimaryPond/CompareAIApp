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

namespace CompareAI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PromptPage : Window
    {
        private readonly ApiKeyManager _apiKeyManager;
        private ComparePage _page;
        public PromptPage(ApiKeyManager api, ComparePage page)
        {
            InitializeComponent(); 
            _apiKeyManager = api;
            _page = page;
        }
        
        public void closeMethod(object sender, System.EventArgs e) { _page.update(); }

        private void TextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (txtPrompt.Text.Equals("Enter a Product")) { txtPrompt.Text = ""; }
            
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Enter)
            {
                callAPI(_apiKeyManager, txtPrompt.Text);
            }
        }

        private void btn_Enter_Click(object sender, RoutedEventArgs e)
        {
            callAPI(_apiKeyManager, txtPrompt.Text);

            /*
            General.Products.Add(new Product("iphone", 20.10, 3.4, "clicks stuff", "none"));
            General.Products.Add(new Product("samsung", 10.10, 4, "clicks stuff", "none"));
            General.Products.Add(new Product("who knows", 15.10, 2, "clicks stuff", "none"));

            General.serialize();*/
        }

        private async Task callAPI(ApiKeyManager api, string txt)
        {
            string? response = await GeminiApiClient.findmultipleproducts(api, txt);

            if (response != null)
            {
                General.deserialize(response);
            }

            populateProducts();

        }

        private void populateProducts()
        {
            stackPanel_viewer.Children.Clear();

            foreach (Product p in General.Products)
            {
                ProductPanel a;
                try
                {
                    a = new ProductPanel(p);
                }
                catch { continue; }
                stackPanel_viewer.Children.Add(a);
                
            }
        }

    }
}