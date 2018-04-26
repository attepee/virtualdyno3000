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
        private Car carToModify;

        public ModWindow(Car car)
        {
            InitializeComponent();

            carToModify = car;

            // Show current cars manufacturer and model
            currentCar.Content = car.manufacturer.ToString() + " " + car.model.ToString();
        }

        private void loadParts()
        {
            // Creates a list and loads parts from database to it 
            List<Part> parts = new List<Part>();
            parts = DB.LoadPart();

            // Remove items that don't match the selection and add them to partGrid
            parts.RemoveAll(x => x.parttype != partBox.SelectedIndex + 1);
            partGrid.ItemsSource = parts;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            // Save car configuration to db
            if (DB.UpdateCar(carToModify))
            {
                // If car is saved to db
                info.Content = "Car saved";
            }
            else
            {
                info.Content = "Something wrong. Car not saved";
            }
        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            // Add selected part to car
            // Add selected part to nPart
            Part nPart = (Part)partGrid.SelectedItem;

            // Switchcase for different parttypes
            switch (nPart.parttype)
            {
                case 1:
                    carToModify.camshaft = nPart.id;
                    info.Content = "Camshaft changed";
                    break;
                case 2:
                    carToModify.piston = nPart.id;
                    info.Content = "Piston changed";
                    break;
                case 3:
                    carToModify.injectionsystem = nPart.id;
                    info.Content = "Injectionsystem changed";
                    break;
                case 4:
                    carToModify.exhaust = nPart.id;
                    info.Content = "Exhaust changed";
                    break;
                case 5:
                    carToModify.turbo = nPart.id;
                    info.Content = "Turbo changed";
                    break;
                case 6:
                    carToModify.block = nPart.id;
                    info.Content = "Block changed";
                    break;
            }
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
            DynoWindow dwin = new DynoWindow(carToModify);
            dwin.Show();
            this.Close();
        }

        private void partBox_DropDownClosed(object sender, EventArgs e)
        {
            loadParts();
        }

        private void modifyPartButton_Click(object sender, RoutedEventArgs e)
        {
            // Modifies selected part

            // Adds data from partGrid to nPart
            Part nPart = (Part)partGrid.SelectedItem;

            if (nPart != null)
            {
                // If part is selected
                ModifyPartWindow nModPartWindow = new ModifyPartWindow(nPart);
                nModPartWindow.Show();
            }
            else
            {
                // If part is not selected
                MessageBox.Show("Select a part");
            }
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            loadParts();
        }

        private void removePartButton_Click(object sender, RoutedEventArgs e)
        {
            // Removes selected part

            // Adds data from partGrid to nPart
            Part nPart = (Part)partGrid.SelectedItem;

            if (nPart != null)
            {
                // If part is selected
                if (DB.DeletePart(nPart.id))
                {
                    // If removal is succesfull
                    MessageBox.Show("Part removed.");
                }
                else
                {
                    MessageBox.Show("Something went wrong, part not removed");
                }
            }
            else
            {
                // If part is not selected
                MessageBox.Show("Select a part");
            }
        }

        private void addPartButton_Click(object sender, RoutedEventArgs e)
        {
            // Open NewPartWindow
            NewPartWindow nPartWindow = new NewPartWindow();
            nPartWindow.Show();
        }
    }
}
