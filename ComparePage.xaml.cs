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
using WpfApp1;

namespace CompareAI
{
    /// <summary>
    /// Interaction logic for ComparePage.xaml
    /// </summary>
    public partial class ComparePage : Window
    {
        public ComparePage()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow p = new MainWindow();
                        p.Show();

                        this.Close();
        }

        private void btn_search_one_Click(object sender, RoutedEventArgs e)
        {
            PromptPage p = new PromptPage();
            p.Show();

        }

        private void btn_search_two_Click(object sender, RoutedEventArgs e)
        {
            PromptPage p = new PromptPage();
            p.Show();
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            Results p = new Results();
            p.Show();

        }
    }
}
