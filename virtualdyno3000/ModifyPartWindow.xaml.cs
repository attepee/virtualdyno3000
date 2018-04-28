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
    /// Interaction logic for ModifyPartWindow.xaml
    /// </summary>
    public partial class ModifyPartWindow : Window
    {
        private Part partToModify;

        public ModifyPartWindow(Part part)
        {
            InitializeComponent();

            partToModify = part;

            // Set values according to selected part
            manufacturerTextBox.Text = partToModify.manufacturer;
            modelTextBox.Text = partToModify.partname;
            partTypeBox.SelectedIndex = partToModify.parttype - 1;
            stageBox.SelectedIndex = partToModify.stage - 1;
            toughnessBox.SelectedIndex = partToModify.toughness - 1;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            bool save = true;
            if (manufacturerTextBox.Text != "" &&
                modelTextBox.Text != "" &&
                partTypeBox.SelectedIndex != -1 &&
                stageBox.SelectedIndex != -1 &&
                toughnessBox.SelectedIndex != -1)
            {
                // if fields are not empty, add selected data to part
                partToModify.manufacturer = manufacturerTextBox.Text;
                partToModify.partname = modelTextBox.Text;
                partToModify.parttype = partTypeBox.SelectedIndex + 1;
                partToModify.stage = stageBox.SelectedIndex + 1;
                partToModify.toughness = toughnessBox.SelectedIndex + 1;
            }
            else
            {
                // If some fields are empty
                save = false;
                MessageBox.Show("check input fields!");
            }
            if (save)
            {
                //Add new part to DB
                if (DB.UpdatePart(partToModify))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Something went wrong, part not modified.");
                }
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            // Clears any text and selections from
            // textboxes and combobox
            manufacturerTextBox.Text = null;
            modelTextBox.Text = null;
            partTypeBox.SelectedIndex = -1;
            stageBox.SelectedIndex = -1;
            toughnessBox.SelectedIndex = -1;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            // Close partToModifyWindow
            this.Close();
        }
    }
}
