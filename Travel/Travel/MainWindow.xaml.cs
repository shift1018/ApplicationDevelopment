using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Xml.Linq;

namespace Travel
{

    public partial class MainWindow : Window
    {
        List<Trip> TripsList = new List<Trip>();
        const string DataFileName = @"..\..\trips.txt";

        public static SocietyDBContext dbContext;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                dbContext = new SocietyDBContext(); 
                LvTrips.ItemsSource = dbContext.Trips.ToList(); 
            }
            catch (SystemException ex)
            {
                MessageBox.Show(this, "Error reading from database\n" + ex.Message, "Fatal error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Trip newTrip = new Trip(DestinationInput.Text, NameInput.Text, PassportNoInput.Text, (DateTime)DepartureDate.SelectedDate, (DateTime)ReturnDate.SelectedDate) ;  
                dbContext.Trips.Add(newTrip);
                dbContext.SaveChanges(); // SystemException
                LvTrips.ItemsSource = dbContext.Trips.ToList();
                //clear inputs
                ResetFields();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(this, ex.Message, "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SystemException ex)
            {
                MessageBox.Show(this, "Error reading from database\n" + ex.Message, "Database error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            //LvPeople.ItemsSource = Globals.DbContext.People.ToList(); // ex, equivalent of
            //ResetFields();
            Trip currSelectedTrip = LvTrips.SelectedItem as Trip;
            if (currSelectedTrip == null) return;
            var result = MessageBox.Show(this, "Are you sure you want to delete this item?", "Confirm deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes) return;
            try
            {
                dbContext.Trips.Remove(currSelectedTrip);
                dbContext.SaveChanges(); 
                LvTrips.ItemsSource = dbContext.Trips.ToList(); 
                ResetFields();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(this, "Error reading from database:\n" + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Trip currSelectedTrip = LvTrips.SelectedItem as Trip;
            if (currSelectedTrip == null) return;
            try
            {
                currSelectedTrip.Destination = DestinationInput.Text;
                currSelectedTrip.TravellerName = NameInput.Text;
                currSelectedTrip.TravellerPassport = PassportNoInput.Text;
                currSelectedTrip.DepartureDate = (DateTime)DepartureDate.SelectedDate;
                currSelectedTrip.ReturnDate = (DateTime)ReturnDate.SelectedDate ;
                dbContext.SaveChanges();
                LvTrips.ItemsSource = dbContext.Trips.ToList(); 
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(this, ex.Message, "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            catch (SystemException ex)
            {
                MessageBox.Show(this, "Unable to access the database:\n" + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveSelected_Click(object sender, RoutedEventArgs e)
        {
            //Trip currSelectedTrip = LvTrips.SelectedItem as Trip;
            //TripsList.Add(currSelectedTrip);
            List<Trip> TripsList = dbContext.Trips.ToList();
            List<string> lines = new List<string>();
            foreach (Trip t in TripsList)
            {
                lines.Add($"{t.Destination};{t.TravellerName};{t.TravellerPassport};{t.DepartureDate};{t.ReturnDate}");
            }
            try
            {
                File.WriteAllLines(DataFileName, lines);
            }
            catch (Exception ex) when (ex is IOException || ex is SystemException)
            {
                MessageBox.Show(this, "Error writing to file\n" + ex.Message, "File access error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LvTrips_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Trip currSelectedTrip = LvTrips.SelectedItem as Trip;
            BtnUpdate.IsEnabled = (currSelectedTrip != null);
            BtnDelete.IsEnabled = (currSelectedTrip != null);
            if (currSelectedTrip == null)
            {
                ResetFields();
            }
            else
            {
                DestinationInput.Text = currSelectedTrip.Destination;
                NameInput.Text = currSelectedTrip.TravellerName;
                PassportNoInput.Text = currSelectedTrip.TravellerPassport;
                DepartureDate.SelectedDate = currSelectedTrip.DepartureDate;
                ReturnDate.SelectedDate = currSelectedTrip.ReturnDate;
            }
        }

        private void ResetFields()
        {
            
            DestinationInput.Text = "";
            NameInput.Text = "";
            PassportNoInput.Text = "";
            DepartureDate.SelectedDate = DateTime.Today;
            ReturnDate.SelectedDate = DateTime.Today;
            BtnDelete.IsEnabled = false;
            BtnUpdate.IsEnabled = false;
        }
    }
}
