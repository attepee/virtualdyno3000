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

            // https://github.com/Microsoft/InteractiveDataDisplay.WPF
            // Creates a list and loads cars from
            // database to it 
            List<Car> cars = new List<Car>();
            cars = DB.LoadCar();

            // Adds datagrid to stackpanel so datagrid is
            // Always the right height
            DataGrid carGrid = new DataGrid();
            stackPanel.Children.Add(carGrid);
            carGrid.IsReadOnly = true;

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
            // Open DynoWindow
            DynoWindow dWindow = new DynoWindow();
            dWindow.Show();
            this.Close();
        }

        private void modCarButton_Click(object sender, RoutedEventArgs e)
        {
            // Add ModWindow
            ModWindow mWindow = new ModWindow();
            mWindow.Show();
            this.Close();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            // Exit application
            this.Close();
        }
    }
}
