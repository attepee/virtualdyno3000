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

namespace virtualdyno3000
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Load cars
            loadCars();
        }

        private void loadCars()
        {
            // https://github.com/Microsoft/InteractiveDataDisplay.WPF
            // Creates a list and loads cars from
            // database to it 
            List<Car> cars = new List<Car>();
            cars = DB.LoadCar();

            // Adds cars from list to datagrid 
            carGrid.ItemsSource = cars;
        }

        private void addCarButton_Click(object sender, RoutedEventArgs e)
        {
            // Open NewCarWindow
            NewCarWindow nCarWindow = new NewCarWindow();
            nCarWindow.Show();
        }

        private void addPartButton_Click(object sender, RoutedEventArgs e)
        {
            // Open NewPartWindow
            NewPartWindow nPartWindow = new NewPartWindow();
            nPartWindow.Show();
        }

        private void testCarButton_Click(object sender, RoutedEventArgs e)
        {
            // Cast selected car to nCar
            Car nCar = (Car)carGrid.SelectedItem;

            if (nCar != null)
            {
                // Open DynoWindow
                DynoWindow nDynoWindow = new DynoWindow(nCar);
                nDynoWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Select a car");
            }
        }

        private void modCarButton_Click(object sender, RoutedEventArgs e)
        {
            // Cast selected car to nCar
            Car nCar = (Car)carGrid.SelectedItem;

            if (nCar != null)
            {
                // Open DynoWindow
                ModWindow nModWindow = new ModWindow(nCar);
                nModWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Select a car");
            }
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            // Exit application
            this.Close();
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            // Load cars
            loadCars();
        }
    }
}
