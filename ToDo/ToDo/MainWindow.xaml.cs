using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Day05ToDo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TodoDbContext dbContext;

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                dbContext = new TodoDbContext(); // Exceptions
                LvToDos.ItemsSource = dbContext.ToDos.ToList(); // equivalent of SELECT * FROM people
            }
            catch (SystemException ex)
            {
                MessageBox.Show(this, "Error reading from database\n" + ex.Message, "Fatal error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() != true) return; // cancelled
            //
            List<Todo> toDoExport = dbContext.ToDos.ToList();
            List<string> lines = new List<string>();
            foreach (Todo p in toDoExport)
            {
                lines.Add($"{p.Task};{p.Difficulty};{p.DueDate};{p.Status}");
            }
            try
            {
                File.WriteAllLines(saveFileDialog.FileName, lines); // ex IO/Sys
                MessageBox.Show(this, "Export complete!", "Export Status", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex) when (ex is IOException || ex is SystemException)
            {
                MessageBox.Show(this, "Export failed\n" + ex.Message, "Export Status", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Todo newToDo = new Todo(TaskInput.Text, (int)DifficultySlider.Value, (DateTime)DueDate.SelectedDate, (Todo.StatusEnum)StatusComboBox.SelectedIndex);  // ArgumentException
                dbContext.ToDos.Add(newToDo);
                dbContext.SaveChanges(); // SystemException
                LvToDos.ItemsSource = dbContext.ToDos.ToList();
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
            Todo currSelectedToDo = LvToDos.SelectedItem as Todo;
            if (currSelectedToDo == null) return;
            var result = MessageBox.Show(this, "Are you sure you want to delete this item?", "Confirm deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes) return;
            try
            {
                dbContext.ToDos.Remove(currSelectedToDo);
                dbContext.SaveChanges(); // ex
                LvToDos.ItemsSource = dbContext.ToDos.ToList(); // ex, equivalent of SELECT * FROM People
                ResetFields();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(this, "Error reading from database:\n" + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Todo currSelectedToDo = LvToDos.SelectedItem as Todo;
            if (currSelectedToDo == null) return;
            try
            {
                currSelectedToDo.Task = TaskInput.Text; // ArgumentException
                currSelectedToDo.Difficulty = (int)DifficultySlider.Value; // ArgumentException
                currSelectedToDo.DueDate = (DateTime)DueDate.SelectedDate; // ArgumentException
                currSelectedToDo.Status = (Todo.StatusEnum)StatusComboBox.SelectedIndex; // ArgumentException
                /*var selectedTag = ((ComboBoxItem)StatusComboBox.SelectedItem).Tag.ToString();
                currSelectedToDo.Status = (Todo.StatusEnum) Enum.Parse(typeof(Todo.StatusEnum), selectedTag); //ex: ?? should never happen, internal error */
                dbContext.SaveChanges(); // SystemException
                LvToDos.ItemsSource = dbContext.ToDos.ToList(); // SystemException
                ResetFields();
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

        private void LvTodos_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Todo currSelectedToDo = LvToDos.SelectedItem as Todo;
            if (currSelectedToDo == null)
            {
                ResetFields();
            }
            else
            {
                BtnDelete.IsEnabled = true;
                BtnUpdate.IsEnabled = true;
                TaskInput.Text = currSelectedToDo.Task;
                DifficultySlider.Value = currSelectedToDo.Difficulty;
                DueDate.SelectedDate = currSelectedToDo.DueDate;
                StatusComboBox.SelectedIndex = (int)currSelectedToDo.Status;
            }
        }

        private void ResetFields()
        {
            TaskInput.Text = "";
            DifficultySlider.Value = 1;
            DueDate.SelectedDate = DateTime.Today;
            StatusComboBox.SelectedIndex = 0;
            BtnDelete.IsEnabled = false;
            BtnUpdate.IsEnabled = false;
        }

        private void Window_Initialized(object sender, EventArgs e)
        {

        }
    }
}
