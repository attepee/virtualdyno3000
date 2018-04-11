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
    /// Interaction logic for newcarwindow.xaml
    /// </summary>
    public partial class NewCarWindow : Window
    {
        Car c = new Car();

        public NewCarWindow()
        {
            InitializeComponent();
        }
        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            bool save = true;
            if(manufacturer.Text != "" && model.Text != "" && Tools.DoubleRegex(engine.Text) != "" && Tools.IntRegex(year.Text) != "")
            {
                c.manufacturer = manufacturer.Text;
                c.model = model.Text;
                c.engine = Tools.ConvertToDouble(engine.Text);
                c.year = int.Parse(year.Text);
            }
            else
            {
                save = false;
                MessageBox.Show("check input fields!");
            }
            if(save)
            {
                if(DB.CreateCar(c))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Something went wrong, no cars added.");
                }
            }

        }
    }
}
