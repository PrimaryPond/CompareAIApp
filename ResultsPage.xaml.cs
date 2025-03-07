using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Swapper.xaml
    /// </summary>
    public partial class ResultsPage : Window
    {

        private Product A;
        private Product B;
        private ObservableCollection<ComparisonRow> _comparisonData;
        public ResultsPage(ApiKeyManager apiKeyManager)
        {
            A = new Product("Iphone 3", 125.3, 3, "I am a phone duh", "I have all the good stuff, from not good stuff to amazing stuff, you have no idea. I have all the good stuff, from not good stuff to amazing stuff, you have no idea. I have all the good stuff, from not good stuff to amazing stuff, you have no idea. ", null);
            B = new Product("Iphone 6", 2005.3, 3, "you dont know", "I have some of the good stuff, from not good stuff to amazing stuff, you have no idea. I have all the good stuff, from not good stuff to amazing stuff, you have no idea. I have all the good stuff, from not good stuff to amazing stuff, you have no idea. ", null);
            InitializeComponent();
            dataGrid.Columns[1].Header = A.productName;
            dataGrid.Columns[2].Header = B.productName;
            SetupDataGrid();
        }

        public ResultsPage(Product A, Product B)
        {
            InitializeComponent();
            this.A = A;
            this.B = B;
            SetupDataGrid();
            
        }

        private void SetupDataGrid()
        {
            // Create sample products
            

            // Generate comparison data
            _comparisonData = new ObservableCollection<ComparisonRow>
            {
                new ComparisonRow { Category = "Description", Product1Value = A.productLongDesc, Product2Value = B.productLongDesc },
                new ComparisonRow { Category = "Price", Product1Value = A.productPrice.ToString("C"), Product2Value = B.productPrice.ToString("C") },
                new ComparisonRow { Category = "Reviews", Product1Value = String.Join(", ", A.productRating), Product2Value = String.Join(", ", B.productRating) }
            };

            // Set the DataContext
            dataGrid.ItemsSource = _comparisonData;
        }
    }
    public class ComparisonRow
    {
        public string Category { get; set; }
        public string Product1Value { get; set; }
        public string Product2Value { get; set; }
    }
}
