using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace ToDo
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Globals.DbContext = new SocietyDBContext(); // FIXME: exceptions
                LvTask.ItemsSource = Globals.DbContext.TodoList.ToList(); // equivalent of SELECT * FROM People
            }
            catch (SystemException ex)
            {
                MessageBox.Show(this, "Unable to access the database:\n" + ex.Message, "Fatal database error", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }
        }
        private void BtnAddPerson_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDeletePerson_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnUpdatePerson_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LvTask_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Person currSelPer = LvPeople.SelectedItem as Person;
            //// Either this or Binding in XAML to enable/disable buttons
            //// BtnUpdatePerson.IsEnabled = (currSelPer != null);
            //// BtnDeletePerson.IsEnabled = (currSelPer != null);
            //if (currSelPer == null)
            //{
            //    ResetFields();
            //}
            //else
            //{
            //    TbxName.Text = currSelPer.Name;
            //    TbxAge.Text = currSelPer.Age.ToString();
            //}
        }

       

        private void btnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //if (saveFileDialog.ShowDialog() == true)
            //    File.WriteAllText(saveFileDialog.FileName, txtEditor.Text);
        }
    }
}
