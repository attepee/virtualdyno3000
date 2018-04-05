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
    /// Interaction logic for NewPartWindow.xaml
    /// </summary>
    public partial class NewPartWindow : Window
    {
        public NewPartWindow()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            // Close NewPartWindow
            this.Close();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            // Clears any text and selections from
            // textboxes and combobox
            manufacturerTextBox.Text = null;
            nameTextBox.Text = null;
            partTypeBox.SelectedIndex = -1;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             * SelectedIndexe means the selected item
             * -1 is nothing, 0 is the first item and so on
             * 
            int selection = partTypeBox.SelectedIndex;
            MessageBox.Show(selection.ToString());
            */

            Part newPart = new Part();
            newPart.manufacturer = manufacturerTextBox.Text;
            newPart.partname = nameTextBox.Text;
            newPart.parttype = partTypeBox.SelectedIndex;
        }
    }
}
