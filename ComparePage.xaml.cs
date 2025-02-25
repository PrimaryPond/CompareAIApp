using System;
using System.IO;
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
using WpfApp1;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;
using System.Diagnostics;

namespace CompareAI
{
    /// <summary>
    /// Interaction logic for ComparePage.xaml
    /// </summary>
    public partial class ComparePage : Window
    {
        
        private readonly ApiKeyManager _apiKeyManager;

        public ComparePage(ApiKeyManager api)
        {
            InitializeComponent();
            _apiKeyManager = api;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow p = new MainWindow(_apiKeyManager);
                        p.Show();

                        this.Close();
        }

        private void btn_search_one_Click(object sender, RoutedEventArgs e)
        {
            PromptPage p = new PromptPage(_apiKeyManager, this);
            p.Show();

        }

        private void btn_search_two_Click(object sender, RoutedEventArgs e)
        {
            PromptPage p = new PromptPage(_apiKeyManager, this);
            p.Show();
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            Results p = new Results();
            p.Show();
            
        }

        private void btn_link_search_one_Click(object sender, RoutedEventArgs e)
        {
            General.Products.Add(new Product("iphone", 20.10, 3.4, "clicks stuff", "none"));
            General.Products.Add(new Product("samsung", 10.10, 4, "clicks stuff", "none"));
            General.Products.Add(new Product("who knows", 15.10, 2, "clicks stuff", "none"));

            File.WriteAllText(Environment.CurrentDirectory.ToString() + "\\..\\..\\..\\lib\\hello.txt", General.serialize());

        }

        private void btn_link_search_two_Click(object sender, RoutedEventArgs e)
        {
            string jsonString = File.ReadAllText(Environment.CurrentDirectory.ToString() + "\\..\\..\\..\\lib\\hello.txt");
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.IncludeFields = true;
            if (jsonString.Length > 0)
            {
                try { 
                    General.deserialize(jsonString);
                    //General.Products = JsonSerializer.Deserialize<List<Product>>(jsonString, options);
                }
                catch {
                    throw new Exception("no - ComparePage.xaml.cs - deserialze bit");
                }
            }
        }

        public static void saveToTxt()
        {
            string jsonString = JsonSerializer.Serialize(General.Products);

            File.WriteAllText(Environment.CurrentDirectory.ToString() + "\\..\\..\\lib\\profiles.txt", jsonString);
        }
        public static void importFromTxt()
        {
            string jsonString = File.ReadAllText(Environment.CurrentDirectory.ToString() + "\\..\\..\\lib\\profiles.txt");
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.IncludeFields = true;
            if (jsonString.Length > 0)
            {
                General.Products = JsonSerializer.Deserialize<List<Product>>(jsonString, options);
            }
            
        }

        public void update()
        {

            if (General.productSelectOne == null)
            {
                stk_one.Children.Clear();
                stk_one.Children.Add(new product_square());
            }
            else if (General.productSelectTwo != null)
            {
               stk_two.Children.Clear();
            }
            
        }
    }
}
