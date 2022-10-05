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
using System.Xml.Linq;

namespace tempconvsimple
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

        private void ConvertLabel_Click(object sender, RoutedEventArgs e)
        {
            

            string Fahrenheit = Finput.Text;
            

            if (Fahrenheit == "")
            {
                MessageBox.Show("Input must not be empty!", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double input = double.Parse(Fahrenheit);
            double output = (input - 32) * 5 / 9;
            Coutput.Text = output.ToString();
            string Celsius = Coutput.Text;

            LblGreeting.Content = $" {Fahrenheit}°F = {Celsius} °C";
        
        }
    }
}
