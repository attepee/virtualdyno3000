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
    /// Interaction logic for dynowindow.xaml
    /// </summary>
    public partial class DynoWindow : Window
    {
        public DynoWindow()
        {
            InitializeComponent();
        }

        private int ellipselenght = 374;
        private Point currentposition = new Point(0, 228);


        private async void startButton_Click(object sender, RoutedEventArgs e)
        {
            int h = 0;
            int a = 200;
            int g = 0;
            int f = 10;
            for (int j = 0; j < 200; j++)
            {
                await Task.Delay(5);
                Random r = new Random();
                int rInt = r.Next(187, 189);
                int homo = rInt - g;

                //int range = 2;
                Ellipse ellipsePoints = new Ellipse() { Width = 4, Height = 4, Fill = Brushes.Red };
                Ellipse ellipsePoint = new Ellipse() { Width = 4, Height = 4, Fill = Brushes.Yellow };
                Canvas.SetLeft(ellipsePoints, h);
                Canvas.SetTop(ellipsePoints, homo);
                Canvas.SetLeft(ellipsePoint, f);
                Canvas.SetTop(ellipsePoint, homo);

                dynoCanvas.Children.Add(ellipsePoint);

                dynoCanvas.Children.Add(ellipsePoints);
                h++;
                h++;
                a--;


                g++;

                f++;
                f++;

            }

            hp.Text = "HP: 250";
            nm.Text = "NM: 213";
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            // Stops the dyno
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            // Saves results ot db
        }

        private void menuButton_Click(object sender, RoutedEventArgs e)
        {
            // Closes dynowindow and opens main
            MainWindow mWindow = new MainWindow();
            mWindow.Show();
            this.Close();
        }

        private void modButton_Click(object sender, RoutedEventArgs e)
        {
            // closes dynowindow and opens modwindow
            Car auto = new Car();
            ModWindow modWundow = new ModWindow(auto);
            modWundow.Show();
            this.Close();
        }
    }
}
