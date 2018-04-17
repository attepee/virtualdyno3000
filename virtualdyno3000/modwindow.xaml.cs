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
using System.Windows.Shapes;

namespace virtualdyno3000
{
    /// <summary>
    /// Interaction logic for modwindow.xaml
    /// </summary>
    public partial class ModWindow : Window
    {
        public ModWindow(Car c)
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            // Save car configuration to db
        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void mainButton_Click(object sender, RoutedEventArgs e)
        {
            // Closes this and opens main
            MainWindow mWindow = new MainWindow();
            mWindow.Show();
            this.Close();
        }
        private void dynoButton_Click(object sender, RoutedEventArgs e)
        {
            // Closes this and open dynowindow
            DynoWindow dwin = new DynoWindow();
            dwin.Show();
            this.Close();
        }

        private void partBox_DropDownClosed(object sender, EventArgs e)
        {
            // Creates a list and loads parts from database to it 
            List<Part> parts = new List<Part>();
            parts = DB.LoadPart();

            // Remove items that don't match the selection and add them to partGrid
            parts.RemoveAll(x => x.parttype != partBox.SelectedIndex + 1);
            partGrid.ItemsSource = parts;
        }
    }
}
