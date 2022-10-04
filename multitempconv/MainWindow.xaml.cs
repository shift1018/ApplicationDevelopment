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

namespace multitempconv
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




        //private void RbninputCelsius_Checked(object sender, RoutedEventArgs e)
        //{




        //}

        //private void RbninputFahrenheit_Checked(object sender, RoutedEventArgs e)
        //{
        //    double input = Double.Parse(inputbox.Text);

        //    double output;
        //    if (RbnoutputCelsius.IsChecked == true)
        //    {
        //        output = (input - 32) * 5 / 9;
        //        outputbox.Text = output.ToString();
        //    }
        //    else if (RbnoutputFahrenheit.IsChecked == true)
        //    {
        //        output = input;
        //        outputbox.Text = output.ToString();
        //    }
        //    else if (RbnoutputKelvin.IsChecked == true)
        //    {
        //        output =;
        //        outputbox.Text = output.ToString();
        //    }

        //}

        //private void RbninputKelvin_Checked(object sender, RoutedEventArgs e)
        //{
        //    double input = Double.Parse(inputbox.Text);

        //    double output;
        //    if (RbnoutputCelsius.IsChecked == true)
        //    {
        //        output = input - 273.15;
        //        outputbox.Text = output.ToString();
        //    }
        //    else if (RbnoutputFahrenheit.IsChecked == true)
        //    {
        //        output = (input - 273.15) * 9 / 5 + 32;
        //        outputbox.Text = output.ToString();
        //    }
        //    else if (RbnoutputKelvin.IsChecked == true)
        //    {
        //        output = input;
        //        outputbox.Text = output.ToString();
        //    }
        //}

        private void RbnoutputCelsius_Checked(object sender, RoutedEventArgs e)
        {
            double input = double.Parse(inputbox.Text);
            Console.WriteLine(input);


            double output;
            if (RbninputCelsius.IsChecked == true)
            {
                output = input;
                outputbox.Text = output.ToString();
            }
            else if (RbninputFahrenheit.IsChecked == true)
            {
                output = (input -32)*5/9;
                outputbox.Text = output.ToString();
            }
            else if (RbninputKelvin.IsChecked == true)
            {
                output = input - 273.15;
                outputbox.Text = output.ToString();
            }
        }

        private void RbnoutputFahrenheit_Checked(object sender, RoutedEventArgs e)
        {
            double input = double.Parse(inputbox.Text);
            Console.WriteLine(input);


            double output;
            if (RbninputCelsius.IsChecked == true)
            {
                output = input*9/5 +32;
                outputbox.Text = output.ToString();
            }
            else if (RbninputFahrenheit.IsChecked == true)
            {
                output = input;
                outputbox.Text = output.ToString();
            }
            else if (RbninputKelvin.IsChecked == true)
            {
                output = (input - 273.15) *9/5+32;
                outputbox.Text = output.ToString();
            }
        }

        private void RbnoutputKelvin_Checked(object sender, RoutedEventArgs e)
        {
            double input = double.Parse(inputbox.Text);
            Console.WriteLine(input);


            double output;
            if (RbninputCelsius.IsChecked == true)
            {
                output = input+273.15;
                outputbox.Text = output.ToString();
            }
            else if (RbninputFahrenheit.IsChecked == true)
            {
                output = ((input - 32) * 5 / 9) + 273.15;
                outputbox.Text = output.ToString();
            }
            else if (RbninputKelvin.IsChecked == true)
            {
                output = input;
                outputbox.Text = output.ToString();
            }
        }
    }
}
