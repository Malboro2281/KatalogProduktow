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

namespace KatalogProduktow
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

        private void NazwaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Oblicz(object sender, RoutedEventArgs e)
        {
            int cena;
            int ilosc;  

            if (int.TryParse(CenaTextBox.Text, out cena) && int.TryParse(IloscTextBox.Text, out ilosc)) // double.TryParse dla liczb z przecinkiem
            {

                if (cena < 0 || ilosc < 0)
                {
                    WynikTextBlock.Text = "Podaj wartości większe od zera!";

                }
                else
                {
                    WynikTextBlock.Text = "Wynik: " + cena * ilosc;
                }
                }
            else
            {
                WynikTextBlock.Text = "Podaj poprawne wartości!";
            }
        }
    }
}