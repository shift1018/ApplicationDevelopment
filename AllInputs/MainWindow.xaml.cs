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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace AllInputs
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

        

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //string name = TbxName.Text;
            ////fixme:validate
            //if (name == "")
            //{
            //    MessageBox.Show("Name must not be empty!", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return;
            //}

            //MessageBox.Show($"Hello {name}，nice to meet you!", "Greeting", MessageBoxButton.OK, MessageBoxImage.Information);

           // < Label Content = "What is your name?" HorizontalAlignment = "Left" Margin = "10,10,0,0" VerticalAlignment = "Top"  Width = "107" FontSize = "11" />
       // < TextBox x: Name = "TbxName" HorizontalAlignment = "Left" Margin = "152,13,0,0" TextWrapping = "Wrap" Text = "" VerticalAlignment = "Top" Width = "109" RenderTransformOrigin = "0.133,-2.283" />
        //< Button Content = "Say Hello (label)" HorizontalAlignment = "Left" Margin = "19,47,0,0" VerticalAlignment = "Top" Click = "btnSayHelloLabel_Click" />
        //< Button Content = "Say Hello (msg box)" HorizontalAlignment = "Left" Margin = "152,47,0,0" VerticalAlignment = "Top" RenderTransformOrigin = "0.478,0.603" Click = "btnSayHelloPopuo_Click" />
       // < Label x: Name = "LblGreeting" Content = "..." HorizontalAlignment = "Left" Margin = "19,87,0,0" VerticalAlignment = "Top" Width = "251" />
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
