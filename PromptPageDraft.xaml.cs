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
    public partial class PromptPageDraft : Window
    {
        public PromptPageDraft()
        {
            InitializeComponent();
        }


        private void TextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (txtPrompt.Text.Equals("Search for a Product")) { txtPrompt.Text = ""; }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}