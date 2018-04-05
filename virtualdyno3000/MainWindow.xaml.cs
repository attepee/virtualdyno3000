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
            List<Car> cars = new List<Car>();
            cars = DB.LoadCar();

            // Lisää stackpaneliin datagridin, näin datagridistä
            // saa automaattisesti sopivan kokoisen riveihin nähden
            DataGrid carGrid = new DataGrid();
            stackPanel.Children.Add(carGrid);
            carGrid.ItemsSource = cars;

            //https://github.com/Microsoft/InteractiveDataDisplay.WPF
        }

        private void addCarButton_Click(object sender, RoutedEventArgs e)
        {
            // Avaa uuden auton lisäämis ikkunan ja sulkee pääikkunan
            NewCarWindow nCarWindow = new NewCarWindow();
            nCarWindow.Show();
            this.Close();
        }

        private void testCarButton_Click(object sender, RoutedEventArgs e)
        {
            DynoWindow dWindow = new DynoWindow();
            dWindow.Show();
            this.Close();
        }

        private void modCarButton_Click(object sender, RoutedEventArgs e)
        {
            ModWindow mWindow = new ModWindow();
            mWindow.Show();
            this.Close();
        }
    }
}
